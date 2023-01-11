/*
USART Library
Version = 1.2.0
Written by Unknown_313
*/



/*

ISR(USART_RXC_vect)
{
	#asm("cli")
	// Place Your Code Here
	#asm("sei")
}

ISR(USART_TXC_vect)
{
	#asm("cli")
	// Place Your Code Here
	#asm("sei")
}

ISR(USART_UDRE_vect)
{
	#asm("cli")
	// Place Your Code Here
	#asm("sei")
}

*/

//*********************************************************************************************************/

#ifndef __USART_H__
#define __USART_H__

#include <interrupt.h>

#ifndef USART_BAUDRATE
#define USART_BAUDRATE 4800
#endif

#ifndef USART_CHARSIZE
#define USART_CHARSIZE 8
#endif

#ifndef USART_CLOCK_POLARITY_FALLING_EDGE // Read ON FALLING EDGE
#ifndef USART_CLOCK_POLARITY_RISING_EDGE  // Read ON RISING EDGE
#define USART_CLOCK_POLARITY_FALLING_EDGE
#endif
#endif

#ifndef USART_STOP_BIT
#define USART_STOP_BIT 1
#endif

#ifndef USART_PARITY_DISABLE
#ifndef USART_PARITY_EVEN
#ifndef USART_PARITY_ODD
#define USART_PARITY_DISABLE
#endif
#endif
#endif

#ifndef USART_MODE_Asynchronous
#ifndef USART_MODE_Asynchronous2X // not Available for now
#ifndef USART_MODE_SynchronousMaster // not Available for now
#ifndef USART_MODE_SynchronousSlave // not Available for now
#define USART_MODE_Asynchronous
#endif
#endif
#endif
#endif



//**********************************************************************************************************/

#if   (USART_CHARSIZE == 5)
#define UCSZ_0 0
#define UCSZ_1 0
#define UCSZ_2 0
#elif (USART_CHARSIZE == 6)
#define UCSZ_0 1
#define UCSZ_1 0
#define UCSZ_2 0
#elif (USART_CHARSIZE == 7)
#define UCSZ_0 0
#define UCSZ_1 1
#define UCSZ_2 0
#elif (USART_CHARSIZE == 8)
#define UCSZ_0 1
#define UCSZ_1 1
#define UCSZ_2 0
#elif (USART_CHARSIZE == 9)
#define UCSZ_0 1
#define UCSZ_1 1
#define UCSZ_2 1
#endif

//**********************************************************************************************************/

#ifdef USART_CLOCK_POLARITY_FALLING_EDGE
#define U_CPOL 0
#endif
#ifdef USART_CLOCK_POLARITY_RISING_EDGE
#define U_CPOL 1
#endif

//**********************************************************************************************************/

#if   (USART_STOP_BIT == 1)
#define U_SBS 0
#elif (USART_STOP_BIT == 2)
#define U_SBS 1
#endif

//**********************************************************************************************************/

#ifdef USART_PARITY_DISABLE
#define UPM_0 0
#define UPM_1 0
#endif
#ifdef USART_PARITY_EVEN
#define UPM_0 0
#define UPM_1 1
#endif
#ifdef USART_PARITY_ODD
#define UPM_0 1
#define UPM_1 1
#endif

//**********************************************************************************************************/

#ifdef USART_MODE_Asynchronous

#if (F_CPU == 1000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 25
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 12
#define USART_BAUDRATE_PASS
#endif

#endif
#if (F_CPU == 2000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 51
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 25
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 12
#define USART_BAUDRATE_PASS
#endif

#endif
#if (F_CPU == 4000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 103
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 51
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 25
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 12
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 0
#define USART_BAUDRATE_PASS
#endif

#endif
#if (F_CPU == 8000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 207
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 103
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 51
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 25
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 12
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 1
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 0
#define USART_BAUDRATE_PASS
#endif

#endif
#if (F_CPU == 16000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 1
#define UBRR_L 159
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 207
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 103
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 0
#define UBRR_L 68
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 51
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 25
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 12
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 3
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 1
#define USART_BAUDRATE_PASS
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 0
#define USART_BAUDRATE_PASS
#endif
#endif

#ifndef USART_BAUDRATE_PASS
#error invalid Usart Baudrate defined !
#endif


void usart_init(void); // Initilize Usart with setting mode , character size , baudrate , clock polarity , parity mode and stop bits for use (no input)

void usart_txc_interrupt(unsigned txc); // Enable or Disable Transmitt Complete Interrupt (txc=0 for disable & txc=1 for enable it)

void usart_rxc_interrupt(unsigned rxc); // Enable or Disable Receive Complete Interrupt (rxc=0 for disable & rxc=1 for enable it)

void usart_udre_interrupt(unsigned udre); // Enable or Disable Usart Data Register (UDR) Empty Interrupt (udre=0 for disable & udre=1 for enable it)

