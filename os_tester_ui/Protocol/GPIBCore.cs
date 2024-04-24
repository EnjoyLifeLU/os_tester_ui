using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Protocol
{
    public class GpibCore : Prot
    {
        public int Address { get; set; }

        public GpibCore(int address)
        {
            Address = address;
        }

        private int DefaultSessionId = 0;
        private int SessionId = 0;

        public override int Connect()
        {
            int status = 0;

            //Session Open
            status = visa32.viOpenDefaultRM(out DefaultSessionId);

            //Connection Open
            status = visa32.viOpen(DefaultSessionId,
                "GPIB::" + this.Address.ToString() + "::INSTR", 0, 0, out SessionId);

            // Set the termination character to carriage return (i.e., 13);
            status = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR, 13);
            // Set the flag to terminate when receiving a termination character
            status = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR_EN, 1);
            // Set timeout in milliseconds; set the timeout for your requirements
            status = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TMO_VALUE, 2000);

            return status;
        }

        public override void Close()
        {
            visa32.viClose(SessionId);
        }

        public override int Send(string Command)
        {
            int status = 0;

            //Communication
            status = visa32.viPrintf(SessionId, Command + "\n");//device specific commands to write
            StringBuilder message = new StringBuilder(2048);
            status = visa32.viScanf(SessionId, "%2048t", message);//Readback

            return status;
        }

        public override int Read(string Command, out string Buf)
        {
            int status = 0;

            //Communication
            status = visa32.viRead(SessionId, out Buf, 1024);//device specific commands to write

            return status;
        }
    }
}
