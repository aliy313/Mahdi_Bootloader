using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using Microsoft.VisualBasic.Logging;
using System.Runtime.ConstrainedExecution;

namespace BootLoader_v1._0._0
{
    public partial class MainPage : Form
    {
        public bool is_MCU_identified = false;
        public int PageNumber;
        public int PageSize;
        public int E2promSize;
        public const byte BuildNumber = 12;
        const string Version = "1.1.0";
        public int LogLine = 0;
        public const string ConfigPath = "Configs.cfg";

        SerialPort com = new SerialPort();

        //***************************************************************************************************************//

        public bool Setting()
        {
            if (SerialPort.GetPortNames().Length == 0)
            {
                Log("No COM Port Available to Open !",0);
                return false;
            }
            switch (cmb_port.SelectedIndex)
            {
                case 0:
                    com.PortName = SerialPort.GetPortNames()[0];
                    break;
                case 1:
                    if(SerialPort.GetPortNames().Length > 1)
                    {
                        com.PortName = SerialPort.GetPortNames()[1];
                    }
                    else
                    {
                        Log("There Is No Second Port ! Connect To First Port Instead...", 0);
                        com.PortName = SerialPort.GetPortNames()[0];
                    }
                    break;
                case 2:
                    if (SerialPort.GetPortNames().Length > 2)
                    {
                        com.PortName = SerialPort.GetPortNames()[2];
                    }
                    else if (SerialPort.GetPortNames().Length > 1)
                    {
                        Log("There Is No Third Port ! Connect To Second Port Instead...", 0);
                        com.PortName = SerialPort.GetPortNames()[1];
                    }
                    else
                    {
                        Log("There Is No Third Or Second Port ! Connect To First Port Instead...", 0);
                        com.PortName = SerialPort.GetPortNames()[0];
                    }
                    break;
                case 3:
                    com.PortName = "COM1";
                    break;
                case 4:
                    com.PortName = "COM2";
                    break;
                case 5:
                    com.PortName = "COM3";
                    break;
                case 6:
                    com.PortName = "COM4";
                    break;
                case 7:
                    com.PortName = "COM5";
                    break;
                case 8:
                    com.PortName = "COM6";
                    break;
                case 9:
                    com.PortName = "COM7";
                    break;
                case 10:
                    com.PortName = "COM8";
                    break;
                case 11:
                    com.PortName = "COM9";
                    break;
                case 12:
                    com.PortName = "COM10";
                    break;
            }
            Log("Set PortName To : " + com.PortName.ToString(), 2);
            com.BaudRate = Convert.ToInt32(cmb_baudrate.Text);
            Log("Set BaudRate To : " + com.BaudRate.ToString(), 2);
            com.DataBits = 8;
            Log("Set DataBits To : 8", 2);
            switch (cmb_parity.SelectedIndex)
            {
                case 0:
                    com.Parity = System.IO.Ports.Parity.None;
                    break;
                case 1:
                    com.Parity = System.IO.Ports.Parity.Even;
                    break;
                case 2:
                    com.Parity = System.IO.Ports.Parity.Odd;
                    break;
            }
            Log("Set Parity To : " + com.Parity.ToString(), 2);

            switch (cmb_stopbits.SelectedIndex)
            {
                case 0:
                    com.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 1:
                    com.StopBits = System.IO.Ports.StopBits.Two;
                    break;
            }
            Log("Set StopBits To : " + com.StopBits.ToString(), 2);

            com.Handshake = Handshake.None;
            Log("Set HandShake To : " + com.Handshake.ToString(), 2);

            switch (cmb_timeout.SelectedIndex)
            {
                case 0:
                    com.WriteTimeout = 50;
                    com.ReadTimeout = 50;
                    break;
                case 1:
                    com.WriteTimeout = 100;
                    com.ReadTimeout = 100;
                    break;
                case 2:
                    com.WriteTimeout = 500;
                    com.ReadTimeout = 500;
                    break;
                case 3:
                    com.WriteTimeout = 1000;
                    com.ReadTimeout = 1000;
                    break;
                case 4:
                    com.WriteTimeout = 2000;
                    com.ReadTimeout = 2000;
                    break;
                case 5:
                    com.WriteTimeout = 5000;
                    com.ReadTimeout = 5000;
                    break;
                case 6:
                    com.WriteTimeout = 10000;
                    com.ReadTimeout = 10000;
                    break;
            }
            Log("Set Read Timeout To : " + com.ReadTimeout.ToString(), 2);
            Log("Set Write Timeout To : " + com.WriteTimeout.ToString(), 2);

            return true;
        }


        public bool Start()
        {
            try
            {
                Log("Try To Open Port : " + com.PortName.ToString(),1);
                com.Open();
            }
            catch (Exception Ex)
            {
                com.Close();
                Log(Ex.Message,0);
            }
            if (com.IsOpen)
            {
                lbl_com.Text = com.PortName;
                Log("Port " + com.PortName.ToString() + " Opened",2);
                return true;
            }
            else
            {
                Log("Error Opening Port : " + com.PortName,1);
                return false;
            }
        }


        public void WriteByte(byte Byte)
        {
            byte[] ByteArr = new byte[1];
            ByteArr[0] = Byte;
            try
            {
                Log("Try To Send Byte ...", 3);
                com.Write(ByteArr, 0, 1);
            }
            catch(Exception E)
            {
                Log("Error : " + E.Message,0);
            }
        }


        public bool FreeCheck()
        {
            Log("Send Free Check Request", 3);
            WriteByte(Protocols.Free_Req);
            if(com.ReadByte() == Protocols.Free_Req_Back)
            {
                Log("Chip Is Free", 3);
                return true;
            }
            else
            {
                Log("Chip Is Not Free !",0);
                return false;
            }
        }


        public int Identify(out string mcu)
        {
            mcu = "Error";
            com.DiscardInBuffer();
            bool Connected = false;
            int tmp;

            Log("Wait for MCU to Boot", 0);

            for(int w = 0; w < 50; w++)
            {
                if(com.BytesToRead != 0)
                {
                    tmp = com.ReadByte();
                    if (tmp != Protocols.Boot_Loaded)
                    {
                        Log("Unknown Code Received", 0);
                        Log("Unknown Code Received : " + tmp.ToString() + " != " + Protocols.Boot_Loaded.ToString(), 1);
                        return 1;
                    }
                    Connected = true;
                    Log("Received BootLoaded Code : " + tmp.ToString(), 2);
                    break;
                }
                Thread.Sleep(100);
            }

            if(!Connected)
            {
                Log("Connection TimedOut", 0);
                return 2;
            }

            Log("Connected", 0);

            Log("Send Connection Request ...", 2);
            WriteByte(Protocols.Connect_Req);

            tmp = com.ReadByte();
            if (tmp != Protocols.Connect_Req_Back)
            {
                WriteByte(Protocols.Error);
                Log("Connection Request Back Error : " + tmp.ToString() + " != " + Protocols.Connect_Req_Back, 1);
                return 2;
            }
            Log("Connection Request Received",2);

            Log("Send Connect_Continue_1 ...", 2);
            WriteByte(Protocols.Connect_Continue_1);

            com.NewLine = " ";
            mcu = com.ReadLine();
            Log("MCU Model : " + mcu,0);

            Log("Send Connect_Continue_2 ...", 2);
            WriteByte(Protocols.Connect_Continue_2);

            byte PageNumberH = (byte)com.ReadByte();
            Log("Received " + PageNumberH.ToString() + " As PageNumberH", 1);
            byte PageNumberL = (byte)com.ReadByte();
            Log("Received " + PageNumberL.ToString() + " As PageNumberL", 1);
            byte PageSizeH = (byte)com.ReadByte();
            Log("Received " + PageSizeH.ToString() + " As PageSizeH", 1);
            byte PageSizeL = (byte)com.ReadByte();
            Log("Received " + PageSizeL.ToString() + " As PageSizeL", 1);
            byte E2promSizeH = (byte)com.ReadByte();
            Log("Received " + E2promSizeH.ToString() + " As E2promSizeH", 1);
            byte E2promSizeL = (byte)com.ReadByte();
            Log("Received " + E2promSizeL.ToString() + " As E2promSizeL", 1);
            byte MCU_BuildNumber = (byte)com.ReadByte();
            Log("Received " + MCU_BuildNumber.ToString() + " As MCU_BuildNumber", 1);

            Log("Send PageNumberH ...", 2);
            WriteByte(PageNumberH);
            tmp = com.ReadByte();
            if (tmp != Protocols.PageNumber_H_Pass)
            {
                Log("Error Receive PageNumber_H_Pass : " + tmp.ToString() + " != " + Protocols.PageNumber_H_Pass.ToString(), 1);
                return 3;
            }
            Log("PageNumber_H_Pass Received",2);

            Log("Send PageNumberL ...", 2);
            WriteByte(PageNumberL);
            tmp = com.ReadByte();
            if (tmp != Protocols.PageNumber_L_Pass)
            {
                Log("Error Receive PageNumber_L_Pass : " + tmp.ToString() + " != " + Protocols.PageNumber_L_Pass.ToString(), 1);
                return 4;
            }
            Log("PageNumber_L_Pass Received", 2);

            Log("Send PageSizeH ...", 2);
            WriteByte(PageSizeH);
            tmp = com.ReadByte();
            if (tmp != Protocols.PageSize_H_Pass)
            {
                Log("Error Receive PageSize_H_Pass : " + tmp.ToString() + " != " + Protocols.PageSize_H_Pass.ToString(), 1);
                return 5;
            }
            Log("PageSize_H_Pass Received", 2);

            Log("Send PageSizeL ...", 2);
            WriteByte(PageSizeL);
            tmp = com.ReadByte();
            if (tmp != Protocols.PageSize_L_Pass)
            {
                Log("Error Receive PageSize_L_Pass : " + tmp.ToString() + " != " + Protocols.PageSize_L_Pass.ToString(), 1);
                return 6;
            }
            Log("PageSize_L_Pass Received", 2);

            Log("Send E2promSizeH ...", 2);
            WriteByte(E2promSizeH);
            tmp = com.ReadByte();
            if (tmp != Protocols.E2promSize_H_Pass)
            {
                Log("Error Receive E2promSize_H_Pass : " + tmp.ToString() + " != " + Protocols.E2promSize_H_Pass.ToString(), 1);
                return 7;
            }
            Log("E2promSize_H_Pass Received", 2);

            Log("Send E2promSizeL ...", 2);
            WriteByte(E2promSizeL);
            tmp = com.ReadByte();
            if (tmp != Protocols.E2promSize_L_Pass)
            {
                Log("Error Receive E2promSize_L_Pass : " + tmp.ToString() + " != " + Protocols.E2promSize_L_Pass.ToString(), 1);
                return 8;
            }
            Log("E2promSize_L_Pass Received", 2);

            Log("Send MCU_BuildNumber ...", 2);
            WriteByte(MCU_BuildNumber);
            tmp = com.ReadByte();
            if (tmp != Protocols.BuildNumber_Pass)
            {
                Log("Error Receive BuildNumber_Pass : " + tmp.ToString() + " != " + Protocols.BuildNumber_Pass.ToString(), 1);
                return 9;
            }
            Log("BuildNumber_Pass Received", 2);

            if ((MCU_BuildNumber != BuildNumber) && (!ckb_ignore_buildnumber.Checked))
            {
                Log("MCU BootLoader Version Not Supported !",0);
                return 10;
            }
            Log("BootLoader Version Supported", 2);

            PageNumber = (((int)PageNumberH) * 256) + (int)PageNumberL;
            Log("PageNumber = " + PageNumber.ToString(),1);
            PageSize = (((int)PageSizeH) * 256) + (int)PageSizeL;
            Log("PageSize = " + PageSize.ToString(), 1);
            Log("Available Flash Size = " + (PageNumber * PageSize).ToString() + " Bytes | " + (((double)(PageNumber * PageSize) / 1024)).ToString() + " KB", 0);
            E2promSize = (((int)E2promSizeH) * 256) + (int)E2promSizeL;
            Log("E2promSize = " + E2promSize.ToString() + " Bytes", 0);

            return 0;
        }


