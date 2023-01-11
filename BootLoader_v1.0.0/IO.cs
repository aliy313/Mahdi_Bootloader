using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootLoader_v1._0._0
{
    public static class IO
    {
        public static string Configs_Read(in string FileName, in string ConfigName, out int Type, out bool Bool, out int Integer, out string String )
        {
            byte[] file = File.ReadAllBytes(FileName);
            int FileSize = file.Length;
            string Name = "";
            int ValueCount = 0;

            Type = 0;
            Bool = false;
            Integer = 0;
            String = "";

            for(int f = 0; f < FileSize; )
            {
                if (file[f] != '?') return "Record Start Its Not '?'";

                f++;

                Name = "";

                while ((file[f] != '=') && (f < FileSize -1))
                {
                    Name += (char)(file[f]);
                    f++;
                }

                

                if (file[f] != '=') return "Equal Sign '=' Not Found";

                f++;

                if(Name == ConfigName)
                {
                    if (file[f] == '^')
                    {
                        Type = 1;
                        f++;
                        if (file[f] == '+') Bool = true;
                        else if (file[f] == '-') Bool = false;
                        else return "There Is No Valid Boolean Sign '+'&'-' To Read";
                        f++;
                        if (file[f] != ';') return "End Of Record ';' Not Found";
                    }
                    else if (file[f] == '#')
                    {
                        Type = 2;
                        f++;
                        ValueCount = 0;
                        while ((file[f] != ';') && (f < FileSize -1) && (ValueCount < 10))
                        {
                            switch ((char)file[f])
                            {
                                case '0':
                                    Integer *= 10;
                                    Integer += 0;
                                    break;
                                case '1':
                                    Integer *= 10;
                                    Integer += 1;
                                    break;
                                case '2':
                                    Integer *= 10;
                                    Integer += 2;
                                    break;
                                case '3':
                                    Integer *= 10;
                                    Integer += 3;
                                    break;
                                case '4':
                                    Integer *= 10;
                                    Integer += 4;
                                    break;
                                case '5':
                                    Integer *= 10;
                                    Integer += 5;
                                    break;
                                case '6':
                                    Integer *= 10;
                                    Integer += 6;
                                    break;
                                case '7':
                                    Integer *= 10;
                                    Integer += 7;
                                    break;
                                case '8':
                                    Integer *= 10;
                                    Integer += 8;
                                    break;
                                case '9':
                                    Integer *= 10;
                                    Integer += 9;
                                    break;
                                default:
                                    ValueCount = -1;
                                    break;
                            }
                            if (ValueCount < 0) return "Invalid Digit Found (Only 0-9)";
                            f++;
                            ValueCount++;
                        }
                        if (file[f] != ';') return "End Of Record ';' Not Found";
                    }
                    else if (file[f] == '@')
                    {
                        Type = 3;
                        f++;
                        ValueCount = 0;
                        while ((file[f] != ';') && (f < FileSize -1) && (ValueCount < 50))
                        {
                            String += (char)file[f];
                            f++;
                            ValueCount++;
                        }
                        if (file[f] != ';') return "End Of Record ';' Not Found";
                    }
                    else return "Invalid Data Type Sign";

                    return "No Error";
                }

                else if(Name != ConfigName)
                {
                    while((file[f] != ';') && (f < FileSize -1))
                    {
                        f++;
                    }
                }

                f += 3;
            }

            return "No Error";

        }


        public static void Configs_Write(in string FileName, in string ConfigName, in int Type, in bool Bool, in int Integer, in string String)
        {
            string Config = "";

            Config += '?';

            Config += ConfigName;

            Config += '=';

            switch(Type)
            {
                case 1:
                    Config += '^';
                    if (Bool) Config += '+';
                    else Config += '-';
                    break;
                case 2:
                    Config += '#';
                    Config += Integer.ToString();
                    break;
                case 3:
                    Config += '@';
                    Config += String;
                    break;
                default:
                    throw new Exception("Invalid Type Input !");
            }

            Config += ';';

            Config += (char)13;

            Config += (char)10;

            File.AppendAllText(FileName, Config);
            //File.WriteAllText(FileName, Config);

            return;
        }


        public static void BytetoBoolArray(byte Byte, out bool[] Bool)
        {
            bool[] tmp = new bool[8];
            for (int a = 0; a < 8; a++)
            {
                tmp[a] = false;
            }
            if ((Byte & 0b00000001) == 0b00000001) tmp[0] = true;
            if ((Byte & 0b00000010) == 0b00000010) tmp[1] = true;
            if ((Byte & 0b00000100) == 0b00000100) tmp[2] = true;
            if ((Byte & 0b00001000) == 0b00001000) tmp[3] = true;
            if ((Byte & 0b00010000) == 0b00010000) tmp[4] = true;
            if ((Byte & 0b00100000) == 0b00100000) tmp[5] = true;
            if ((Byte & 0b01000000) == 0b01000000) tmp[6] = true;
            if ((Byte & 0b10000000) == 0b10000000) tmp[7] = true;

            Bool = tmp;

        }


        public static byte AsciiToByte(byte ch)
        {
            byte ret = 0;
            switch (ch)
            {
                case 48:
                    ret = 0;
                    break;
                case 49:
                    ret = 1;
                    break;
                case 50:
                    ret = 2;
                    break;
                case 51:
                    ret = 3;
                    break;
                case 52:
                    ret = 4;
                    break;
                case 53:
                    ret = 5;
                    break;
                case 54:
                    ret = 6;
                    break;
                case 55:
                    ret = 7;
                    break;
                case 56:
                    ret = 8;
                    break;
                case 57:
                    ret = 9;
                    break;
                case 65:
                    ret = 10;
                    break;
                case 66:
                    ret = 11;
                    break;
                case 67:
                    ret = 12;
                    break;
                case 68:
                    ret = 13;
                    break;
                case 69:
                    ret = 14;
                    break;
                case 70:
                    ret = 15;
                    break;
            }
            return ret;
        }


        public static byte ByteToAscii(byte b)
        {
            byte ret = 0;
            switch (b)
            {
                case 0:
                    ret = 48;
                    break;
                case 1:
                    ret = 49;
                    break;
                case 2:
                    ret = 50;
                    break;
                case 3:
                    ret = 51;
                    break;
                case 4:
                    ret = 52;
                    break;
                case 5:
                    ret = 53;
                    break;
                case 6:
                    ret = 54;
                    break;
                case 7:
                    ret = 55;
                    break;
                case 8:
                    ret = 56;
                    break;
                case 9:
                    ret = 57;
                    break;
                case 10:
                    ret = 65;
                    break;
                case 11:
                    ret = 66;
                    break;
                case 12:
                    ret = 67;
                    break;
                case 13:
                    ret = 68;
                    break;
                case 14:
                    ret = 69;
                    break;
                case 15:
                    ret = 70;
                    break;
            }
            return ret;
        }


        public static string HexToByteArray(in byte[] HexArr, ref byte[] ByteArr, out int CurrentRecord, out int EndOfFile)
        {
            byte[] Byte = new byte[ByteArr.Length];
            for (int a = 0; a < Byte.Length; a++)
            {
                Byte[a] = 0xFF;
            }
            long MaxPoint = ByteArr.Length;
            int Offset = 0;
            int BytePointer = 0;
            int RecordSize = 0;
            int CheckSum = 0;
            int CheckSumT = 0;
            int CheckSumM = 0;
            CurrentRecord = 1;
            EndOfFile = 0;
            int LastBytePoint = 0;
            byte[] EndChars = new byte[2];
            int EndCharCount = 0;

            if (HexArr[0] != ':') return "Record Start Sign Its Not ':' In Record " + CurrentRecord.ToString();
            RecordSize = AsciiToByte(HexArr[1]) * 16;
            RecordSize += AsciiToByte(HexArr[2]);
            if (HexArr[11 + (RecordSize * 2)] != ':')
            {
                EndChars[0] = HexArr[11 + (RecordSize * 2)];
                EndCharCount++;
            }
            if (HexArr[12 + (RecordSize * 2)] != ':')
            {
                EndChars[1] = HexArr[12 + (RecordSize * 2)];
                EndCharCount++;
            }


            for (int i = 0; i < HexArr.Length;)
            {
                if (HexArr[i] != ':') return "Record Start Sign Its Not ':' In Record " + CurrentRecord.ToString();

                i++;
                RecordSize = AsciiToByte(HexArr[i]) * 16;
                i++;
                RecordSize += AsciiToByte(HexArr[i]);
                i++;
                if (RecordSize > 255) return "Record Size Its Not Valid In Record " + CurrentRecord.ToString();
                CheckSum = RecordSize;

                Offset = AsciiToByte(HexArr[i]) * 4096;
                CheckSum += AsciiToByte(HexArr[i]) * 16;
                i++;
                Offset += AsciiToByte(HexArr[i]) * 256;
                CheckSum += AsciiToByte(HexArr[i]);
                i++;
                Offset += AsciiToByte(HexArr[i]) * 16;
                CheckSum += AsciiToByte(HexArr[i]) * 16;
                i++;
                Offset += AsciiToByte(HexArr[i]);
                CheckSum += AsciiToByte(HexArr[i]);
                i++;
                if ((Offset + RecordSize) >= MaxPoint) return "Hex Address Overflow In Record : " + CurrentRecord.ToString();
                else BytePointer = Offset;
                if ((Offset + RecordSize - 1) > LastBytePoint) LastBytePoint = Offset + RecordSize - 1;

                if (HexArr[i] != '0') return "Record Type First Char Must Be '0' (Record " + CurrentRecord.ToString() + ")";
                i++;
                if (HexArr[i] == '1')
                {
                    if (RecordSize != 0) return "Record Size In Last Record Must Be 0 (Record " + CurrentRecord.ToString() + ")";
                    i++;
                    if (HexArr[i] != 'F') return "End Record CheckSum Error : Must Be FF (Record " + CurrentRecord.ToString() + ")";
                    i++;
                    if (HexArr[i] != 'F') return "End Record CheckSum Error : Must Be FF (Record " + CurrentRecord.ToString() + ")";
                    if (EndCharCount > 0)
                    {
                        i++;
                        if (HexArr[i] != EndChars[0]) return "End Character Must Be Ascii " + Convert.ToInt32(EndChars[0]).ToString() + " Not " + Convert.ToInt32(HexArr[i]).ToString() + " (Record " + CurrentRecord.ToString() + ")";
                    }
                    if (EndCharCount > 1)
                    {
                        i++;
                        if (HexArr[i] != EndChars[1]) return "End Character Must Be Ascii " + Convert.ToInt32(EndChars[1]).ToString() + " Not " + Convert.ToInt32(HexArr[i]).ToString() + " (Record " + CurrentRecord.ToString() + ")";
                    }
                    EndOfFile = LastBytePoint;
                    break;
                }
                else if (HexArr[i] != '0') return "Record Type Second Char Must Be '0' Or '1' (Record " + CurrentRecord.ToString() + ")";
                i++;
                for (int j = 0; j < RecordSize; j++)
                {
                    Byte[BytePointer] = (byte)(AsciiToByte(HexArr[i]) * 16);
                    i++;
                    Byte[BytePointer] += (byte)(AsciiToByte(HexArr[i]));
                    CheckSum += Byte[BytePointer];
                    BytePointer++;
                    i++;
                }
                CheckSumM = (AsciiToByte(HexArr[i]) * 16);
                i++;
                CheckSumM += AsciiToByte(HexArr[i]);
                i++;
                CheckSumT = ((~CheckSum) & 0xFF) + 1;
                if (CheckSumM != CheckSumT) return "CheckSum Error In Record " + CurrentRecord.ToString();

                CurrentRecord++;

                if (EndCharCount > 0)
                {
                    if (HexArr[i] != EndChars[0]) return "End Character Must Be Ascii " + Convert.ToInt32(EndChars[0]).ToString() + " Not " + Convert.ToInt32(HexArr[i]).ToString() + " (Record " + CurrentRecord.ToString() + ")";
                    i++;
                }
                if (EndCharCount > 1)
                {
                    if (HexArr[i] != EndChars[1]) return "End Character Must Be Ascii " + Convert.ToInt32(EndChars[1]).ToString() + " Not " + Convert.ToInt32(HexArr[i]).ToString() + " (Record " + CurrentRecord.ToString() + ")";
                    i++;
                }
            }
            ByteArr = Byte;
            return "No Error";
        }


        public static void ByteArrayToHex(byte[] Bytes, out byte[] HexArr, int RecordSize = 16, int StartAddress = 0)
        {
            int HexPointer = 0;
            int CurrentAddress = StartAddress;
            int RemainTemp = 0;
            int CheckSumT = 0;
            int CheckSumF = 0;
            int BytePointer = 0;
            int RecSize = 0;

            //int BytesTrueSize = 0;
            //while (BytesTrueSize < (Bytes.Length -1))
            //{
            //    if ((Bytes[BytesTrueSize] == 0xFF) && (Bytes[BytesTrueSize + 1] == 0xFF)) break;
            //    BytesTrueSize += 2;
            //}

            int BytesTrueSize = Bytes.Length;
            while (BytesTrueSize > 0)
            {
                BytesTrueSize -= 2;
                if ((Bytes[BytesTrueSize] != 0xFF) || (Bytes[BytesTrueSize + 1] != 0xFF))
                {
                    BytesTrueSize += 2;
                    break;
                }
            }

            Array.Resize(ref Bytes, BytesTrueSize);

            int HexSizeEs = (BytesTrueSize / RecordSize) + 1;
            HexSizeEs *= ((RecordSize * 2) + 13);
            HexSizeEs += 13;
            HexArr = new byte[HexSizeEs];

            while (BytePointer < Bytes.Length)
            {
                if (((Bytes.Length - BytePointer) / RecordSize) >= 1) RecSize = RecordSize;
                else RecSize = (Bytes.Length - BytePointer);

                CheckSumT = RecSize;

                HexArr[HexPointer++] = (byte)':';

                HexArr[HexPointer++] = ByteToAscii((byte)(RecSize / 16));
                HexArr[HexPointer++] = ByteToAscii((byte)(RecSize % 16));

                HexArr[HexPointer++] = ByteToAscii((byte)(CurrentAddress / 4096));
                RemainTemp = CurrentAddress % 4096;
                HexArr[HexPointer++] = ByteToAscii((byte)(RemainTemp / 256));
                RemainTemp %= 256;
                HexArr[HexPointer++] = ByteToAscii((byte)(RemainTemp / 16));
                RemainTemp %= 16;
                HexArr[HexPointer++] = ByteToAscii((byte)RemainTemp);
                CheckSumT += CurrentAddress / 256;
                CheckSumT += CurrentAddress % 256;
                CurrentAddress += RecSize;

                HexArr[HexPointer++] = (byte)'0';
                HexArr[HexPointer++] = (byte)'0';

                for (int r = 0; r < RecSize; r++)
                {
                    HexArr[HexPointer++] = ByteToAscii((byte)(Bytes[BytePointer] / 16));
                    HexArr[HexPointer++] = ByteToAscii((byte)(Bytes[BytePointer] % 16));
                    CheckSumT += Bytes[BytePointer];
                    BytePointer++;
                }

                CheckSumF = (0xFF - (CheckSumT & 0xFF)) + 1;
                if (CheckSumF > 0xFF) CheckSumF = 0;
                HexArr[HexPointer++] = ByteToAscii((byte)(CheckSumF / 16));
                HexArr[HexPointer++] = ByteToAscii((byte)(CheckSumF % 16));

                HexArr[HexPointer++] = 13;
                HexArr[HexPointer++] = 10;
            }

            HexArr[HexPointer++] = (byte)':';
            for(int n = 0; n < 7; n++)
            {
                HexArr[HexPointer++] = (byte)'0';
            }
            HexArr[HexPointer++] = (byte)'1';
            HexArr[HexPointer++] = (byte)'F';
            HexArr[HexPointer++] = (byte)'F';
            HexArr[HexPointer++] = 13;
            HexArr[HexPointer] = 10;


            Array.Resize(ref HexArr, HexPointer + 1);

        }


        public static void ByteArrayToMhd(in byte[] ByteArr, out byte[] MhdArr, bool Ignore0xFF)
        {
            int ByteSize = ByteArr.Length;
            int Address = 0;
            int Value = 0;
            int MhdPointer = 0;
            int MaxAdrPow = 0;
            bool ZiroIgnore = true;

            for (int p = 0; p < 8; p++)
            {
                if (Math.Pow(10, p) <= ByteSize) continue;
                else
                {
                    MaxAdrPow = p;
                    break;
                }
            }

            int MhdSizeEs = ((MaxAdrPow + 8) * ByteSize);

            MhdArr = new byte[MhdSizeEs];



            for (int c = 0; c < ByteSize; c++)
            {
                if ((ByteArr[c] == 0xFF) && Ignore0xFF) continue;
                MhdArr[MhdPointer++] = (byte)'&';
                Address = c;
                Value = ByteArr[c];

                ZiroIgnore = true;

                for (int a = MaxAdrPow; a >= 0; a--)
                {
                    if ((((int)(Address / Math.Pow(10, a))) == 0) && ZiroIgnore && (a != 0)) continue;
                    ZiroIgnore = false;
                    MhdArr[MhdPointer++] = ByteToAscii((byte)(Address / Math.Pow(10, a)));
                    Address %= ((int)(Math.Pow(10, a)));
                }

                MhdArr[MhdPointer++] = (byte)'=';

                ZiroIgnore = true;

                for (int v = 2; v >= 0; v--)
                {
                    if ((((int)(Value / Math.Pow(10, v))) == 0) && ZiroIgnore && (v != 0)) continue;
                    ZiroIgnore = false;
                    MhdArr[MhdPointer++] = ByteToAscii((byte)(Value / Math.Pow(10, v)));
                    Value %= ((int)(Math.Pow(10, v)));
                }

                MhdArr[MhdPointer++] = (byte)';';
                MhdArr[MhdPointer++] = 13;
                MhdArr[MhdPointer++] = 10;
            }
            Array.Resize(ref MhdArr, MhdPointer);
        }


        public static string MhdToByteArray(in byte[] MhdArr, ref byte[] ByteArr)
        {
            int Address = 0;
            byte Value = 0;
            int MhdSize = MhdArr.Length;
            int ByteSize = ByteArr.Length;

            for (int c = 0; c < ByteSize; c++)
            {
                ByteArr[c] = 0xFF;
            }

            for (int c = 0; c < MhdSize;)
            {
                Address = 0;
                Value = 0;

                while (MhdArr[c] != '&')
                {
                    c++;
                    if (c >= MhdSize) return "No Error";
                }

                c++;
                if (c >= MhdSize) return "Address Missing";

                if (MhdArr[c] != 'x')
                {
                    while (MhdArr[c] != '=')
                    {
                        Address *= 10;
                        Address += AsciiToByte(MhdArr[c]);
                        c++;
                        if (c >= MhdSize) return "'=' Sign Missing";
                        if (Address >= ByteSize) return "Address Is Bigger Than E2prom Size";
                    }
                }
                else if (MhdArr[c] == 'x')
                {
                    c++;
                    if (c >= MhdSize) return "Address Missing";
                    while (MhdArr[c] != '=')
                    {
                        Address *= 16;
                        Address += AsciiToByte(MhdArr[c]);
                        c++;
                        if (c >= MhdSize) return "'=' Sign Missing";
                        if (Address >= ByteSize) return "Address Is Bigger Than E2prom Size";
                    }
                }

                c++;
                if (c >= MhdSize) return "Value Missing";

                if (MhdArr[c] != 'x')
                {
                    while (MhdArr[c] != ';')
                    {
                        Value *= 10;
                        Value += AsciiToByte(MhdArr[c]);
                        c++;
                        if (c >= MhdSize) return "';' Sign Missing";
                        if (Value > 0xFF) return "Value Must Be 0-255 Or 0x00-0xFF";
                    }
                }
                else if (MhdArr[c] == 'x')
                {
                    c++;
                    if (c >= MhdSize) return "Value Missing";
                    while (MhdArr[c] != ';')
                    {
                        Value *= 16;
                        Value += AsciiToByte(MhdArr[c]);
                        c++;
                        if (c >= MhdSize) return "';' Sign Missing";
                        if (Value > 0xFF) return "Value Must Be 0-255 Or 0x00-0xFF";
                    }
                }

                ByteArr[Address] = Value;

            }

            return "No Error";
        }


        public static void ArrayToPages(byte[] inArray, ref byte[,] Pages, int PageNumber, int PageSize)
        {
            for (int p = 0; p < PageNumber; p++)
            {
                for (int b = 0; b < PageSize; b++)
                {
                    Pages[p, b] = 0x85;
                }
            }

            int BytePointer = 0;
            for (int p = 0; p < PageNumber; p++)
            {
                for (int b = 0; b < PageSize; b++)
                {
                    Pages[p, b] = inArray[BytePointer];
                    BytePointer++;

                }
            }
        }












    }
}
