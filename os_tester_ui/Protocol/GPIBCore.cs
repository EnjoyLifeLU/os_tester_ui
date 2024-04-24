using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Protocol
{
    public class GpibCore : IGpib
    {
        private static int DefaultSessionId = 0;
        private static int SessionId = 0;

        public static int Connect(int Address)
        {
            int LastStatus = 0;

            //Session Open
            LastStatus = visa32.viOpenDefaultRM(out DefaultSessionId);

            //Connection Open
            LastStatus = visa32.viOpen(DefaultSessionId,
                "GPIB::" + Address.ToString() + "::INSTR", 0, 0, out SessionId);

            // Set the termination character to carriage return (i.e., 13);
            LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR, 13);
            // Set the flag to terminate when receiving a termination character
            LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR_EN, 1);
            // Set timeout in milliseconds; set the timeout for your requirements
            LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TMO_VALUE, 2000);

            return SessionId;
        }

        public static void Close()
        {
            visa32.viClose(SessionId);
            visa32.viClose(DefaultSessionId);
        }

        public static int Send(string Command)
        {
            int LastStatus = 0;

            //Communication
            LastStatus = visa32.viPrintf(SessionId, Command + "\n");//device specific commands to write
            StringBuilder message = new StringBuilder(2048);
            LastStatus = visa32.viScanf(SessionId, "%2048t", message);//Readback

            return LastStatus;
        }

        public static int Read(string Command, out string Buf)
        {
            int LastStatus = 0;

            //Communication
            LastStatus = visa32.viRead(SessionId, out Buf, 1024);//device specific commands to write

            return LastStatus;
        }
    }
}