        public int FuseBits(out byte high, out byte low)
        {
            high = 0;
            low = 0;

            byte high_t = 0;
            byte low_t = 0;
            int tmp;

            com.DiscardInBuffer();
            Log("Send FuseBits_Read_Req ...", 2);
            WriteByte(Protocols.FuseBits_Read_Req);
            tmp = com.ReadByte();
            if (tmp != Protocols.FuseBits_Read_Req_Back)
            {
                if(tmp == Protocols.Unknown_Command)
                {
                    Log("FuseBits Read Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive FuseBits_Read_Req_Back : " + tmp.ToString() + " != " + Protocols.FuseBits_Read_Req_Back.ToString(), 1);
                    Log("Send Error Code ...", 2);
                    WriteByte(Protocols.Error);
                    return 2;
                }
            }
            Log("Received FuseBits_Read_Req_Back", 2);

            Log("Send FuseBits_Read_Continue_1 ...", 2);
            WriteByte(Protocols.FuseBits_Read_Continue_1);

            high_t = (byte)(com.ReadByte());
            Log("Received Fuse High Byte : " + high_t.ToString(), 1);
            low_t = (byte)(com.ReadByte());
            Log("Received Fuse Low Byte : " + low_t.ToString(), 1);

            Log("Send Fuse High Byte ...", 2);
            WriteByte(high_t);
            tmp = com.ReadByte();
            if (tmp != Protocols.FuseBits_Read_Pass)
            {
                Log("Error Receive FuseBitsH_Read_Pass : " + tmp.ToString() + " != " + Protocols.FuseBits_Read_Pass.ToString(), 1);
                return 3;
            }
            Log("Received FuseBitsH_Read_Pass", 2);

            Log("Send Fuse Low Byte ...", 2);
            WriteByte(low_t);
            tmp = com.ReadByte();
            if (tmp != Protocols.FuseBits_Read_Pass)
            {
                Log("Error Receive FuseBitsL_Read_Pass : " + tmp.ToString() + " != " + Protocols.FuseBits_Read_Pass.ToString(), 1);
                return 4;
            }
            Log("Received FuseBitsL_Read_Pass", 2);

            high = high_t;
            low = low_t;

            return 0;

        }


        public int LockBitsR(out byte lockbits)
        {
            lockbits = 0;
            byte lockbits_t = 0;
            int tmp;

            com.DiscardInBuffer();
            Log("Send LockBits_Read_Req ...", 1);
            WriteByte(Protocols.LockBits_Read_Req);

            tmp = com.ReadByte();
            if (tmp != Protocols.LockBits_Read_Req_Back)
            {
                if (tmp == Protocols.Unknown_Command)
                {
                    Log("LockBits Read Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive LockBits_Read_Req_Back : " + tmp.ToString() + " != " + Protocols.LockBits_Read_Req_Back.ToString(), 1);
                    Log("Send Error Code ...", 2);
                    WriteByte(Protocols.Error);
                    return 2;
                }
            }
            Log("Received LockBits_Read_Req_Back", 2);

            Log("Send LockBits_Read_Continue_1", 2);
            WriteByte(Protocols.LockBits_Read_Continue_1);

            lockbits_t = (byte)(com.ReadByte());
            Log("Received " + lockbits_t.ToString() + " As LockBits", 1);

            Log("Send LockBits ...", 2);
            WriteByte(lockbits_t);

            tmp = com.ReadByte();
            if (tmp != Protocols.LockBits_Read_Pass)
            {
                Log("Error Receive LockBits_Read_Pass : " + tmp.ToString() + " != " + Protocols.LockBits_Read_Pass.ToString(), 1);
                return 3;
            }
            Log("Received LockBits_Read_Pass", 2);

            lockbits = lockbits_t;

            return 0;
        }


        public int LockBitsW(bool BLB01, bool BLB02, bool BLB11, bool BLB12)
        {
            int tmp;

            com.DiscardInBuffer();
            Log("Send LockBits_Write_Req ...", 2);
            WriteByte(Protocols.LockBits_Write_Req);

            byte BLB = 195;
            if (BLB01) BLB += 4;
            if (BLB02) BLB += 8;
            if (BLB11) BLB += 16;
            if (BLB12) BLB += 32;
            byte BLBt = 0;

            tmp = com.ReadByte();
            if (tmp != Protocols.LockBits_Write_Req_Back)
            {
                if (tmp == Protocols.Unknown_Command)
                {
                    Log("LockBits Write Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive LockBits_Write_Req_Back : " + tmp.ToString() + " != " + Protocols.LockBits_Write_Req_Back.ToString(), 1);
                    Log("Send Error Code ...", 2);
                    WriteByte(Protocols.Error);
                    return 2;
                }
            }
            Log("Received LockBits_Write_Req_Back", 2);

            Log("Send BootLockBits : " + BLB.ToString() + "  ...",2);
            WriteByte(BLB);

            tmp = com.ReadByte();
            if (tmp != BLB)
            {
                Log("Error Receive BootLockBits : " + tmp.ToString() + " != " + BLB.ToString(), 1);
                Log("Send Error Code ...", 2);
                WriteByte(Protocols.LockBits_Write_Not_Pass_1);
                return 3;
            }
            Log("Received BootLockBits", 2);

            Log("Send LockBits_Write_Pass_1 ...", 2);
            WriteByte(Protocols.LockBits_Write_Pass_1);

            if (LockBitsR(out BLBt) != 0) return 4;

            if (BLBt != BLB)
            {
                Log("Error Apply BootLockBits To MCU : " + BLBt.ToString() + " != " + BLB.ToString(), 1);
                return 5;
            }

            return 0;
        }


        public int FlashPageWrite(bool Operation_E0_W1, byte[,] Bytes, int Page, out bool End)
        {
            byte PageH = (byte)((Page & 0xFF00) >> 8);
            byte PageL = (byte)((Page & 0x00FF) >> 0);
            byte Byte = 0;
            End = false;
            int tmp1;
            int tmp2;

            com.DiscardInBuffer();

            Log("Send FlashPage_Write_Req ...", 2);
            WriteByte(Protocols.FlashPage_Write_Req);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Write_Req_Back)
            {
                if (tmp1 == Protocols.Unknown_Command)
                {
                    Log("Flash Write Operation Not Supported By MCU !", 0);
                    return 4;
                }
                else
                {
                    Log("Error Receive FlashPage_Write_Req_Back : " + tmp1.ToString() + " !+ " + Protocols.FlashPage_Write_Req_Back.ToString(), 1);
                    return 5;
                }
            }
            Log("Received FlashPage_Write_Req_Back", 2);

            Log("Send PageH : " + PageH.ToString() + "  ...", 2);
            WriteByte(PageH);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Write_Continue_1)
            {
                Log("Error Receive FlashPage_Write_Continue_1 : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_Continue_1.ToString(), 1);
                return 6;
            }
            Log("Received FlashPage_Write_Continue_1", 2);

            Log("Send PageL : " + PageL.ToString() + "  ...", 2);
            WriteByte(PageL);

            tmp1 = com.ReadByte();
            tmp2 = com.ReadByte();
            if ((tmp1 != PageH) || (tmp2 != PageL))
            {
                if(tmp1 != PageH)
                {
                    Log("Error Receive PageH : " + tmp1.ToString() + " != " + PageH.ToString(), 1);
                }
                if(tmp2 != PageL)
                {
                    Log("Error Receive PageL : " + tmp2.ToString() + " != " + PageL.ToString(), 1);
                }
                Log("Send FlashPage_Write_Page_Not_Pass ...", 2);
                WriteByte(Protocols.FlashPage_Write_Page_Not_Pass);
                return 7;
            }
            Log("Received PageH & PageL", 2);

            if(!Operation_E0_W1)
            {
                Log("Send FlashPage_Erase_Operation ...", 1);
                WriteByte(Protocols.FlashPage_Erase_Operation);
                tmp1 = com.ReadByte();
                if (tmp1 != Protocols.FlashPage_Erase_Operation_Done)
                {
                    Log("Error Receive FlashPage_Erase_Operation_Done : " + tmp1.ToString() + " != " + Protocols.FlashPage_Erase_Operation_Done.ToString(), 1);
                    return 8;
                }
                Log("Received FlashPage_Erase_Operation_Done", 2);
                return 0;
            }

            Log("Send FlashPage_Write_Operation ...", 1);
            WriteByte(Protocols.FlashPage_Write_Operation);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Write_Continue_2)
            {
                Log("Error Receive FlashPage_Write_Continue_2 : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_Continue_2.ToString(), 1);
                return 9;
            }
            Log("Received FlashPage_Write_Continue_2", 2);

            for (int ctr = 0; ctr < PageSize; ctr++)
            {
                Byte = Bytes[Page, ctr];

                if((ctr < (PageSize -2)) && !End)
                {
                    if ((Bytes[Page, ctr] == 0xFF) && (Bytes[Page, ctr + 1] == 0xFF) && (Bytes[Page, ctr + 2] == 0xFF))
                    {
                        Log("End Of Flash In Page " + Page.ToString() + " And Byte " + (ctr -1).ToString() + " | Total " + ((Page * PageSize) + ctr).ToString() + " Bytes Written .", 0);
                        End = true;
                    }     
                }

                Log("Send Byte : " + Byte.ToString() + " As FlashByte In Page " + Page.ToString() + " & Byte " + ctr.ToString(), 3);
                WriteByte(Byte);

                tmp2 = com.ReadByte();
                if (tmp2 == Byte)
                {
                    Log("Received Byte", 2);
                    Log("Send FlashPage_Write_NextByte ...", 2);
                    WriteByte(Protocols.FlashPage_Write_NextByte);
                    tmp1 = com.ReadByte();
                    if (tmp1 == Protocols.FlashPage_Write_NextByte_Req)
                    {
                        Log("Received FlashPage_Write_NextByte_Req", 2);
                        Log("Send FlashPage_Write_NextByte_Req_Back ...", 2);
                        WriteByte(Protocols.FlashPage_Write_NextByte_Req_Back);
                    }
                    else
                    {
                        Log("Error Receive FlashPage_Write_NextByte_Req : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_NextByte_Req.ToString(), 1);
                        Log("Send Error Code ...", 2);
                        WriteByte(Protocols.Error);
                        return 10;
                    }
                }
                else
                {
                    Log("Error Receive Byte : " + tmp2.ToString() + " != " + Byte.ToString(), 1);
                    ctr--;
                    Log("Send FlashPage_Write_TryByte ...", 2);
                    WriteByte(Protocols.FlashPage_Write_TryByte);
                    tmp1 = com.ReadByte();
                    if (tmp1 == Protocols.FlashPage_Write_TryByte_Req)
                    {
                        Log("Received FlashPage_Write_TryByte_Req", 2);
                        Log("Send FlashPage_Write_TryByte_Req_Back ...", 2);
                        WriteByte(Protocols.FlashPage_Write_TryByte_Req_Back);
                    }
                    else
                    {
                        Log("Error Receive FlashPage_Write_TryByte_Req : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_TryByte_Req.ToString(), 1);
                        Log("Send Error Code ...", 2);
                        WriteByte(Protocols.Error);
                        return 11;
                    }
                }
            }

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Write_Wait_Req)
            {
                Log("Error Receive FlashPage_Write_Wait_Req : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_Wait_Req.ToString(), 1);
                return 12;
            }
            Log("Received FlashPage_Write_Wait_Req", 2);

            Log("Send FlashPage_Write_Wait_Req_Back", 2);
            WriteByte(Protocols.FlashPage_Write_Wait_Req_Back);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Write_Done)
            {
                Log("Error Receive FlashPage_Write_Done : " + tmp1.ToString() + " != " + Protocols.FlashPage_Write_Done.ToString(), 1);
                return 13;
            }
            Log("Received FlashPage_Write_Done", 2);

            return 0;
        }


        public int FlashPageRead(ref byte[] Bytes, int Page, out bool End)
        {
            byte PageH = (byte)((Page & 0xFF00) >> 8);
            byte PageL = (byte)((Page & 0x00FF) >> 0);
            int tmp1;
            int tmp2;
            End = false;

            com.DiscardInBuffer();

            Log("Send FlashPage_Read_Req ...", 2);
            WriteByte(Protocols.FlashPage_Read_Req);
            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Read_Req_Back)
            {
                if (tmp1 == Protocols.Unknown_Command)
                {
                    Log("Flash Read Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive FlashPage_Read_Req_Back : " + tmp1.ToString() + " != " + Protocols.FlashPage_Read_Req_Back.ToString(), 1);
                    return 2;
                }
            }
            Log("Received FlashPage_Read_Req_Back", 2);

            Log("Send PageH ...", 2);
            WriteByte(PageH);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Read_Continue_1)
            {
                Log("Error Receive FlashPage_Read_Continue_1 : " + tmp1.ToString() + " != " + Protocols.FlashPage_Read_Continue_1.ToString(), 1);
                return 3;
            }
            Log("Received FlashPage_Read_Continue_1", 2);

