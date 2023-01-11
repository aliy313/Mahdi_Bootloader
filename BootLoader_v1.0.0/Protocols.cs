using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootLoader_v1._0._0
{
    internal class Protocols
    {

        // Global  (0-29)  ********************************************************************//

        public const byte Unknown = 0;
        public const byte Error = 1;
        public const byte Pass = 2;
        public const byte Free_Req = 3;
        public const byte Free_Req_Back = 4;
        public const byte Reset_App = 5;
        public const byte Sleep = 6;
        public const byte App_Loaded = 7;
        public const byte Boot_Loaded = 8;
        public const byte Sleep_Entered = 9;
        public const byte Unknown_Command = 10;

        // Connect  (30-59)  ******************************************************************//

        public const byte Connect_Req = 30;
        public const byte Connect_Req_Back = 31;
        public const byte Connect_Continue_1 = 32;
        public const byte Connect_Continue_2 = 33;
        public const byte PageNumber_H_Pass = 34;
        public const byte PageNumber_H_Not_Pass = 35;
        public const byte PageNumber_L_Pass = 36;
        public const byte PageNumber_L_Not_Pass = 37;
        public const byte PageSize_H_Pass = 38;
        public const byte PageSize_H_Not_Pass = 39;
        public const byte PageSize_L_Pass = 40;
        public const byte PageSize_L_Not_Pass = 41;
        public const byte BuildNumber_Pass = 42;
        public const byte BuildNumber_Not_Pass = 43;

        // FuseBits Read  (60-79)  ************************************************************//

        public const byte FuseBits_Read_Req = 60;
        public const byte FuseBits_Read_Req_Back = 61;
        public const byte FuseBits_Read_Pass = 62;
        public const byte FuseBits_Read_Not_Pass = 63;
        public const byte FuseBits_Read_Continue_1 = 64;

        // LockBits Read  (80-99)  ************************************************************//

        public const byte LockBits_Read_Req = 80;
        public const byte LockBits_Read_Req_Back = 81;
        public const byte LockBits_Read_Pass = 82;
        public const byte LockBits_Read_Not_Pass = 83;
        public const byte LockBits_Read_Continue_1 = 84;

        // LockBits Write  (100-119)  *********************************************************//

        public const byte LockBits_Write_Req = 100;
        public const byte LockBits_Write_Req_Back = 101;
        public const byte LockBits_Write_Pass_1 = 102;
        public const byte LockBits_Write_Not_Pass_1 = 103;

        // FlashPage Write  (120-149)  ********************************************************//

        public const byte FlashPage_Write_Req = 120;
        public const byte FlashPage_Write_Req_Back = 121;
        public const byte FlashPage_Write_Continue_1 = 122;
        public const byte FlashPage_Write_InvalidPage = 123;
        public const byte FlashPage_Write_ValidPage = 124;
        public const byte FlashPage_Write_Continue_2 = 125;
        public const byte FlashPage_Write_NextByte = 126;
        public const byte FlashPage_Write_TryByte = 127;
        public const byte FlashPage_Write_TryByte_Req = 128;
        public const byte FlashPage_Write_NextByte_Req = 129;
        public const byte FlashPage_Write_Wait_Req = 130;
        public const byte FlashPage_Write_Done = 131;
        public const byte FlashPage_Write_NextByte_Req_Back = 132;
        public const byte FlashPage_Write_TryByte_Req_Back = 133;
        public const byte FlashPage_Write_Wait_Req_Back = 134;
        public const byte FlashPage_Erase_Operation = 135;
        public const byte FlashPage_Write_Operation = 136;
        public const byte FlashPage_Erase_Operation_Done = 137;
        public const byte FlashPage_Write_Page_Pass = 138;
        public const byte FlashPage_Write_Page_Not_Pass = 139;

        // FlashPage Read  (150-179)  *********************************************************//

        public const byte FlashPage_Read_Req = 150;
        public const byte FlashPage_Read_Req_Back = 151;
        public const byte FlashPage_Read_Continue_1 = 152;
        public const byte FlashPage_Read_Page_Pass = 153;
        public const byte FlashPage_Read_InvalidPage = 154;
        public const byte FlashPage_Read_ValidPage = 155;
        public const byte FlashPage_Read_TryByte = 156;
        public const byte FlashPage_Read_TryByte_Req = 157;
        public const byte FlashPage_Read_NextByte = 158;
        public const byte FlashPage_Read_NextByte_Req = 159;
        public const byte FlashPage_Read_Done = 160;
        public const byte FlashPage_Read_Page_Not_Pass = 161;

        // EEPROM Read  (180-209)  ************************************************************//

        public const byte E2prom_Read_Req = 180;
        public const byte E2prom_Read_Req_Back = 181;
        public const byte E2prom_Read_Continue_1 = 182;
        public const byte E2prom_Read_Address_Pass = 183;
        public const byte E2prom_Read_Address_Not_Pass = 184;
        public const byte E2prom_Read_InvalidAddress = 185;
        public const byte E2prom_Read_ValidAddress = 186;
        public const byte E2prom_Read_ValidByte = 187;
        public const byte E2prom_Read_InvalidByte = 188;
        public const byte E2prom_Read_Done = 189;
        public const byte E2promSize_H_Pass = 190;
        public const byte E2promSize_H_Not_Pass = 191;
        public const byte E2promSize_L_Pass = 192;
        public const byte E2promSize_L_Not_Pass = 193;

        // EEPROM Write  (210-239)  ***********************************************************//

        public const byte E2prom_Write_Req = 210;
        public const byte E2prom_Write_Req_Back = 211;
        public const byte E2prom_Write_Continue_1 = 212;
        public const byte E2prom_Write_Address_Pass = 213;
        public const byte E2prom_Write_InvalidAddress = 214;
        public const byte E2prom_Write_ValidAddress = 215;
        public const byte E2prom_Write_ValidByte = 216;
        public const byte E2prom_Write_InvalidByte = 217;
        public const byte E2prom_Write_Done_Req = 218;
        public const byte E2prom_Write_Error = 219;
        public const byte E2prom_Write_Done_Req_Back = 220;
        public const byte E2prom_Write_Address_Not_Pass = 221;
        public const byte E2prom_Write_Continue_2 = 222;

        // Reserved  (240-255)  ***************************************************************//


    }
}
