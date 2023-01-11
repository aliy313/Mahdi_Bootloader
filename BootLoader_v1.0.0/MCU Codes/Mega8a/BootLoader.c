#define Model "Mega8a "
#define BuildNumber 12
#define PageNumber 96
#define PageSize 64
#define E2promSize 512
#define PageNumberH 0
#define PageNumberL 96
#define PageSizeH 0
#define PageSizeL 64
#define E2promSizeH 2
#define E2promSizeL 0
#define F_CPU 8000000
#include <io.h>
#define INTERRUPT_OFF
#include "boot.h"
#include "e2prom.h"
#include <delay.h>
#include "protocols.h"
#define USART_BAUDRATE 500000
#include "usart.h"
#include "types.h"

v8u t;


void Connect()
{
    usart_tx(Connect_Req_Back);
	
	if(usart_rx() != Connect_Continue_1) return;
	
    usart_txs(Model);
	
    if(usart_rx() != Connect_Continue_2) return;
    
    usart_tx(PageNumberH);
    usart_tx(PageNumberL);
    usart_tx(PageSizeH);
    usart_tx(PageSizeL);
	usart_tx(E2promSizeH);
	usart_tx(E2promSizeL);
	usart_tx(BuildNumber);
        
    if(usart_rx() == PageNumberH)
    {
        usart_tx(PageNumber_H_Pass);
    }
    else
    {
        usart_tx(PageNumber_H_Not_Pass);
        return;
    }
	   
    if(usart_rx() == PageNumberL)
    {
        usart_tx(PageNumber_L_Pass);
    }
    else
    {
        usart_tx(PageNumber_L_Not_Pass);
        return;
    }
	            
    if(usart_rx() == PageSizeH)
    {
        usart_tx(PageSize_H_Pass);
    }
    else
    {
        usart_tx(PageSize_H_Not_Pass);
        return;
    }
	    
    if(usart_rx() == PageSizeL)
    {
        usart_tx(PageSize_L_Pass);
    }
    else
    {
        usart_tx(PageSize_L_Not_Pass);
        return;
    }
	
	if(usart_rx() == E2promSizeH)
	{
		usart_tx(E2promSize_H_Pass);
	}
	else
	{
		usart_tx(E2promSize_H_Not_Pass);
		return;
	}
	
	if(usart_rx() == E2promSizeL)
	{
		usart_tx(E2promSize_L_Pass);
	}
	else
	{
		usart_tx(E2promSize_L_Not_Pass);
		return;
	}

	
	if(usart_rx() == BuildNumber)
	{
		usart_tx(BuildNumber_Pass);
	}
	else
	{
		usart_tx(BuildNumber_Not_Pass);
		return;
	}
	
    return;
}

void FuseBitsRead()
{
	v8u tmph = 0;
	v8u tmpl = 0;
	
    usart_tx(FuseBits_Read_Req_Back);
	
	if(usart_rx() != FuseBits_Read_Continue_1) return;
	
	tmph = boot_fusebits_read(1);
	tmpl = boot_fusebits_read(0);
	
    usart_tx(tmph);
    usart_tx(tmpl);
	
    if(usart_rx() == tmph)
	{
		usart_tx(FuseBits_Read_Pass);
	}
	else
	{
		usart_tx(FuseBits_Read_Not_Pass);
		return;
	}
	
	if(usart_rx() == tmpl)
	{
		usart_tx(FuseBits_Read_Pass);
	}
	else
	{
		usart_tx(FuseBits_Read_Not_Pass);
		return;
	}
	
    return;
}

void LockBitsRead()
{
	v8u tmp = 0;
	
    usart_tx(LockBits_Read_Req_Back);
	
	if(usart_rx() != LockBits_Read_Continue_1) return;
	
	tmp = boot_lockbits_read();
	
    usart_tx(tmp);
	
    if(usart_rx() == tmp)
	{
		usart_tx(LockBits_Read_Pass);
	}
	else
	{
		usart_tx(LockBits_Read_Not_Pass);
		return;
	}
    
	return;
}

void LockBitsWrite()
{
    v8u tmp = 0;
	
    usart_tx(LockBits_Write_Req_Back);
	
    tmp = usart_rx();
	
	if(tmp == Error) return;
	
	usart_tx(tmp);
	
	if(usart_rx() != LockBits_Write_Pass_1) return;
	
    boot_lockbits_write(tmp);

    return;
}

void FlashPageWrite()
{
    v8u tmp = 0;
    v16s Page = -1;
    v16s ctr;
    v8u btmp = 0;
	
	
    usart_tx(FlashPage_Write_Req_Back);  
    
    Page = usart_rx();
    Page *= 256;
	
    usart_tx(FlashPage_Write_Continue_1); 
	
    Page += usart_rx();
	
	usart_tx((Page & 0xFF00) >> 8);
	usart_tx(Page & 0x00FF);
	
	if(Page >= PageNumber)
	{
		usart_tx(FlashPage_Write_InvalidPage);
		return;
	}
	
	tmp = usart_rx();
	
	if(tmp == FlashPage_Erase_Operation)
	{
		boot_page_erase(Page);
		usart_tx(FlashPage_Erase_Operation_Done);
		return;
	}
	if(tmp != FlashPage_Write_Operation)
	{
		usart_tx(Error);
		return;
	}
	
	usart_tx(FlashPage_Write_Continue_2);
    
    for(ctr=0 ; ctr < PageSize ; ctr++)
    {
        btmp = usart_rx();
        usart_tx(btmp);
        tmp = usart_rx();
        if(tmp == FlashPage_Write_NextByte)
        {
            page_buffer[ctr] = btmp;
			usart_tx(FlashPage_Write_NextByte_Req);
			if(usart_rx() != FlashPage_Write_NextByte_Req_Back) return;
        }
        else if(tmp == FlashPage_Write_TryByte)
        {
            usart_tx(FlashPage_Write_TryByte_Req);
			if(usart_rx() != FlashPage_Write_TryByte_Req_Back) return;
            ctr--;
        }
		else return;
    }
    
    usart_tx(FlashPage_Write_Wait_Req);
	
	if(usart_rx() != FlashPage_Write_Wait_Req_Back) return;
    
	boot_page_erase(Page);
    boot_page_write(Page);
	
    usart_tx(FlashPage_Write_Done);
    
    return;
}

