// Mega8 Only !

register unsigned char wordH @2;
register unsigned char wordL @3;
register int page_number     @4;
register int word_number     @6;

unsigned int word_ctr;
unsigned char byte_ctr;

volatile unsigned char page_buffer[64];



void boot_page_read(unsigned char _page_number)
{
	unsigned int flash_address = _page_number * 64;
    unsigned char c;
	for(c = 0 ; c<64 ; c++)
	{
		page_buffer[c] = *(const __flash unsigned char *)flash_address;
		flash_address++;
	}
}


void boot_page_erase(unsigned char _page_number)
{
	page_number = _page_number;
	page_number = page_number << 6;
	
    #asm
	movw r30,r4
	ldi  r16,3
	out  0x37,r16
	spm
    #endasm
	while(SPMCR & 0b1);
	
	#asm
	ldi r16,17
	out 0x37,r16
	spm
	#endasm
	while(SPMCR & 0b1000000);
}


void boot_page_write(unsigned char _page_number)
{
	page_number = _page_number;
	page_number = page_number << 6;
    
    byte_ctr = 0;
	for(word_ctr=0; word_ctr<32 ; word_ctr++)
	{
		wordH = page_buffer[byte_ctr];
		byte_ctr++;
		wordL = page_buffer[byte_ctr];
		byte_ctr++;
		word_number = (word_ctr << 1);
        #asm
		movw r0,r2
		movw r30,r6
		ldi r16,1
		out 0x37,r16
		spm
        #endasm
		while(SPMCR & 0b1);
	}
	
    #asm
	movw r30,r4
	ldi r16,5
	out 0x37,r16
	spm
    #endasm
	while(SPMCR & 0b1);
	
	#asm
	ldi r16,17
	out 0x37,r16
	spm
	#endasm
	while(SPMCR & 0b1000000);
}


unsigned char boot_fusebits_read(unsigned low0_high1)
{
	switch(low0_high1)
	{
		case 0:
		page_number = 0;
		break;
		
		case 1:
		page_number = 3;
		break;
	}
    #asm
	movw r30,r4
	ldi r16,9
	out 0x37,r16
	lpm r2,z
    #endasm
	return wordH;
}


void boot_lockbits_write(unsigned char lockvalue)
{
	lockvalue |= 0b11000011;
	wordH = lockvalue;
	page_number = 1;
    #asm
	movw r30,r4
	mov r0,r2
	ldi r16,9
	out 0x37,r16
	spm
    #endasm
	while(SPMCR & 0b1000);
}


unsigned char boot_lockbits_read(void)
{
	page_number = 1;
    #asm
	movw r30,r4
	ldi r16,9
	out 0x37,r16
	lpm r2,z
    #endasm
	return wordH;
}
