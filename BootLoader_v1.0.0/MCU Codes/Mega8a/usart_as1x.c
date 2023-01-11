void usart_init(void)
{
	UCSRA  |=  (0<<MPCM);
	UCSRB  |=  (UCSZ_2<<UCSZ2);
	UCSRC  |=  ((U_CPOL<<UCPOL)|(UCSZ_0<<UCSZ0)|(UCSZ_1<<UCSZ1)|(U_SBS<<USBS)|(UPM_0<<UPM0)|(UPM_1<<UPM1)|(0<<UMSEL)|(1<<URSEL));
	UBRRL = UBRR_L;
	UBRRH = UBRR_H;
}


void usart_txc_interrupt(unsigned txc)
{
	switch(txc)
	{
		case 0:
		UCSRB  &= ~(1<<TXCIE);
		break;
		case 1:
		UCSRB  |=  (1<<TXCIE);
		break;
	}
}


void usart_rxc_interrupt(unsigned rxc)
{
	switch(rxc)
	{
		case 0:
		UCSRB  &= ~(1<<RXCIE);
		break;
		case 1:
		UCSRB  |=  (1<<RXCIE);
		break;
	}
}


void usart_udre_interrupt(unsigned udre)
{
	switch(udre)
	{
		case 0:
		UCSRB  &= ~(1<<UDRIE);
		break;
		case 1:
		UCSRB  |=  (1<<UDRIE);
		break;
	}
}


#if (USART_CHARSIZE == 9)
unsigned usart_read_bit9(void)
{
	return (UCSRB & 0b10);
}


void usart_write_bit9(unsigned bit9)
{
	switch(bit9)
	{
		case 0:
		UCSRB  &= ~(1<<TXB8);
		break;
		case 1:
		UCSRB  |=  (1<<TXB8);
		break;
	}
}


void usart_mpcm(unsigned mpcm)
{
	switch(mpcm)
	{
		case 0:
		UCSRA  &= ~(1<<MPCM);
		break;
		case 1:
		UCSRA  |=  (1<<MPCM);
		break;
	}
}
#endif


void usart_tx_set(unsigned tx)
{
	switch(tx)
	{
		case 0:
		UCSRB  &= ~(1<<TXEN);
		break;
		case 1:
		UCSRB  |=  (1<<TXEN);
		break;
	}
}


void usart_rx_set(unsigned rx)
{
	switch(rx)
	{
		case 0:
		UCSRB  &= ~(1<<RXEN);
		break;
		case 1:
		UCSRB  |=  (1<<RXEN);
		break;
	}
}


unsigned usart_udr_empty_flag(void)
{
	return (UCSRA & 0b100000);
}


unsigned usart_txc_flag(void)
{
	return (UCSRA & 0b1000000);
	UCSRA  |=  (1<<TXC);
}


unsigned usart_rxc_flag(void)
{
	return (UCSRA & 0b10000000);
}


unsigned usart_pe_flag(void)
{
	return (UCSRA & 0b100);
}


unsigned usart_dor_flag(void)
{
	return (UCSRA & 0b1000);
}


unsigned usart_fe_flag(void)
{
	return (UCSRA & 0b10000);
}


unsigned char usart_rx(void)
{
	while((UCSRA & (1<<RXC))==0);
	return UDR;
}


void usart_rxs(char * str , unsigned char size)
{
    unsigned char c;
	for(c=0 ; c<size ; c++)
	{
		while((UCSRA & (1<<RXC))==0);
		str[c] = UDR;
	}
}


void usart_tx(unsigned char byte)
{
	while((UCSRA & (1<<UDRE))==0);
	UDR = byte;
}


void usart_txs(char * str)
{
    unsigned char c;
	for(c=0 ; ; c++)
	{
		if(str[c] != 0)usart_tx(str[c]);
		else break;
	}
}