void FlashPageRead()
{
	v8u tmp = 0;
	v16s Page = -1;
	v16s ctr;
	
	usart_tx(FlashPage_Read_Req_Back);
	
	Page = usart_rx();
	Page *= 256;
	
	usart_tx(FlashPage_Read_Continue_1);
	
	Page += usart_rx();
	
	usart_tx((Page & 0xFF00) >> 8);
	usart_tx(Page & 0x00FF);
	
	if(Page >= PageNumber)
	{
		usart_tx(FlashPage_Read_InvalidPage);
		return;
	}
	
	if(usart_rx() != FlashPage_Read_Page_Pass) return;
	
	boot_page_read(Page);
	
	for(ctr=0 ; ctr < PageSize ; ctr++)
	{
		tmp = page_buffer[ctr];
		usart_tx(tmp);
		
		if(usart_rx() == tmp)
		{
			usart_tx(FlashPage_Read_NextByte);
			if(usart_rx() != FlashPage_Read_NextByte_Req) return;
		}
		else
		{
			usart_tx(FlashPage_Read_TryByte);
			if(usart_rx() != FlashPage_Read_TryByte_Req) return;
			ctr--;
		}
	}
	
	usart_tx(FlashPage_Read_Done);
	
	return;
}

void E2promRead()
{
	v8u tmp = 0;
	v16s Address = 0;
	
	usart_tx(E2prom_Read_Req_Back);
	
	Address = usart_rx();
	Address *= 256;
	
	usart_tx(E2prom_Read_Continue_1);
	
	Address += usart_rx();
	
	usart_tx((Address & 0xFF00) >> 8);
	usart_tx(Address & 0x00FF);
	
	if(Address >= E2promSize)
	{
		usart_tx(E2prom_Read_InvalidAddress);
		return;
	}
	
	if(usart_rx() != E2prom_Read_Address_Pass) return;
	
	tmp = e2prom_byte_read(Address);
	
	usart_tx(tmp);
	
	if(usart_rx() == tmp)
	{
		usart_tx(E2prom_Read_ValidByte);
	}
	else
	{
		usart_tx(E2prom_Read_InvalidByte);
		return;
	}
	
	if(usart_rx() != E2prom_Read_Done) return;
	
	return;
	
}

void E2promWrite()
{
	v8u tmp = 0;
	v16s Address = 0;
	
	usart_tx(E2prom_Write_Req_Back);
	
	Address = usart_rx();
	Address *= 256;
	
	usart_tx(E2prom_Write_Continue_1);
	
	Address += usart_rx();
	
	usart_tx((Address & 0xFF00) >> 8);
	usart_tx(Address & 0x00FF);
	
	if(Address >= E2promSize)
	{
		usart_tx(E2prom_Write_InvalidAddress);
		return;
	}
	
	if(usart_rx() != E2prom_Write_Address_Pass) return;
	
	usart_tx(E2prom_Write_Continue_2);
	
	tmp = usart_rx();
	
	usart_tx(tmp);
	
	if(usart_rx() != E2prom_Write_ValidByte) return;
	
	if(e2prom_byte_write(Address,tmp,1))
	{
		usart_tx(E2prom_Write_Done_Req);
	}
	else
	{
		usart_tx(E2prom_Write_Error);
		return;
	}
	
	if(usart_rx() != E2prom_Write_Done_Req_Back) return;
	
	return;
}

     
void Boot()
{
    v8u tmp = 0;
     
    while(1)
    {
        tmp = usart_rx();
        switch(tmp)
        {
            case Connect_Req:
                Connect();
                break;
            case FuseBits_Read_Req:
                FuseBitsRead();
                break;
            case LockBits_Read_Req:
                LockBitsRead();
                break;
            case LockBits_Write_Req:
                LockBitsWrite();
                break;
            case FlashPage_Write_Req:
                FlashPageWrite();
                break;
			case FlashPage_Read_Req:
				FlashPageRead();
				break;
			case E2prom_Read_Req:
				E2promRead();
				break;
			case E2prom_Write_Req:
				E2promWrite();
				break;
			case Free_Req:
				usart_tx(Free_Req_Back);
				break;
			case Sleep:
                usart_tx(Sleep_Entered);
                delay_ms(100);
                usart_tx_set(0);
                usart_rx_set(0);
                MCUCR  |= 0b00100000;
                MCUCR  |= 0b10000000;
			    #asm("sleep")
				break;
			case Reset_App:
                usart_tx(App_Loaded);
                delay_ms(100);
                usart_tx_set(0);
                usart_rx_set(0);
				#asm("rjmp 0x0000")
				break;
			default:
				usart_tx(Unknown_Command);
				break;
        }
    }
    return;
}



void main(void)
{
    usart_init();
    usart_tx_set(1);
    usart_rx_set(1);
	t = UDR;
	t = UDR;
	t = UDR;
    
    usart_tx(Boot_Loaded);
	
	delay_ms(1000);
    
	if((UCSRA & (1<<RXC))==0)
    {                        
        usart_tx_set(0);
        usart_rx_set(0);    
        #asm("rjmp 0x0000");
    }
    
    Boot();
	
    while (1);
	
}

