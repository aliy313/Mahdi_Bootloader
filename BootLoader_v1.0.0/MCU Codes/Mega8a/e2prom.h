/*
Internal EEPROM Library
Version = 1.1.0
Written by Unknown_313
*/



#ifndef __E2PROM_H__
#define __E2PROM_H__

#ifndef INTERRUPT_OFF
#ifndef INTERRUPT_ON
#error define interrupt status First (ex : define INTERRUPT_OFF | INTERRUPT_ON)
#endif
#endif

#ifdef INTERRUPT_ON
#include <avr/interrupt.h>
#endif



unsigned char e2prom_byte_read(unsigned int address); // Return unsigned char from specified Address of eeprom (address = Specified Address in 16bit format)

unsigned e2prom_byte_write(unsigned int address , unsigned char data , unsigned verify); // Write unsigned char on specified Address of eeprom and return true if (verify==1) and written data is verified Successfully or return false for Error (address : Specified Address in 16bit format && data : unsigned char data to write && verify=1 to verify written data & verify=0 to not verify and return 1 anyway)

unsigned int e2prom_word_read(unsigned int address); // Return unsigned int from specified Address of eeprom (address = Specified Address in 16bit format)

unsigned e2prom_word_write(unsigned int address , unsigned int data , unsigned verify); // Write unsigned int on specified Address of eeprom and return true if (verify==1) and written data is verified Successfully or return false for Error (address : Specified Address in 16bit format && data : unsigned int data to write && verify=1 to verify written data & verify=0 to not verify and return 1 anyway)

unsigned long int e2prom_dword_read(unsigned int address); // Return unsigned long int from specified Address of eeprom (address = Specified Address in 16bit format)

unsigned e2prom_dword_write(unsigned int address , unsigned long int data , unsigned verify); // Write unsigned long int on specified Address of eeprom and return true if (verify==1) and written data is verified Successfully or return false for Error (address : Specified Address in 16bit format && data : unsigned long int data to write && verify=1 to verify written data & verify=0 to not verify and return 1 anyway)

#include "e2prom.c"

#endif