#if (USART_CHARSIZE == 9)
unsigned usart_read_bit9(void); // return ninth bit of UDR if character size was set to 9 (no input)

void usart_write_bit9(unsigned bit9); // set ninth bit of UDR if character size was set to 9 (bit9 = ninth bit of Usart Data)

void usart_mpcm(unsigned mpcm); // Enable or Disable MultiProcessorCommunicationMode (MPCM) if character size was set to 9 (mpcm=0 for disable & mpcm=1 for enable it)
#endif

void usart_tx_set(unsigned tx); // Enable or Disable Usart Transmitt (tx=0 for disable & tx=1 for enable)

void usart_rx_set(unsigned rx); // Enable or Disable Usart Receive (rx=0 for disable & rx=1 for enable)

unsigned usart_udr_empty_flag(void); // return true if UDR register is empty (no input)

unsigned usart_txc_flag(void); // return true if Transmittion is completed (no input)

unsigned usart_rxc_flag(void); // return true if Reception is completed (no input)

unsigned usart_pe_flag(void); // return true if any Parity Error happened (no input)

unsigned usart_dor_flag(void); // return true if any DataOverRun (DOR) Error happened (no input)

unsigned usart_fe_flag(void); // return true if any Frame Error happened (no input)

unsigned char usart_rx(void); // return Byte Received from Usart Port (ninth bit can be read with usart_read_bit9() if char size is 9) (no input)

void usart_rxs(char * str , unsigned char size); // Fill Pointed Array with Received Bytes in Specified number (* str is str[] && size is the number of Reception (max=ArraySize))

void usart_tx(unsigned char byte); // Transmitt one Byte with Usart (byte is the data that you want to send)

void usart_txs(char * str); // Transmitt All characters of str[] or Constant "Text" with Usart (* str is str['T','e','x','t'] or "Text")

#include "usart_as1x.c"

#endif

#ifdef USART_MODE_Asynchronous2X

#error This Mode its not available For now !

#if (F_CPU == 1000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 12
#endif
#endif
#if (F_CPU == 2000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 12
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 0
#endif
#endif
#if (F_CPU == 4000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 12
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 1
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 0
#endif
#endif
#if (F_CPU == 8000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 12
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 3
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 1
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 0
#endif
#endif
#if (F_CPU == 16000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 3
#define UBRR_L 64
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 0
#define UBRR_L 137
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 28800)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 7
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 3
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 1
#endif
#endif

#include <ali/Sources/usart/usart_as2x.c>

#endif

#ifdef USART_MODE_SynchronousMaster

#error This Mode its not available For now !

#if (F_CPU == 1000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 12
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 1
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 0
#endif
#endif
#if (F_CPU == 2000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 12
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 3
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 1
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 0
#endif
#endif
#if (F_CPU == 4000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 3
#define UBRR_L 64
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 0
#define UBRR_L 137
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 28800)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 25
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 7
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 3
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 1
#endif
#endif
#if (F_CPU == 8000000)
#if (USART_BAUDRATE == 2400)
#define UBRR_H 6
#define UBRR_L 129
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 3
#define UBRR_L 64
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 1
#define UBRR_L 20
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 28800)
#define UBRR_H 0
#define UBRR_L 137
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 57600)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 51
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 15
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 7
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 3
#endif
#endif
#if (F_CPU == 16000000)
#if   (USART_BAUDRATE == 2400)
#define UBRR_H 13
#define UBRR_L 4
#elif (USART_BAUDRATE == 4800)
#define UBRR_H 6
#define UBRR_L 129
#elif (USART_BAUDRATE == 9600)
#define UBRR_H 3
#define UBRR_L 64
#elif (USART_BAUDRATE == 14400)
#define UBRR_H 2
#define UBRR_L 42
#elif (USART_BAUDRATE == 19200)
#define UBRR_H 1
#define UBRR_L 159
#elif (USART_BAUDRATE == 28800)
#define UBRR_H 1
#define UBRR_L 20
#elif (USART_BAUDRATE == 38400)
#define UBRR_H 0
#define UBRR_L 207
#elif (USART_BAUDRATE == 57600)
#define UBRR_H 0
#define UBRR_L 137
#elif (USART_BAUDRATE == 76800)
#define UBRR_H 0
#define UBRR_L 103
#elif (USART_BAUDRATE == 115200)
#define UBRR_H 0
#define UBRR_L 68
#elif (USART_BAUDRATE == 250000)
#define UBRR_H 0
#define UBRR_L 31
#elif (USART_BAUDRATE == 500000)
#define UBRR_H 0
#define UBRR_L 15
#elif (USART_BAUDRATE == 1000000)
#define UBRR_H 0
#define UBRR_L 7
#endif
#endif

#include <ali/Sources/usart/usart_sm.c>

#endif

#ifdef USART_MODE_SynchronousSlave

#error This Mode its not available For now !

#include <ali/Sources/usart/usart_ss.c>

#endif



#endif