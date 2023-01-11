unsigned char e2prom_byte_read(unsigned int address)
{
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	EEAR = address;
	EECR |= 0b1;
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return EEDR;
}


unsigned e2prom_byte_write(unsigned int address , unsigned char data , unsigned verify)
{
	unsigned vertmp = 1;
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	EEAR = address;
	EEDR = data;
	EECR |= 0b100;
	EECR |= 0b10;
	if(verify)
	{
		if(e2prom_byte_read(address) != data) vertmp = 0;
	}
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return vertmp;
}


unsigned int e2prom_word_read(unsigned int address)
{
	unsigned int tmp = 0;
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	
	tmp += e2prom_byte_read(address);
	tmp *= 256;
	
	tmp += e2prom_byte_read(address + 1);
	
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return tmp;
}


unsigned e2prom_word_write(unsigned int address , unsigned int data , unsigned verify)
{
	unsigned vertmp = 1;
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	
	e2prom_byte_write(address , ((data & 0xFF00) >> 8) , 0);
	e2prom_byte_write(address + 1 , (data & 0x00FF) , 0);
	
	if(verify)
	{
		if(e2prom_word_read(address) != data) vertmp = 0;
	}
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return vertmp;
}


unsigned long int e2prom_dword_read(unsigned int address)
{
	unsigned long int tmp = 0;
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	
	tmp += e2prom_word_read(address);
	tmp *= 65536;
	
	tmp += e2prom_word_read(address + 2);
	
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return tmp;
}


unsigned e2prom_dword_write(unsigned int address , unsigned long int data , unsigned verify)
{
	unsigned vertmp = 1;
	while(EECR & 0b10);
	#ifdef INTERRUPT_ON
	cli();
	#endif
	
	e2prom_word_write(address , ((data & 0xFFFF0000) >> 16) , 0);
	e2prom_word_write(address + 2 , (data & 0x0000FFFF) , 0);
	
	if(verify)
	{
		if(e2prom_dword_read(address) != data) vertmp = 0;
	}
	#ifdef INTERRUPT_ON
	//sei();
	#endif
	return vertmp;
}
