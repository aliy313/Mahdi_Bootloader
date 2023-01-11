#ifndef __PROTOCOLS_H__
#define __PROTOCOLS_H__





// Global  (0-29)  ********************************************************************//

#define Unknown                               0
#define Error                                 1
#define Pass                                  2
#define Free_Req                              3
#define Free_Req_Back                         4
#define Reset_App                             5
#define Sleep                                 6
#define App_Loaded                            7
#define Boot_Loaded                           8
#define Sleep_Entered                         9
#define Unknown_Command                       10

// Connect  (30-59)  ******************************************************************//

#define Connect_Req                           30
#define Connect_Req_Back                      31
#define Connect_Continue_1                    32
#define Connect_Continue_2                    33
#define PageNumber_H_Pass                     34
#define PageNumber_H_Not_Pass                 35
#define PageNumber_L_Pass                     36
#define PageNumber_L_Not_Pass                 37
#define PageSize_H_Pass                       38
#define PageSize_H_Not_Pass                   39
#define PageSize_L_Pass                       40
#define PageSize_L_Not_Pass                   41
#define BuildNumber_Pass                      42
#define BuildNumber_Not_Pass                  43

// FuseBits Read  (60-79)  ************************************************************//

#define FuseBits_Read_Req                     60
#define FuseBits_Read_Req_Back                61
#define FuseBits_Read_Pass                    62
#define FuseBits_Read_Not_Pass                63
#define FuseBits_Read_Continue_1              64

// LockBits Read  (80-99)  ************************************************************//

#define LockBits_Read_Req                     80
#define LockBits_Read_Req_Back                81
#define LockBits_Read_Pass                    82
#define LockBits_Read_Not_Pass                83
#define LockBits_Read_Continue_1              84

// LockBits Write  (100-119)  *********************************************************//

#define LockBits_Write_Req                    100
#define LockBits_Write_Req_Back               101
#define LockBits_Write_Pass_1                 102
#define LockBits_Write_Not_Pass_1             103

// FlashPage Write  (120-149)  ********************************************************//

#define FlashPage_Write_Req                   120
#define FlashPage_Write_Req_Back              121
#define FlashPage_Write_Continue_1            122
#define FlashPage_Write_InvalidPage           123
#define FlashPage_Write_ValidPage             124
#define FlashPage_Write_Continue_2            125
#define FlashPage_Write_NextByte              126
#define FlashPage_Write_TryByte               127
#define FlashPage_Write_TryByte_Req           128
#define FlashPage_Write_NextByte_Req          129
#define FlashPage_Write_Wait_Req              130
#define FlashPage_Write_Done                  131
#define FlashPage_Write_NextByte_Req_Back     132
#define FlashPage_Write_TryByte_Req_Back      133
#define FlashPage_Write_Wait_Req_Back         134
#define FlashPage_Erase_Operation             135
#define FlashPage_Write_Operation             136
#define FlashPage_Erase_Operation_Done        137
#define FlashPage_Write_Page_Pass             138
#define FlashPage_Write_Page_Not_Pass         139

// FlashPage Read  (150-179)  *********************************************************//

#define FlashPage_Read_Req                    150
#define FlashPage_Read_Req_Back               151
#define FlashPage_Read_Continue_1             152
#define FlashPage_Read_Page_Pass              153
#define FlashPage_Read_InvalidPage            154
#define FlashPage_Read_ValidPage              155
#define FlashPage_Read_TryByte                156
#define FlashPage_Read_TryByte_Req            157
#define FlashPage_Read_NextByte               158
#define FlashPage_Read_NextByte_Req           159
#define FlashPage_Read_Done                   160
#define FlashPage_Read_Page_Not_Pass          161

// EEPROM Read  (180-209)  ************************************************************//

#define E2prom_Read_Req                       180
#define E2prom_Read_Req_Back                  181
#define E2prom_Read_Continue_1                182
#define E2prom_Read_Address_Pass              183
#define E2prom_Read_Address_Not_Pass          184
#define E2prom_Read_InvalidAddress            185
#define E2prom_Read_ValidAddress              186
#define E2prom_Read_ValidByte                 187
#define E2prom_Read_InvalidByte               188
#define E2prom_Read_Done                      189
#define E2promSize_H_Pass                     190
#define E2promSize_H_Not_Pass                 191
#define E2promSize_L_Pass                     192
#define E2promSize_L_Not_Pass                 193

// EEPROM Write  (210-239)  ***********************************************************//

#define E2prom_Write_Req                      210
#define E2prom_Write_Req_Back                 211
#define E2prom_Write_Continue_1               212
#define E2prom_Write_Address_Pass             213
#define E2prom_Write_InvalidAddress           214
#define E2prom_Write_ValidAddress             215
#define E2prom_Write_ValidByte                216
#define E2prom_Write_InvalidByte              217
#define E2prom_Write_Done_Req                 218
#define E2prom_Write_Error                    219
#define E2prom_Write_Done_Req_Back            220
#define E2prom_Write_Address_Not_Pass         221
#define E2prom_Write_Continue_2               222

// Reserved  (240-255)  ***************************************************************//





#endif