            Log("Send PageL ...", 2);
            WriteByte(PageL);

            tmp1 = com.ReadByte();
            tmp2 = com.ReadByte();
            if ((tmp1 != PageH) || (tmp2 != PageL))
            {
                if (tmp1 != PageH)
                {
                    Log("Error Receive PageH : " + tmp1.ToString() + " != " + PageH.ToString(), 1);
                }
                if (tmp2 != PageL)
                {
                    Log("Error Receive PageL : " + tmp2.ToString() + " != " + PageL.ToString(), 1);
                }

                Log("Send FlashPage_Read_Page_Not_Pass ...", 2);
                WriteByte(Protocols.FlashPage_Read_Page_Not_Pass);
                return 4;
            }
            Log("Received PageH & PageL", 2);

            Log("Send FlashPage_Read_Page_Pass ...", 2);
            WriteByte(Protocols.FlashPage_Read_Page_Pass);

            for(int c = (PageSize * Page); c < (PageSize * (Page+1)); c++)
            {
                tmp1 = com.ReadByte();
                Log("Received Byte : " + tmp1.ToString() + " As Flash Byte In Page " + Page.ToString() + " & Byte " + (c - (PageSize * Page)).ToString(), 3);
                Bytes[c] = (byte)tmp1;
                Log("Send Back Byte ...", 3);
                WriteByte(Bytes[c]);
                tmp1 = (byte)com.ReadByte();
                if(tmp1 == Protocols.FlashPage_Read_NextByte)
                {
                    Log("Received FlashPage_Read_NextByte", 3);
                    WriteByte(Protocols.FlashPage_Read_NextByte_Req);
                }
                else if (tmp1 == Protocols.FlashPage_Read_TryByte)
                {
                    Log("Received FlashPage_Read_TryByte", 1);
                    WriteByte(Protocols.FlashPage_Read_TryByte_Req);
                    c--;
                }
                else
                {
                    Log("Unknown Code Received : " + tmp1.ToString() + " != " + Protocols.FlashPage_Read_NextByte.ToString() + " != " + Protocols.FlashPage_Read_TryByte.ToString(), 1);
                    Log("Send Error Code ...", 2);
                    WriteByte(Protocols.Error);
                    return 5;
                }
            }

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.FlashPage_Read_Done)
            {
                Log("Error Receive FlashPage_Read_Done : " + tmp1.ToString() + " != " + Protocols.FlashPage_Read_Done.ToString(), 1);
                return 6;
            }
            Log("Received FlashPage_Read_Done", 2);

            if ((Bytes[(PageSize * Page)+PageSize -3] == 0xFF) && (Bytes[(PageSize * Page) + PageSize - 2] == 0xFF) && (Bytes[(PageSize * Page) + PageSize - 1] == 0xFF))
            {
                End = true;
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
                Log("End Of Flash In Page " + Page.ToString() + " And Byte " + (BytesTrueSize % PageSize -1).ToString() + " | Total " + BytesTrueSize.ToString() + " Bytes Read .", 0);
            }
            return 0;
        }


        public int E2promReadByte(out byte Byte, int Address)
        {
            Byte = 0xFF;
            byte AddressH = (byte)((Address & 0xFF00) >> 8);
            byte AddressL = (byte)((Address & 0x00FF) >> 0);
            int tmp1;
            int tmp2;

            com.DiscardInBuffer();

            Log("Send E2prom_Read_Req ...", 2);
            WriteByte(Protocols.E2prom_Read_Req);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Read_Req_Back)
            {
                if (tmp1 == Protocols.Unknown_Command)
                {
                    Log("E2prom Read Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive E2prom_Read_Req_Back : " + tmp1.ToString() + " != " + Protocols.E2prom_Read_Req_Back.ToString(), 1);
                    return 2;
                }
            }
            Log("Received E2prom_Read_Req_Back", 2);

            Log("Send AddressH ...", 2);
            WriteByte(AddressH);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Read_Continue_1)
            {
                Log("Error Receive E2prom_Read_Continue_1 : " + tmp1.ToString() + " != " + Protocols.E2prom_Read_Continue_1.ToString(), 1);
                return 3;
            }
            Log("Received E2prom_Read_Continue_1", 2);

            Log("Send AddressL ...", 2);
            WriteByte(AddressL);

            tmp1 = com.ReadByte();
            tmp2 = com.ReadByte();
            if ((tmp1 != AddressH) || (tmp2 != AddressL))
            {
                if (tmp1 != AddressH)
                {
                    Log("Error Receive AddressH : " + tmp1.ToString() + " != " + AddressH.ToString(), 1);
                }
                if (tmp2 != AddressL)
                {
                    Log("Error Receive AddressL : " + tmp2.ToString() + " != " + AddressL.ToString(), 1);

                }

                Log("Send E2prom_Read_Address_Not_Pass ...", 2);
                WriteByte(Protocols.E2prom_Read_Address_Not_Pass);
                return 4;
            }
            Log("Received AddressH & AddressL", 2);

            Log("Send E2prom_Read_Address_Pass", 2);
            WriteByte(Protocols.E2prom_Read_Address_Pass);

            tmp2 = com.ReadByte();
            Log("Receive " + tmp2.ToString() + " As E2prom Byte In Address " + Address.ToString(), 2);

            Log("Send Back Byte ...", 2);
            WriteByte((byte)tmp2);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Read_ValidByte)
            {
                Log("Error Receive E2prom_Read_ValidByte : " + tmp1.ToString() + " != " + Protocols.E2prom_Read_ValidByte.ToString(), 1);
                return 5;
            }
            Log("Received E2prom_Read_ValidByte", 2);

            Log("Send E2prom_Read_Done ...", 2);
            WriteByte(Protocols.E2prom_Read_Done);

            Byte = (byte)tmp2;

            return 0;
        }


        public int E2promWriteByte(in byte Byte, int Address)
        {
            byte AddressH = (byte)((Address & 0xFF00) >> 8);
            byte AddressL = (byte)((Address & 0x00FF) >> 0);
            int tmp1;
            int tmp2;

            com.DiscardInBuffer();

            Log("Send E2prom_Write_Req ...", 2);
            WriteByte(Protocols.E2prom_Write_Req);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Write_Req_Back)
            {
                if (tmp1 == Protocols.Unknown_Command)
                {
                    Log("E2prom Write Operation Not Supported By MCU !", 0);
                    return 1;
                }
                else
                {
                    Log("Error Receive E2prom_Write_Req_Back : " + tmp1.ToString() + " != " + Protocols.E2prom_Write_Req_Back.ToString(), 1);
                    return 2;
                }
            }
            Log("Received E2prom_Write_Req_Back", 2);

            Log("Send AddressH ...", 2);
            WriteByte(AddressH);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Write_Continue_1)
            {
                Log("Error Receive E2prom_Write_Continue_1 : " + tmp1.ToString() + " != " + Protocols.E2prom_Write_Continue_1.ToString(), 1);
                return 3;
            }
            Log("Received E2prom_Write_Continue_1", 2);

            Log("Send AddressL ...", 2);
            WriteByte(AddressL);

            tmp1 = com.ReadByte();
            tmp2 = com.ReadByte();
            if ((tmp1 != AddressH) || (tmp2 != AddressL))
            {
                if (tmp1 != AddressH)
                {
                    Log("Error Receive AddressH : " + tmp1.ToString() + " != " + AddressH.ToString(), 1);
                }
                if (tmp2 != AddressL)
                {
                    Log("Error Receive AddressL : " + tmp2.ToString() + " != " + AddressL.ToString(), 1);
                }

                Log("Send E2prom_Write_Address_Not_Pass ...", 2);
                WriteByte(Protocols.E2prom_Write_Address_Not_Pass);
                return 4;
            }
            Log("Received AddressH & AddressL", 2);

            Log("Send E2prom_Write_Address_Pass ...", 2);
            WriteByte(Protocols.E2prom_Write_Address_Pass);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Write_Continue_2)
            {
                Log("Error Receive E2prom_Write_Continue_2 : " + tmp1.ToString() + " != " + Protocols.E2prom_Write_Continue_2.ToString(), 1);
                return 5;
            }
            Log("Received E2prom_Write_Continue_2", 2);

            Log("Send " + Byte.ToString() + " As E2prom Byte ...", 2);
            WriteByte(Byte);

            tmp1 = com.ReadByte();
            if (tmp1 != Byte)
            {
                Log("Error Receive E2prom Byte : " + tmp1.ToString() + " != " + Byte.ToString(), 1);
                Log("Send E2prom_Write_InvalidByte", 2);
                WriteByte(Protocols.E2prom_Write_InvalidByte);
                return 6;
            }
            Log("Received Byte", 2);

            Log("Send E2prom_Write_ValidByte ...", 2);
            WriteByte(Protocols.E2prom_Write_ValidByte);

            tmp1 = com.ReadByte();
            if (tmp1 != Protocols.E2prom_Write_Done_Req)
            {
                Log("Error Receive E2prom_Write_Done_Req : " + tmp1.ToString() + " != " + Protocols.E2prom_Write_Done_Req.ToString(), 1);
                return 7;
            }
            Log("Received E2prom_Write_Done_Req", 2);

            Log("Send E2prom_Write_Done_Req_Back ...", 2);
            WriteByte(Protocols.E2prom_Write_Done_Req_Back);

            return 0;
        }


        public int FlashWrite(byte[,] Flash, int EndByte, ref int CurrentPage)
        {
            int Page = 0;
            int ErrorCode = 0;
            int BytePointer = 0;
            bool End = false;
            int PageNeeded = EndByte / PageSize;
            if ((EndByte % PageSize) > 0) PageNeeded++;

            ProgressInit(PageNeeded);

            for (int ctr = 0; ctr < PageNumber; ctr++)
            {
                ErrorCode = FlashPageWrite(true,Flash, ctr, out End);
                Log("Write Page : " + Page.ToString(), 1);
                BytePointer += PageSize;
                CurrentPage = Page + 1;
                Page++;
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
                if (End) break;
                if (BytePointer == EndByte) break;
            }

            return 0;
        }


        public int FlashRead(ref byte[] Flash, ref int CurrentPage)
        {
            ProgressInit(PageNumber);

            for(int i = 0; i < Flash.Length; i++)
            {
                Flash[i] = 0xFF;
            }
            bool End = false;
            int ErrorCode = 0;
            for(int Page = 0; Page<PageNumber; Page++)
            {
                CurrentPage = Page;
                ErrorCode = FlashPageRead(ref Flash, Page, out End);
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
                Log("Read Page : " + Page.ToString(), 1);
                if (End) break;
            }

            ProgressSet(PageNumber);
            return 0;
        }


        public int FlashVerify(byte[] File, ref int CurrentPage, ref int CurrentByte, out bool Verify)
        {
            ProgressInit(PageNumber);

            byte[] Flash = new byte[PageNumber * PageSize];
            bool End = false;
            int ErrorCode = 0;
            Verify = true;

            for (int i = 0; i < Flash.Length; i++)
            {
                Flash[i] = 0xFF;
            }

            for (int Page = 0; Page < PageNumber; Page++)
            {
                CurrentPage = Page;
                ErrorCode = FlashPageRead(ref Flash, Page, out End);
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
                for (int v = (PageSize * Page); v < (PageSize * (Page + 1)); v++)
                {
                    CurrentByte = v - (PageSize * Page);
                    if (Flash[v] != File[v])
                    {
                        Verify = false;
                        return 0;
                    }
                }
                Log("Verify Page : " + Page.ToString(), 1);
                if (End) break;
            }

            ProgressSet(PageNumber);
            return 0;
        }


        public int FlashErase(ref int CurrentPage)
        {
            ProgressInit(PageNumber);

            int ErrorCode = 0;
            bool End = false;
            byte[,] Flash = new byte[PageNumber , PageSize];
            CurrentPage = 0;

            for (int ctr = 0; ctr < PageNumber; ctr++)
            {
                ErrorCode = FlashPageWrite(false, Flash, ctr, out End);
                Log("Erase Page : " + CurrentPage.ToString(), 1);

                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);

                CurrentPage++;
            }

            ProgressSet(PageNumber);
            return 0;
        }


        public int E2promRead(ref byte[] E2prom)
        {
            ProgressInit(E2promSize);

            int ErrorCode = 0;
            for(int c = 0; c < E2promSize; c++)
            {
                ErrorCode = E2promReadByte(out E2prom[c], c);
                Log("Read E2prom Address : " + c.ToString(), 1);
                if(ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
            }

            ProgressSet(E2promSize);
            return 0;
        }


        public int E2promVerify(byte[] File, ref int CurrentByte, out bool Verify)
        {
            ProgressInit(E2promSize);

            int ErrorCode = 0;
            byte E2prom = 0;
            Verify = true;
            for (int c = 0; c < E2promSize; c++)
            {
                CurrentByte = c;
                ErrorCode = E2promReadByte(out E2prom, c);
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
                Log("Verify Address : " + c.ToString(), 1);
                if(E2prom != File[c])
                {
                    Verify = false;
                    return 0;
                }
            }

            ProgressSet(E2promSize);
            return 0;
        }


        public int E2promWrite(in byte[] E2prom, ref int CurrentAddress, bool Ignore0xFF)
        {
            ProgressInit(E2promSize);

            int ErrorCode = 0;

            for(int c = 0; c < E2promSize; c++)
            {
                if ((E2prom[c] == 0xFF) && Ignore0xFF)
                {
                    Log("Ignore Value 0xFF in Address : " + c.ToString(), 1);
                    continue;
                }
                ErrorCode = E2promWriteByte(E2prom[c], c);
                Log("Write Value " + E2prom[c].ToString() + " in Address " + c.ToString(), 1);
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
            }

            ProgressSet(E2promSize);
            return 0;
        }


        public int E2promErase(ref int CurrentByte, bool Ignore0xFF)
        {
            ProgressInit(E2promSize);

            int ErrorCode = 0;
            byte E2byte = 0;

            for (int c = 0; c < E2promSize; c++)
            {
                CurrentByte = c;
                ErrorCode = E2promReadByte(out E2byte, c);
                if (ErrorCode != 0) return ErrorCode;
                ProgressInc(1);
                if ((E2byte != 0xFF) || (!Ignore0xFF))
                {
                    ErrorCode = E2promWriteByte(0xFF, c);
                    if (ErrorCode != 0) return ErrorCode;
                    Log("Erase Address " + c.ToString() + " in E2prom", 1);
                }
                else
                {
                    Log("Ignore Address " + c.ToString() + " in E2prom", 1);
                }
            }

            ProgressSet(E2promSize);
            return 0;
        }


        public int ResetToApp()
        {
            int tmp;

            if (!FreeCheck()) return 1;
            Log("Send Reset_App ...", 1);
            WriteByte(Protocols.Reset_App);

            tmp = com.ReadByte();
            if (tmp != Protocols.App_Loaded)
            {
                if (tmp == Protocols.Unknown_Command)
                {
                    Log("Reset Operation Not Supported By MCU !", 0);
                    return 2;
                }
                else
                {
                    Log("Error Receive App_Loaded : " + tmp.ToString() + " != " + Protocols.App_Loaded.ToString(), 1);
                    return 2;
                }
            }
            Log("Received App_Loaded", 1);

            return 0;
        }


        public int Sleep()
        {
            int tmp;

            if (!FreeCheck()) return 1;
            Log("Send Sleep Request ...", 1);
            WriteByte(Protocols.Sleep);

            tmp = com.ReadByte();
            if (tmp != Protocols.Sleep_Entered)
            {
                if (tmp == Protocols.Unknown_Command)
                {
                    Log("Sleep Operation Not Supported By MCU !", 0);
                    return 2;
                }
                else
                {
                    Log("Error Receive Sleep_Entered : " + tmp.ToString() + " != " + Protocols.Sleep_Entered.ToString(), 1);
                    return 3;
                }
            }
            Log("Received Sleep_Entered", 1);

            return 0;
        }


        //******************************************************************************************************************************//

        public void status(byte s)
        {
            switch(s)
            {
                case 0:
                    lbl_status.Text = "Failure";
                    lbl_status.BackColor = Color.Red;
                    break;
                case 1:
                    lbl_status.Text = "Warning";
                    lbl_status.BackColor = Color.DarkKhaki;
                    break;
                case 2:
                    lbl_status.Text = "Success";
                    lbl_status.BackColor = Color.Chartreuse;
                    break;
                default:
                    lbl_status.Text = "";
                    lbl_status.BackColor = Color.OrangeRed;
                    break;
            }
            //ProgressReset();
        }


        public void McuModelSet(string mcu)
        {
            switch (mcu)
            {
                case "Mega32":
                case "Mega32a":
                    ckb_fusebit_l8.Text = "BODLEVEL";
                    ckb_fusebit_l7.Text = "BODEN";
                    ckb_fusebit_l6.Text = "SUT1";
                    ckb_fusebit_l5.Text = "SUT0";
                    ckb_fusebit_l4.Text = "CKSEL 3";
                    ckb_fusebit_l3.Text = "CKSEL 2";
                    ckb_fusebit_l2.Text = "CKSEL 1";
                    ckb_fusebit_l1.Text = "CKSEL 0";

                    ckb_fusebit_h8.Text = "OCDEN";
                    ckb_fusebit_h7.Text = "JTAGEN";
                    ckb_fusebit_h6.Text = "SPIEN";
                    ckb_fusebit_h5.Text = "CKOPT";
                    ckb_fusebit_h4.Text = "EESAVE";
                    ckb_fusebit_h3.Text = "BOOTSZ1";
                    ckb_fusebit_h2.Text = "BOOTSZ0";
                    ckb_fusebit_h1.Text = "BOOTRST";
                    break;

                case "Mega8":
                case "Mega8a":
                    ckb_fusebit_l8.Text = "BODLEVEL";
                    ckb_fusebit_l7.Text = "BODEN";
                    ckb_fusebit_l6.Text = "SUT1";
                    ckb_fusebit_l5.Text = "SUT0";
                    ckb_fusebit_l4.Text = "CKSEL 3";
                    ckb_fusebit_l3.Text = "CKSEL 2";
                    ckb_fusebit_l2.Text = "CKSEL 1";
                    ckb_fusebit_l1.Text = "CKSEL 0";

                    ckb_fusebit_h8.Text = "RSTDISABLE";
                    ckb_fusebit_h7.Text = "WTDON";
                    ckb_fusebit_h6.Text = "SPIEN";
                    ckb_fusebit_h5.Text = "CKOPT";
                    ckb_fusebit_h4.Text = "EESAVE";
                    ckb_fusebit_h3.Text = "BOOTSZ1";
                    ckb_fusebit_h2.Text = "BOOTSZ0";
                    ckb_fusebit_h1.Text = "BOOTRST";
                    break;
                default:
                    ckb_fusebit_l8.Text = "FuseBit_l8";
                    ckb_fusebit_l7.Text = "FuseBit_l7";
                    ckb_fusebit_l6.Text = "FuseBit_l6";
                    ckb_fusebit_l5.Text = "FuseBit_l5";
                    ckb_fusebit_l4.Text = "FuseBit_l4";
                    ckb_fusebit_l3.Text = "FuseBit_l3";
                    ckb_fusebit_l2.Text = "FuseBit_l2";
                    ckb_fusebit_l1.Text = "FuseBit_l1";
                    ckb_fusebit_h8.Text = "FuseBit_h8";
                    ckb_fusebit_h7.Text = "FuseBit_h7";
                    ckb_fusebit_h6.Text = "FuseBit_h6";
                    ckb_fusebit_h5.Text = "FuseBit_h5";
                    ckb_fusebit_h4.Text = "FuseBit_h4";
                    ckb_fusebit_h3.Text = "FuseBit_h3";
                    ckb_fusebit_h2.Text = "FuseBit_h2";
                    ckb_fusebit_h1.Text = "FuseBit_h1";
                    break;

            }
        }


        public void Log(string log, int level)
        {
            if(cmb_log_level.SelectedIndex >= level)
            {
                LogLine++;
                txt_log.AppendText(LogLine.ToString() + " -> " + log + "\r\n");
            }
        }


        public void ProgressInit(int Size)
        {
            prgrs_progress.Minimum = 0;
            prgrs_progress.Maximum = Size;
            prgrs_progress.Value = 0;
        }


        public void ProgressSet(int Value)
        {
            prgrs_progress.Value = Value;
        }


        public void ProgressInc(int Inc)
        {
            if ((prgrs_progress.Value + Inc) < prgrs_progress.Maximum)
                prgrs_progress.Value += Inc;
            else
                prgrs_progress.Value = prgrs_progress.Maximum;
            Log("Progress : " + prgrs_progress.Value.ToString(), 2);
        }


        public string Configs_Load(in string FileName)
        {
            string ErrorCode = "";
            bool Error = false;
            int Type = 0;
            bool Bool = false;
            int Integer = 0;
            string String = "";


            bool AutoResetAfterWriteFlash = false;
            bool AutoResetAfterReadFlash = false;
            bool LockAppWriteAfterFlashWrite = false;
            bool LockAppReadAfterFlashRead = false;
            bool EraseFlashBeforeFlashWrite = true;
            bool EraseE2promBeforeFlashWrite = false;
            bool VerifyFlashAfterFlashWrite = true;
            bool IgnoreLockBitsForFlashWR = false;
            int FlashFileType = 0;

            bool AutoResetAfterE2promWrite = false;
            bool AutoResetAfterE2promRead = false;
            bool EraseE2promBeforeE2promWrite = false;
            bool Ignore0xffForE2promErase = true;
            bool Ignore0xffForE2promRead = true;
            bool Ignore0xffForE2promWrite = true;
            int E2promFileType = 0;

            int PortName = 0;
            int BaudRate = 12;
            int TimeOut = 4;
            int Parity = 0;
            int StopBits = 0;
            bool IgnoreBuildNumberMismatch = false;

            int LogLevel = 0;

            int SaveMode = 2;

            string FlashSavePath = "";
            string FlashOpenPath = "";
            string E2promSavePath = "";
            string E2promOpenPath = "";

            if (File.Exists(FileName))
            {
                Log("Loading Config ...", 1);

                ErrorCode = IO.Configs_Read(FileName, "AutoResetAfterWriteFlash", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) AutoResetAfterWriteFlash = Bool;

                ErrorCode = IO.Configs_Read(FileName, "AutoResetAfterReadFlash", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) AutoResetAfterReadFlash = Bool;

                ErrorCode = IO.Configs_Read(FileName, "LockAppWriteAfterFlashWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) LockAppWriteAfterFlashWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "LockAppReadAfterFlashRead", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) LockAppReadAfterFlashRead = Bool;

                ErrorCode = IO.Configs_Read(FileName, "EraseFlashBeforeFlashWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) EraseFlashBeforeFlashWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "EraseE2promBeforeFlashWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) EraseE2promBeforeFlashWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "VerifyFlashAfterFlashWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) VerifyFlashAfterFlashWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "IgnoreLockBitsForFlashWR", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) IgnoreLockBitsForFlashWR = Bool;

                ErrorCode = IO.Configs_Read(FileName, "FlashFileType", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) FlashFileType = Integer;

                ErrorCode = IO.Configs_Read(FileName, "AutoResetAfterE2promWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) AutoResetAfterE2promWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "AutoResetAfterE2promRead", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) AutoResetAfterE2promRead = Bool;

                ErrorCode = IO.Configs_Read(FileName, "EraseE2promBeforeE2promWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) EraseE2promBeforeE2promWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "Ignore0xffForE2promErase", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) Ignore0xffForE2promErase = Bool;

                ErrorCode = IO.Configs_Read(FileName, "Ignore0xffForE2promRead", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) Ignore0xffForE2promRead = Bool;

                ErrorCode = IO.Configs_Read(FileName, "Ignore0xffForE2promWrite", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) Ignore0xffForE2promWrite = Bool;

                ErrorCode = IO.Configs_Read(FileName, "E2promFileType", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) E2promFileType = Integer;

                ErrorCode = IO.Configs_Read(FileName, "PortName", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) PortName = Integer;

                ErrorCode = IO.Configs_Read(FileName, "BaudRate", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) BaudRate = Integer;

                ErrorCode = IO.Configs_Read(FileName, "TimeOut", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) TimeOut = Integer;

                ErrorCode = IO.Configs_Read(FileName, "Parity", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) Parity = Integer;

                ErrorCode = IO.Configs_Read(FileName, "StopBits", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) StopBits = Integer;

                ErrorCode = IO.Configs_Read(FileName, "IgnoreBuildNumberMismatch", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 1) IgnoreBuildNumberMismatch = Bool;

                ErrorCode = IO.Configs_Read(FileName, "LogLevel", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) LogLevel = Integer;

                ErrorCode = IO.Configs_Read(FileName, "SaveMode", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 2) SaveMode = Integer;

                ErrorCode = IO.Configs_Read(FileName, "FlashSavePath", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 3) FlashSavePath = String;

                ErrorCode = IO.Configs_Read(FileName, "FlashOpenPath", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 3) FlashOpenPath = String;

                ErrorCode = IO.Configs_Read(FileName, "E2promSavePath", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 3) E2promSavePath = String;

                ErrorCode = IO.Configs_Read(FileName, "E2promOpenPath", out Type, out Bool, out Integer, out String);
                if (ErrorCode != "No Error")
                {
                    Error = true;
                    goto AfterReadFile;
                }
                if (Type == 3) E2promOpenPath = String;
            }
            else
            {
                Log("Config File Not Found !", 0);
                return "File Not Found";
            }
            AfterReadFile:
            if (Error)
            {
                Log("Invalid Or Corrupted Config File !", 0);
                return ErrorCode;
            }

            ckb_auto_reset_after_write_flash.Checked = AutoResetAfterWriteFlash;
            ckb_auto_reset_after_read_flash.Checked = AutoResetAfterReadFlash;
            ckb_lock_app_write_after_write_flash.Checked = LockAppWriteAfterFlashWrite;
            ckb_lock_app_read_after_read_flash.Checked = LockAppReadAfterFlashRead;
            ckb_erase_flash_before_write_flash.Checked = EraseFlashBeforeFlashWrite;
            ckb_erase_e2prom_before_write_flash.Checked = EraseE2promBeforeFlashWrite;
            ckb_verify_after_flash_write.Checked = VerifyFlashAfterFlashWrite;
            ckb_ignore_lockbits_while_write_flash.Checked = IgnoreLockBitsForFlashWR;
            cmb_file_type_flash.SelectedIndex = FlashFileType;

            ckb_auto_reset_after_e2prom_write.Checked = AutoResetAfterE2promWrite;
            ckb_auto_reset_after_e2prom_read.Checked = AutoResetAfterE2promRead;
            ckb_erase_e2prom_before_write_e2prom.Checked = EraseE2promBeforeE2promWrite;
            ckb_ignore_0xFF_for_e2prom_erase.Checked = Ignore0xffForE2promErase;
            ckb_ignore_0xFF_for_e2prom_read.Checked = Ignore0xffForE2promRead;
            ckb_ignore_oxFF_for_e2prom_write.Checked = Ignore0xffForE2promWrite;
            cmb_file_type_e2prom.SelectedIndex = E2promFileType;

            cmb_port.SelectedIndex = PortName;
            cmb_baudrate.SelectedIndex = BaudRate;
            cmb_timeout.SelectedIndex = TimeOut;
            cmb_parity.SelectedIndex = Parity;
            cmb_stopbits.SelectedIndex = StopBits;
            ckb_ignore_buildnumber.Checked = IgnoreBuildNumberMismatch;

            cmb_log_level.SelectedIndex = LogLevel;

            cmb_save_mode_settings.SelectedIndex = SaveMode;

            txt_save_path_flash.Text = FlashSavePath;
            txt_open_path_flash.Text = FlashOpenPath;
            txt_save_path_eeprom.Text = E2promSavePath;
            txt_open_path_eeprom.Text = E2promOpenPath;

            Log("Config Loaded", 1);

            return "Config Loaded";
        }


        public void Config_Load_Default()
        {
            ckb_auto_reset_after_write_flash.Checked = false;
            ckb_auto_reset_after_read_flash.Checked = false;
            ckb_lock_app_write_after_write_flash.Checked = false;
            ckb_lock_app_read_after_read_flash.Checked = false;
            ckb_erase_flash_before_write_flash.Checked = true;
            ckb_erase_e2prom_before_write_flash.Checked = false;
            ckb_verify_after_flash_write.Checked = true;
            ckb_ignore_lockbits_while_write_flash.Checked = false;
            cmb_file_type_flash.SelectedIndex = 0;

            ckb_auto_reset_after_e2prom_write.Checked = false;
            ckb_auto_reset_after_e2prom_read.Checked = false;
            ckb_erase_e2prom_before_write_e2prom.Checked = false;
            ckb_ignore_0xFF_for_e2prom_erase.Checked = true;
            ckb_ignore_0xFF_for_e2prom_read.Checked = true;
            ckb_ignore_oxFF_for_e2prom_write.Checked = true;
            cmb_file_type_e2prom.SelectedIndex = 0;

            cmb_port.SelectedIndex = 0;
            cmb_baudrate.SelectedIndex = 12;
            cmb_timeout.SelectedIndex = 4;
            cmb_parity.SelectedIndex = 0;
            cmb_stopbits.SelectedIndex = 0;
            ckb_ignore_buildnumber.Checked = false;

            cmb_log_level.SelectedIndex = 0;

            cmb_save_mode_settings.SelectedIndex = 2;

            txt_save_path_flash.Text = "";
            txt_open_path_flash.Text = "";
            txt_save_path_eeprom.Text = "";
            txt_open_path_eeprom.Text = "";

            btn_flash_read.Enabled = false;
            btn_flash_verify.Enabled = false;
            btn_flash_write.Enabled = false;
            btn_eeprom_read.Enabled = false;
            btn_eeprom_verify.Enabled = false;
            btn_eeprom_write.Enabled = false;
        }


        public void Configs_Save(in string FileName)
        {
            bool AutoResetAfterWriteFlash = ckb_auto_reset_after_write_flash.Checked;
            bool AutoResetAfterReadFlash = ckb_auto_reset_after_read_flash.Checked;
            bool LockAppWriteAfterFlashWrite = ckb_lock_app_write_after_write_flash.Checked;
            bool LockAppReadAfterFlashRead = ckb_lock_app_read_after_read_flash.Checked;
            bool EraseFlashBeforeFlashWrite = ckb_erase_flash_before_write_flash.Checked;
            bool EraseE2promBeforeFlashWrite = ckb_erase_e2prom_before_write_flash.Checked;
            bool VerifyFlashAfterFlashWrite = ckb_verify_after_flash_write.Checked;
            bool IgnoreLockBitsForFlashWR = ckb_ignore_lockbits_while_write_flash.Checked;
            int FlashFileType = cmb_file_type_flash.SelectedIndex;

            bool AutoResetAfterE2promWrite = ckb_auto_reset_after_e2prom_write.Checked;
            bool AutoResetAfterE2promRead = ckb_auto_reset_after_e2prom_read.Checked;
            bool EraseE2promBeforeE2promWrite = ckb_erase_e2prom_before_write_e2prom.Checked;
            bool Ignore0xffForE2promErase = ckb_ignore_0xFF_for_e2prom_erase.Checked;
            bool Ignore0xffForE2promRead = ckb_ignore_0xFF_for_e2prom_read.Checked;
            bool Ignore0xffForE2promWrite = ckb_ignore_oxFF_for_e2prom_write.Checked;
            int E2promFileType = cmb_file_type_e2prom.SelectedIndex;

            int PortName = cmb_port.SelectedIndex;
            int BaudRate = cmb_baudrate.SelectedIndex;
            int TimeOut = cmb_timeout.SelectedIndex;
            int Parity = cmb_parity.SelectedIndex;
            int StopBits = cmb_stopbits.SelectedIndex;
            bool IgnoreBuildNumberMismatch = ckb_ignore_buildnumber.Checked;

            int LogLevel = cmb_log_level.SelectedIndex;

            int SaveMode = cmb_save_mode_settings.SelectedIndex;

            string FlashSavePath = txt_save_path_flash.Text;
            string FlashOpenPath = txt_open_path_flash.Text;
            string E2promSavePath = txt_save_path_eeprom.Text;
            string E2promOpenPath = txt_open_path_eeprom.Text;

            Log("Delete Old Config ...", 1);

            File.Delete(FileName);

            IO.Configs_Write(FileName, "AutoResetAfterWriteFlash", 1, AutoResetAfterWriteFlash, 0, "");
            IO.Configs_Write(FileName, "AutoResetAfterReadFlash", 1, AutoResetAfterReadFlash, 0, "");
            IO.Configs_Write(FileName, "LockAppWriteAfterFlashWrite", 1, LockAppWriteAfterFlashWrite, 0, "");
            IO.Configs_Write(FileName, "LockAppReadAfterFlashRead", 1, LockAppReadAfterFlashRead, 0, "");
            IO.Configs_Write(FileName, "EraseFlashBeforeFlashWrite", 1, EraseFlashBeforeFlashWrite, 0, "");
            IO.Configs_Write(FileName, "EraseE2promBeforeFlashWrite", 1, EraseE2promBeforeFlashWrite, 0, "");
            IO.Configs_Write(FileName, "VerifyFlashAfterFlashWrite", 1, VerifyFlashAfterFlashWrite, 0, "");
            IO.Configs_Write(FileName, "IgnoreLockBitsForFlashWR", 1, IgnoreLockBitsForFlashWR, 0, "");
            IO.Configs_Write(FileName, "FlashFileType", 2, false, FlashFileType, "");
            IO.Configs_Write(FileName, "AutoResetAfterE2promWrite", 1, AutoResetAfterE2promWrite, 0, "");
            IO.Configs_Write(FileName, "AutoResetAfterE2promRead", 1, AutoResetAfterE2promRead, 0, "");
            IO.Configs_Write(FileName, "EraseE2promBeforeE2promWrite", 1, EraseE2promBeforeE2promWrite, 0, "");
            IO.Configs_Write(FileName, "Ignore0xffForE2promErase", 1, Ignore0xffForE2promErase, 0, "");
            IO.Configs_Write(FileName, "Ignore0xffForE2promRead", 1, Ignore0xffForE2promRead, 0, "");
            IO.Configs_Write(FileName, "Ignore0xffForE2promWrite", 1, Ignore0xffForE2promWrite, 0, "");
            IO.Configs_Write(FileName, "E2promFileType", 2, false, E2promFileType, "");
            IO.Configs_Write(FileName, "PortName", 2, false, PortName, "");
            IO.Configs_Write(FileName, "BaudRate", 2, false, BaudRate, "");
            IO.Configs_Write(FileName, "TimeOut", 2, false, TimeOut, "");
            IO.Configs_Write(FileName, "Parity", 2, false, Parity, "");
            IO.Configs_Write(FileName, "StopBits", 2, false, StopBits, "");
            IO.Configs_Write(FileName, "IgnoreBuildNumberMismatch", 1, IgnoreBuildNumberMismatch, 0, "");
            IO.Configs_Write(FileName, "LogLevel", 2, false, LogLevel, "");
            IO.Configs_Write(FileName, "SaveMode", 2, false, SaveMode, "");
            IO.Configs_Write(FileName, "FlashSavePath", 3, false, 0, FlashSavePath);
            IO.Configs_Write(FileName, "FlashOpenPath", 3, false, 0, FlashOpenPath);
            IO.Configs_Write(FileName, "E2promSavePath", 3, false, 0, E2promSavePath);
            IO.Configs_Write(FileName, "E2promOpenPath", 3, false, 0, E2promOpenPath);

            Log("Config Saved", 0);

        }

        //*******************************************************************************************************//

        private void TabFlashWRSet(bool E)
        {
            switch (E)
            {
                case false:
                    ckb_auto_reset_after_write_flash.Enabled = false;
                    ckb_auto_reset_after_read_flash.Enabled = false;
                    ckb_lock_app_write_after_write_flash.Enabled = false;
                    ckb_lock_app_read_after_read_flash.Enabled=false;
                    ckb_erase_flash_before_write_flash.Enabled = false;
                    ckb_erase_e2prom_before_write_flash.Enabled = false;
                    ckb_verify_after_flash_write.Enabled = false;
                    ckb_ignore_lockbits_while_write_flash.Enabled = false;
                    cmb_file_type_flash.Enabled = false;
                    break;
                case true:
                    ckb_auto_reset_after_write_flash.Enabled = true;
                    ckb_auto_reset_after_read_flash.Enabled = true;
                    ckb_lock_app_write_after_write_flash.Enabled = true;
                    ckb_lock_app_read_after_read_flash.Enabled = true;
                    ckb_erase_flash_before_write_flash.Enabled = true;
                    ckb_erase_e2prom_before_write_flash.Enabled = true;
                    ckb_verify_after_flash_write.Enabled = true;
                    ckb_ignore_lockbits_while_write_flash.Enabled = true;
                    cmb_file_type_flash.Enabled = true;
                    break;
            }
        }

        private void TabE2promWRSet(bool E)
        {
            switch(E)
            {
                case false:
                    ckb_auto_reset_after_e2prom_write.Enabled = false;
                    ckb_auto_reset_after_e2prom_read.Enabled = false;
                    ckb_erase_e2prom_before_write_e2prom.Enabled = false;
                    cmb_file_type_e2prom.Enabled = false;
                    ckb_ignore_0xFF_for_e2prom_erase.Enabled = false;
                    ckb_ignore_0xFF_for_e2prom_read.Enabled = false;
                    ckb_ignore_oxFF_for_e2prom_write.Enabled= false;
                    break;
                case true:
                    ckb_auto_reset_after_e2prom_write.Enabled = true;
                    ckb_auto_reset_after_e2prom_read.Enabled = true;
                    ckb_erase_e2prom_before_write_e2prom.Enabled = true;
                    cmb_file_type_e2prom.Enabled = true;
                    ckb_ignore_0xFF_for_e2prom_erase.Enabled = true;
                    ckb_ignore_0xFF_for_e2prom_read.Enabled = true;
                    ckb_ignore_oxFF_for_e2prom_write.Enabled = true;
                    break;
            }
        }

        private void TabConnectSet(bool E)
        {
            switch (E)
            {
                case false:
                    cmb_port.Enabled = false;
                    cmb_baudrate.Enabled = false;
                    cmb_timeout.Enabled = false;
                    cmb_stopbits.Enabled = false;
                    cmb_parity.Enabled = false;
                    ckb_ignore_buildnumber.Enabled = false;
                    break;
                case true:
                    cmb_port.Enabled = true;
                    cmb_baudrate.Enabled = true;
                    cmb_timeout.Enabled = true;
                    cmb_stopbits.Enabled = true;
                    cmb_parity.Enabled = true;
                    ckb_ignore_buildnumber.Enabled = true;
                    break;
            }
        }

        private void TabLogsSet(bool E)
        {
            switch(E)
            {
                case false:
                    cmb_log_level.Enabled = false;
                    btn_clear_logs.Enabled = false;
                    btn_save_log_to_file.Enabled = false;
                    break;
                case true:
                    cmb_log_level.Enabled = true;
                    btn_clear_logs.Enabled = true;
                    btn_save_log_to_file.Enabled = true;
                    break;
            }
        }

        private void TabBackupRestoreSet(bool E)
        {
            switch(E)
            {
                case false:
                    btn_import_settings.Enabled = false;
                    btn_restore_default_settings.Enabled = false;
                    btn_export_settings.Enabled = false;
                    cmb_save_mode_settings.Enabled = false;
                    break;
                case true:
                    btn_import_settings.Enabled = true;
                    btn_restore_default_settings.Enabled = true;
                    btn_export_settings.Enabled = true;
                    cmb_save_mode_settings.Enabled = true;
                    break;
            }
        }

        private void OperationsSet(bool E)
        {
            switch(E)
            {
                case false:
                    btn_fuse_read.Enabled = false;
                    btn_lock_read.Enabled = false;
                    btn_lock_write.Enabled = false;
                    ckb_bootlockbit_app_read.Enabled = false;
                    ckb_bootlockbit_app_write.Enabled = false;
                    ckb_bootlockbit_boot_read.Enabled = false;
                    ckb_bootlockbit_boot_write.Enabled = false;
                    ckb_bootlockbit_app_read.Checked = false;
                    ckb_bootlockbit_app_write.Checked = false;
                    ckb_bootlockbit_boot_read.Checked = false;
                    ckb_bootlockbit_boot_write.Checked = false;
                    btn_flash_erase.Enabled = false;
                    btn_flash_read.Enabled = false;
                    btn_flash_write.Enabled = false;
                    btn_flash_verify.Enabled = false;
                    btn_eeprom_read.Enabled = false;
                    btn_eeprom_write.Enabled = false;
                    btn_eeprom_verify.Enabled = false;
                    btn_eeprom_erase.Enabled = false;
                    btn_reset_app.Enabled = false;
                    btn_sleep.Enabled = false;
                    btn_connect.Enabled = true;
                    break;
                case true:
                    btn_fuse_read.Enabled = true;
                    btn_lock_read.Enabled = true;
                    btn_flash_erase.Enabled = true;
                    btn_eeprom_erase.Enabled = true;
                    if (txt_save_path_flash.Text != "")
                    {
                        btn_flash_read.Enabled = true;
                    }
                    if (txt_open_path_flash.Text != "")
                    {
                        btn_flash_write.Enabled = true;
                        btn_flash_verify.Enabled = true;
                    }
                    if (txt_save_path_eeprom.Text != "")
                    {
                        btn_eeprom_read.Enabled = true;
                    }
                    if (txt_open_path_eeprom.Text != "")
                    {
                        btn_eeprom_write.Enabled = true;
                        btn_eeprom_verify.Enabled = true;
                    }
                    btn_reset_app.Enabled = true;
                    btn_sleep.Enabled = true;
                    btn_connect.Enabled = false;
                    break;
            }
        }

        //*******************************************************************************************************//

        private void btn_lock_read_Click(object sender, EventArgs e)
        {
            byte blockb = 0;
            int ErrorCode = 0;
            
            if(!Start())
            {
                status(0);
                return;
            }

            Log("Reading LockBits ...", 0);
            ErrorCode = LockBitsR(out blockb);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From LockBits Read !", 0);
                status(0);
                return;
            }
            Log("LockBits Read Done", 1);
                bool[] BLbool = new bool[8];
                IO.BytetoBoolArray(blockb, out BLbool);

            if (!BLbool[0] && BLbool[1])
            {
                ckb_lockbit_write.Checked = true;
                ckb_lockbit_read_write.Checked = false;
            }
            else if (!BLbool[0] && !BLbool[1])
            {
                ckb_lockbit_read_write.Checked = true;
                ckb_lockbit_write.Checked = false;
            }
                
            ckb_bootlockbit_app_write.Checked = !BLbool[2];
            ckb_bootlockbit_app_write.Enabled =  BLbool[2];
             
            ckb_bootlockbit_app_read.Checked = !BLbool[3];
            ckb_bootlockbit_app_read.Enabled =  BLbool[3];
                
            ckb_bootlockbit_boot_write.Checked = !BLbool[4];
            ckb_bootlockbit_boot_write.Enabled =  BLbool[4];
                
            ckb_bootlockbit_boot_read.Checked = !BLbool[5];
            ckb_bootlockbit_boot_read.Enabled =  BLbool[5];

            btn_lock_write.Enabled = true;

            com.Close();
            Log("LockBits Read Operation Done", 0);
            status(2);
        }

        private void btn_bootlock_write_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            if (!Start())
            {
                status(0);
                return;
            }

            bool BLB01t = !ckb_bootlockbit_app_write.Checked;
            bool BLB02t = !ckb_bootlockbit_app_read.Checked;
            bool BLB11t = !ckb_bootlockbit_boot_write.Checked;
            bool BLB12t = !ckb_bootlockbit_boot_read.Checked;

            ckb_bootlockbit_app_write.Checked = !BLB01t;
            ckb_bootlockbit_app_read.Checked = !BLB02t;
            ckb_bootlockbit_boot_write.Checked = !BLB11t;
            ckb_bootlockbit_boot_read.Checked = !BLB12t;

            Log("Writing To LockBits ...", 0);
            ErrorCode = LockBitsW(BLB01t, BLB02t, BLB11t, BLB12t);
            if (ErrorCode == 0)
            {
                ckb_bootlockbit_app_write.Enabled = BLB01t;
                ckb_bootlockbit_app_read.Enabled = BLB02t;
                ckb_bootlockbit_boot_write.Enabled = BLB11t;
                ckb_bootlockbit_boot_read.Enabled = BLB12t;
                com.Close();
                Log("LockBits Write Successful", 1);
                status(2);
            }
            else
            {
                ckb_bootlockbit_app_write.Enabled = false;
                ckb_bootlockbit_app_read.Enabled = false;
                ckb_bootlockbit_boot_write.Enabled = false;
                ckb_bootlockbit_boot_read.Enabled = false;
                btn_lock_write.Enabled = false;
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
                status(0);
                return;
            }

            Log("LockBits Write Operation Done", 0);
        }

        private void btn_flash_verify_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;
            string ErrorStr = "";

            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            if(!ckb_ignore_lockbits_while_write_flash.Checked)
            {
                byte LB = 0;

                Log("Reading LockBits ...", 1);
                if (LockBitsR(out LB) != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                if ((LB & 0b1000) == 0)
                {
                    com.Close();
                    Log("Chip Is Protected From Reading !", 0);
                    status(0);
                    return;
                }
                Log("LockBits OK For Reading", 0);
            }

            byte[] Hex = File.ReadAllBytes(txt_open_path_flash.Text);
            byte[] Bt_Src = new byte[PageNumber * PageSize];
            int CurrentRecord = 0;
            int CurrentPage = 0;
            int CurrentByte = 0;
            int End = 0;
            byte[] EndChars = new byte[2];
            bool Verify = false;

            Log("Converting Hex To Binary ...", 0);
            ErrorStr = IO.HexToByteArray(in Hex, ref Bt_Src, out CurrentRecord, out End);
            if (ErrorStr != "No Error")
            {
                com.Close();
                Log("Error (" + ErrorStr + ") From Hex Read !", 0);
                status(0);
                return;
            }
            Log("Hex To Bin Converted", 0);

            Log("Verifying Flash ...", 0);
            ErrorCode = FlashVerify(Bt_Src, ref CurrentPage, ref CurrentByte, out Verify);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Flash Verify In Page " + CurrentPage.ToString(), 0);
                status(0);
                return;
            }
            else if(!Verify)
            {
                com.Close();
                Log("Verification Failed From Flash Verify In Page " + CurrentPage.ToString() + " And Byte " + CurrentByte.ToString(), 0);
                status(1);
                return;
            }
            Log("Verification Done", 0);

            if (ckb_lock_app_read_after_read_flash.Checked)
            {
                btn_lock_write.Enabled = false;

                bool[] BLBS = new bool[8];
                byte BLB;

                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out BLB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                IO.BytetoBoolArray(BLB, out BLBS);

                Log("Writing To Read LockBit ...", 0);
                ErrorCode = LockBitsW(BLBS[2], false, BLBS[4], BLBS[5]);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
                    status(0);
                    return;
                }
                Log("MCU Is Now Protected From Reading !", 0);
            }

            if (ckb_auto_reset_after_read_flash.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App ", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("Flash Verify Operation Done", 0);
            status(2);
        }

        private void btn_save_eeprom_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveEepromDialog = new SaveFileDialog();
            if(cmb_file_type_e2prom.SelectedIndex == 0)
            {
                SaveEepromDialog.Filter = "eeprom File|*.mhd";
            }

            if (SaveEepromDialog.ShowDialog() == DialogResult.OK)
            {
                txt_save_path_eeprom.Text = SaveEepromDialog.FileName;
                if (is_MCU_identified)
                {
                    btn_eeprom_read.Enabled = true;
                }
                Log("eeprom Save Location : " + SaveEepromDialog.FileName, 0);
            }
        }

        private void btn_open_eeprom_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenEepromDialog = new OpenFileDialog();
            if (cmb_file_type_e2prom.SelectedIndex == 0)
            {
                OpenEepromDialog.Filter = "eeprom File|*.mhd";
            }

            if (OpenEepromDialog.ShowDialog() == DialogResult.OK)
            {
                txt_open_path_eeprom.Text = OpenEepromDialog .FileName;
                if (is_MCU_identified)
                {
                    btn_eeprom_write.Enabled = true;
                    btn_eeprom_verify.Enabled = true;
                }
                Log("eeprom Load Location : " + OpenEepromDialog.FileName, 0);
            }
        }

        private void btn_save_flash_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFlashDialog = new SaveFileDialog();
            if (cmb_file_type_flash.SelectedIndex == 0)
            {
                SaveFlashDialog.Filter = "flash File|*.hex";
            }

            if (SaveFlashDialog.ShowDialog() == DialogResult.OK)
            {
                txt_save_path_flash.Text = SaveFlashDialog.FileName;
                if (is_MCU_identified)
                {
                    btn_flash_read.Enabled = true;
                }
                Log("flash Save Location : " + SaveFlashDialog.FileName, 0);
            }
        }

        private void btn_open_flash_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFlashDialog = new OpenFileDialog();
            if (cmb_file_type_flash.SelectedIndex == 0)
            {
                OpenFlashDialog.Filter = "flash File|*.hex";
            }

            if (OpenFlashDialog.ShowDialog() == DialogResult.OK)
            {
                txt_open_path_flash.Text = OpenFlashDialog.FileName;
                if (is_MCU_identified)
                {
                    btn_flash_write.Enabled = true;
                    btn_flash_verify.Enabled = true;
                }
                Log("flash Load Location : " + OpenFlashDialog.FileName, 0);
            }
        }

        private void btn_reset_app_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            if (!Start())
            {
                status(0);
                return;
            }

            Log("Request App Reset Action ...", 0);
            ErrorCode = ResetToApp();
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Reset To App", 0);
                status(0);
                return;
            }
            Log("App Reset Done", 0);

            btn_connect.Enabled = true;

            OperationsSet(false);
            TabFlashWRSet(false);
            TabE2promWRSet(false);
            TabConnectSet(true);
            tab_settings.SelectedIndex = 2;
            McuModelSet("None");
            is_MCU_identified = false;
            lbl_mcu.Text = "";

            com.Close();
            Log("Reset Operation Done", 0);
            status(2);
        }

        private void btn_sleep_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            if (!Start())
            {
                status(0);
                return;
            }

            Log("Request Sleep Mode ...", 0);
            ErrorCode = Sleep();
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error" + ErrorCode.ToString() + " From Sleep Enter", 0);
                status(0);
                return;
            }
            Log("Sleep Mode Enter Done", 0);

            btn_connect.Enabled = true;

            OperationsSet(false);
            TabFlashWRSet(false);
            TabE2promWRSet(false);
            TabConnectSet(true);
            tab_settings.SelectedIndex = 2;
            McuModelSet("None");
            is_MCU_identified = false;
            lbl_mcu.Text = "";

            com.Close();
            Log("Sleep Operation Done", 0);
            status(2);
        }

        private void btn_flash_read_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            byte[] Bt = new byte[PageNumber * PageSize];
            byte[] Hex;
            int ErrorCode = 0;
            int CurrentPage = 0;

            if (!ckb_ignore_lockbits_while_write_flash.Checked)
            {
                byte LB = 0;

                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out LB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                if ((LB & 0b1000) == 0)
                {
                    com.Close();
                    Log("Chip Is Protected From Reading !", 0);
                    status(0);
                    return;
                }
                Log("LockBits OK For Reading", 0);
            }
            else Log("LockBits Ignored !", 0);

            Log("Reading Flash ...", 0);
            ErrorCode = FlashRead(ref Bt, ref CurrentPage);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Flash Read In Page " + CurrentPage.ToString(), 0);
                status(0);
                return;
            }
            Log("Flash Read Done", 0);

            IO.ByteArrayToHex(Bt, out Hex);
            File.WriteAllBytes(txt_save_path_flash.Text, Hex);

            if (ckb_lock_app_read_after_read_flash.Checked)
            {
                btn_lock_write.Enabled = false;

                bool[] BLBS = new bool[8];
                byte BLB;

                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out BLB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                IO.BytetoBoolArray(BLB, out BLBS);

                Log("Writing To Read LockBit ...", 0);
                ErrorCode = LockBitsW(BLBS[2], false, BLBS[4], BLBS[5]);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
                    status(0);
                    return;
                }
                Log("MCU Is Now Protected From Reading !", 0);
            }

            if (ckb_auto_reset_after_read_flash.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App ", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("Flash Read Operation Done", 0);
            status(2);
        }

        private void btn_eeprom_read_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            int ErrorCode = 0;
            byte[] ByteArr = new byte[E2promSize];
            byte[] MhdArr;

            Log("Reading E2prom ...", 0);
            ErrorCode = E2promRead(ref ByteArr);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From E2prom Read !", 0);
                status(0);
                return;
            }
            Log("E2prom Read Done", 0);

            IO.ByteArrayToMhd(in ByteArr, out MhdArr, ckb_ignore_0xFF_for_e2prom_read.Checked);

            File.WriteAllBytes(txt_save_path_eeprom.Text, MhdArr);

            if (ckb_auto_reset_after_e2prom_read.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App ", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("E2prom Read Operation Done", 0);
            status(2);
        }

        private void btn_eeprom_write_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            int ErrorCode = 0;
            string ErrorStr = "";
            byte[] ByteArr = new byte[E2promSize];
            byte[] MhdArr = File.ReadAllBytes(txt_open_path_eeprom.Text);
            int CurrentAddress = 0;

            Log("Converting From Mhd To Binary ...", 0);
            ErrorStr = IO.MhdToByteArray(in MhdArr, ref ByteArr);
            if (ErrorStr != "No Error")
            {
                com.Close();
                Log("Error (" + ErrorStr + ") From Mhd File Read !", 0);
                status(0);
                return;
            }
            Log("Convert From Mhd To Bin Done", 0);

            if (ckb_erase_e2prom_before_write_e2prom.Checked)
            {
                Log("Erasing E2prom Before Write To It ...", 0);
                ErrorCode = E2promErase(ref CurrentAddress, ckb_ignore_0xFF_for_e2prom_erase.Checked);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Erase E2prom In Byte " + CurrentAddress.ToString(), 0);
                    status(0);
                    return;
                }
                Log("E2prom Erase Done", 0);
            }
            else Log("E2prom Erase Before Write Not Selected !", 0);

            Log("Writing To E2prom ...", 0);
            ErrorCode = E2promWrite(in ByteArr,ref CurrentAddress, ckb_ignore_oxFF_for_e2prom_write.Checked);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From E2prom Write in Address " + CurrentAddress.ToString(), 0);
                status(0);
                return;
            }
            Log("E2prom Write Done", 0);

            if (ckb_auto_reset_after_e2prom_write.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("E2prom Write Operation Done", 0);
            status(2);
        }

        private void btn_eeprom_erase_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            int ErrorCode = 0;
            int CurrentByte = 0;

            Log("Erasing E2prom ...", 0);
            ErrorCode = E2promErase(ref CurrentByte, ckb_ignore_0xFF_for_e2prom_erase.Checked);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From E2prom Erase In Byte " + CurrentByte.ToString(), 0);
                status(0);
                return;
            }
            Log("E2prom Erase Done", 0);

            if (ckb_auto_reset_after_e2prom_write.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App ", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("E2prom Erase Operation Done", 0);
            status(2);
        }

        private void btn_flash_erase_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            int CurrentPage = 0;
            int ErrorCode = 0;

            if(!ckb_ignore_lockbits_while_write_flash.Checked)
            {
                byte LB = 0;

                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out LB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                if ((LB & 0b100) == 0)
                {
                    Log("Chip Is Protected From Writing !", 0);
                    com.Close();
                    status(0);
                    return;
                }
                Log("LockBits OK For Writing", 0);
            }

            Log("Erasing Flash ...", 0);
            ErrorCode = FlashErase(ref CurrentPage);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Erase Flash In Page " + CurrentPage.ToString(), 0);
                status(0);
                return;
            }
            Log("Flash Erase Done", 0);

            //if (ckb_lock_app_write_after_write_flash.Checked)
            //{
            //    btn_lock_write.Enabled = false;

            //    bool[] BLBS = new bool[8];
            //    byte BLB;

            //    Log("Reading LockBits ...", 1);
            //    ErrorCode = LockBitsR(out BLB);
            //    if (ErrorCode != 0)
            //    {
            //        com.Close();
            //        Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
            //        status(0);
            //        return;
            //    }
            //    Log("LockBits Read Done", 1);

            //    IO.BytetoBoolArray(BLB, out BLBS);

            //    Log("Writing To Write LockBit ...", 0);
            //    ErrorCode = LockBitsW(false, BLBS[3], BLBS[4], BLBS[5]);
            //    if (ErrorCode != 0)
            //    {
            //        com.Close();
            //        Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
            //        status(0);
            //        return;
            //    }
            //    Log("MCU Is Now Protected From Writing !", 0);
            //}

            com.Close();
            Log("Flash Erase Operation Done", 0);
            status(2);
        }

        private void btn_eeprom_verify_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if (!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            byte[] Mhd = File.ReadAllBytes(txt_open_path_eeprom.Text);
            byte[] Bt_Src = new byte[E2promSize];
            int ErrorCode = 0;
            string ErrorStr = "";
            int CurrentByte = 0;
            bool Verify = false;

            Log("Converting Mhd To Binary ...", 0);
            ErrorStr = IO.MhdToByteArray(in Mhd, ref Bt_Src);
            if (ErrorStr != "No Error")
            {
                com.Close();
                Log("Error (" + ErrorStr + ") From Mhd Read !", 0);
                status(0);
                return;
            }
            Log("Mhd To Bin Convert Done", 0);

            Log("Verifying E2prom ...", 0);
            ErrorCode = E2promVerify(Bt_Src, ref CurrentByte, out Verify);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From E2prom Verify In Address" + CurrentByte.ToString(), 0);
                status(0);
                return;
            }
            else if(!Verify)
            {
                com.Close();
                Log("Verification Failed From E2prom Verify In Byte " + CurrentByte.ToString(), 0);
                status(1);
                return;
            }
            Log("E2prom Verify Done", 0);

            if (ckb_auto_reset_after_e2prom_read.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("E2prom Verify Operation Done", 0);
            status(2);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            if (!Setting())
            {
                status(0);
                return;
            }

            if (!Start())
            {
                status(0);
                return;
            }

            string tmp = "";

            Log("Identifying ...", 0);
            ErrorCode = Identify(out tmp);
            if (ErrorCode == 0)
            {
                TabConnectSet(false);
                tab_settings.SelectedIndex = 0;
                OperationsSet(true);
                TabFlashWRSet(true);
                TabE2promWRSet(true);
                McuModelSet(tmp);
                is_MCU_identified = true;
                lbl_mcu.Text = tmp;
                com.Close();
                Log("Identification Complete", 0);
                status(2);

            }
            else
            {
                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "Error";
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Identification", 0);
                status(0);
                return;
            }

            Log("Identify Operation Done", 0);
        }

        private void btn_flash_write_Click(object sender, EventArgs e)
        {
            if (!Start())
            {
                status(0);
                return;
            }

            if(!FreeCheck())
            {
                com.Close();
                status(0);
                return;
            }

            int ErrorCode = 0;
            string ErrorStr = "";
            byte LB = 0;

            if (!ckb_ignore_lockbits_while_write_flash.Checked)
            {
                Log("Checking LockBits ...", 1);
                ErrorCode = LockBitsR(out LB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Successful", 1);

                if ((LB & 0b100) == 0)
                {
                    com.Close();
                    Log("Chip Is Protected From Writing !", 0);
                    status(0);
                    return;
                }
                Log("LockBits OK For Writing", 0);
            }
            else Log("Ignored LockBits !!!", 0);

            if (ckb_verify_after_flash_write.Checked && (!ckb_ignore_lockbits_while_write_flash.Checked))
            {
                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out LB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Successful", 1);

                if ((LB & 0b1000) == 0)
                {
                    com.Close();
                    Log("Chip Is Protected From Reading !", 0);
                    status(0);
                    return;
                }
                Log("LockBits OK For Reading ...", 0);
            }

            byte[,] Flash = new byte[PageNumber, PageSize];
            byte[] Bt = new byte[PageNumber * PageSize];
            byte[] Hex = File.ReadAllBytes(txt_open_path_flash.Text);

            int Record = 0;
            int End = 0;
            byte[] EndChars = new byte[2];

            Log("Converting Hex To Binary ...", 0);
            ErrorStr = IO.HexToByteArray(Hex, ref Bt, out Record, out End);
            if (ErrorStr != "No Error")
            {
                com.Close();
                Log("Error (" + ErrorStr + ") From Hex Read", 0);
                status(0);
                return;
            }
            Log("Hex To Bin Converted", 0);

            IO.ArrayToPages(Bt, ref Flash, PageNumber, PageSize);

            if (ckb_erase_e2prom_before_write_flash.Checked)
            {
                int CurrentByte = 0;

                Log("Erasing E2prom Before Flash Write ...", 0);
                ErrorCode = E2promErase(ref CurrentByte, ckb_ignore_0xFF_for_e2prom_erase.Checked);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Erase E2prom In Byte " + CurrentByte.ToString(), 0);
                    status(0);
                    return;
                }
                Log("E2prom Erase Done", 0);
            }
            else Log("E2prom Erase Disabled", 1);

            int CurrentPage = 0;

            if (ckb_erase_flash_before_write_flash.Checked)
            {
                CurrentPage = 0;

                Log("Erasing Flash Before Write To it ...", 0);
                ErrorCode = FlashErase(ref CurrentPage);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Erase Flash In Page " + CurrentPage.ToString(), 0);
                    status(0);
                    return;
                }
                Log("Flash Erase Successful", 0);
            }
            else Log("Flash Erase Not Selected !", 0);

            CurrentPage = 0;

            Log("Writing To Flash ...", 0);
            ErrorCode = FlashWrite(Flash,End,ref CurrentPage);
            if (ErrorCode != 0)
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From Write Flash In Page " + CurrentPage.ToString(), 0);
                status(0);
                return;
            }
            else Log("Flash Write Done", 0);

            if (ckb_verify_after_flash_write.Checked)
            {
                int CurrentByte = 0;
                bool Verify = false;

                Log("Verifying Flash ...", 0);
                ErrorCode = FlashVerify(Bt, ref CurrentPage, ref CurrentByte, out Verify);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Verify Flash In Page " + CurrentPage.ToString(), 0);
                    status(0);
                    return;
                }
                else if (!Verify)
                {
                    com.Close();
                    Log("Verification Failed From Flash Verify In Page " + CurrentPage.ToString() + " And Byte " + CurrentByte.ToString(), 0);
                    status(1);
                    return;
                }
                Log("Verification Done", 0);

                if (ckb_lock_app_read_after_read_flash.Checked)
                {
                    btn_lock_write.Enabled = false;

                    bool[] BLBS = new bool[8];
                    byte BLB;

                    Log("Reading LockBits ...", 1);
                    ErrorCode = LockBitsR(out BLB);
                    if (ErrorCode != 0)
                    {
                        com.Close();
                        Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                        status(0);
                        return;
                    }
                    Log("LockBits Read Done", 1);

                    IO.BytetoBoolArray(BLB, out BLBS);

                    Log("Writing To Read LockBit ...", 0);
                    ErrorCode = LockBitsW(BLBS[2], false, BLBS[4], BLBS[5]);
                    if (ErrorCode != 0)
                    {
                        com.Close();
                        Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
                        status(0);
                        return;
                    }
                    Log("MCU Is Now Protected From Writing", 0);
                }
                else Log("Lock App Read After Flash Read Not Selected", 1);
            }
            else Log("Verify After Write Flash Not Selected !", 0);

            if (ckb_lock_app_write_after_write_flash.Checked)
            {
                btn_lock_write.Enabled = false;

                bool[] BLBS = new bool[8];
                byte BLB;

                Log("Reading LockBits ...", 1);
                ErrorCode = LockBitsR(out BLB);
                if (ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Read", 0);
                    status(0);
                    return;
                }
                Log("LockBits Read Done", 1);

                IO.BytetoBoolArray(BLB, out BLBS);

                Log("Writing To Write LockBit ...", 0);
                ErrorCode = LockBitsW(false, BLBS[3], BLBS[4], BLBS[5]);
                if(ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From LockBits Write", 0);
                    status(0);
                    return;
                }
                Log("MCU Is Now Protected From Writing", 0);
            }
            else Log("Lock App Write After Flash Write Not Selected", 1);

            if (ckb_auto_reset_after_write_flash.Checked)
            {
                Log("Request Reset Action ...", 0);
                ErrorCode = ResetToApp();
                if(ErrorCode != 0)
                {
                    com.Close();
                    Log("Error " + ErrorCode.ToString() + " From Reset To App ", 0);
                    status(0);
                    return;
                }
                Log("Reset Done", 0);

                OperationsSet(false);
                TabFlashWRSet(false);
                TabE2promWRSet(false);
                TabConnectSet(true);
                tab_settings.SelectedIndex = 2;
                McuModelSet("None");
                is_MCU_identified = false;
                lbl_mcu.Text = "";
            }

            com.Close();
            Log("Flash Write Operation Done", 0);
            status(2);
        }

        private void btn_fuse_read_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            if (!Start())
            {
                status(0);
                return;
            }

            byte highf=0,lowf=0;

            Log("Reading FuseBits ...", 0);
            ErrorCode = FuseBits(out highf, out lowf);
            if (ErrorCode == 0)
            {
                bool[] Fhbool = new bool[8];
                bool[] Flbool = new bool[8];
                IO.BytetoBoolArray(highf, out Fhbool);
                IO.BytetoBoolArray(lowf, out Flbool);

                
                ckb_fusebit_h1.Checked = !Fhbool[0];
                ckb_fusebit_h2.Checked = !Fhbool[1];
                ckb_fusebit_h3.Checked = !Fhbool[2];
                ckb_fusebit_h4.Checked = !Fhbool[3];
                ckb_fusebit_h5.Checked = !Fhbool[4];
                ckb_fusebit_h6.Checked = !Fhbool[5];
                ckb_fusebit_h7.Checked = !Fhbool[6];
                ckb_fusebit_h8.Checked = !Fhbool[7];

                ckb_fusebit_l1.Checked = !Flbool[0];
                ckb_fusebit_l2.Checked = !Flbool[1];
                ckb_fusebit_l3.Checked = !Flbool[2];
                ckb_fusebit_l4.Checked = !Flbool[3];
                ckb_fusebit_l5.Checked = !Flbool[4];
                ckb_fusebit_l6.Checked = !Flbool[5];
                ckb_fusebit_l7.Checked = !Flbool[6];
                ckb_fusebit_l8.Checked = !Flbool[7];


                status(2);
            }
            else
            {
                com.Close();
                Log("Error " + ErrorCode.ToString() + " From FuseBits Read !", 0);
                status(0);
                return;
            }

            com.Close();
            Log("FuseBits Read Operation Done", 0);
            status(2);
        }

        public MainPage()
        {
            InitializeComponent(); 

            txt_log.AppendText("Mahdi Boot Loader Version " + Version + " (Build " + BuildNumber.ToString() + ")\r\n\r\n");
            string ErrorCode = Configs_Load(ConfigPath);
            if (ErrorCode != "Config Loaded")
            {
                MessageBox.Show("Error Loading Saved Configurations . Loading Defaults Instead ...");
                Config_Load_Default();
                Log("Config Error : " + ErrorCode,0);
            }

            tab_settings.SelectedIndex = 2;
        }

        private void btn_load_settings_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenConfig = new OpenFileDialog();
            OpenConfig.Filter = "Config File|*.cfg";
            if(OpenConfig.ShowDialog() == DialogResult.OK)
            {
                string ErrorCode = Configs_Load(OpenConfig.FileName);
                if (ErrorCode != "Config Loaded")
                {
                    MessageBox.Show("Failed To Load Config Files !\r\nLoading Default Settings Instead ...");
                    Config_Load_Default();
                    Log("Config Error : " + ErrorCode, 0);
                }
                else
                {
                    Log("Config Loaded Successfuly From : " + OpenConfig.FileName, 0);
                }
            }
        }

        private void btn_save_settings_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveConfig = new SaveFileDialog();
            SaveConfig.Filter = "Config File|*.cfg";
            if(SaveConfig.ShowDialog() == DialogResult.OK)
            {
                Configs_Save(SaveConfig.FileName);
                Log("Configs Saved In Path : " + SaveConfig.FileName, 0);
            }
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(cmb_save_mode_settings.SelectedIndex == 0)
            {
                Config_Load_Default();
                Configs_Save(ConfigPath);
            }
            else if(cmb_save_mode_settings.SelectedIndex == 2)
            Configs_Save(ConfigPath);
        }

        private void btn_restore_default_settings_Click(object sender, EventArgs e)
        {
            Config_Load_Default();
            Log("Default Values Loaded", 0);
        }

        private void btn_save_now_Click(object sender, EventArgs e)
        {
            if (cmb_save_mode_settings.SelectedIndex == 1)
                Configs_Save(ConfigPath);
        }

        private void btn_clear_logs_Click(object sender, EventArgs e)
        {
            txt_log.Text = "";
            txt_log.AppendText("Mahdi Boot Loader Version " + Version + " (Build " + BuildNumber.ToString() + ")\r\n\r\n");
            LogLine = 0;
        }

        private void btn_save_log_to_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveLog = new SaveFileDialog();
            SaveLog.Filter = "Log File|*.txt";
            if(SaveLog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SaveLog.FileName, txt_log.Text);
                Log("Log Saved In Path : " + SaveLog.FileName, 0);
            }
        }

        private void ckb_bootlockbit_app_read_Click(object sender, EventArgs e)
        {
            if (ckb_bootlockbit_app_read.Checked == true)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("After Apply This Lock You Wont Be Able To Read Or Verify Flash Section ! \nAre You Want To Continue ?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) ckb_bootlockbit_app_read.Checked = false;
            }
        }

        private void ckb_bootlockbit_app_write_Click(object sender, EventArgs e)
        {
            if (ckb_bootlockbit_app_write.Checked == true)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("After Apply This Lock You Wont Be Able To Write Or Erase Flash Section! \nAre You Want To Continue ?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) ckb_bootlockbit_app_write.Checked = false;
            }
        }

    }
}