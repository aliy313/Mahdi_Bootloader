/*
BootLoader Library (Mega32)
Version = 1.2.0
Written by Unknown_313
*/


#ifndef __BOOT_H__
#define __BOOT_H__


void boot_page_read(unsigned char _page_number); // Fill page_buffer[128] with Flash Page values . Data Order is High Word First (_page_number : Address number of Specified Page to Fill page_buffer[128] with its value)

void boot_page_erase(unsigned char _page_number); // Erase Specified Flash Page (Reset to 0xFF) (_page_number : Address number of Specified Page to Erase)

void boot_page_write(unsigned char _page_number); // Write page_buffer[128] values to Specified Flash Page . Data Order is High Word First (_page_number : Address number of Specified Page to Write on it)

unsigned char boot_fusebits_read(unsigned low0_high1); // Return Low or High FuseBits value (low0_high1=0 to return low byte fuse bits & low0_high1=1 to return high byte fuse bits)

void boot_lockbits_write(unsigned char lockvalue); // Change LockBits to Higher Secure Values (lockvalue : LockBits values to write)

unsigned char boot_lockbits_read(void); // Return LockBits values (no input)

#include "boot.c"

#endif