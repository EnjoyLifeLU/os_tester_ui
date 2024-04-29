using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using os_tester_ui.Logger;
using TouchSocket.Core;

namespace os_tester_ui.Protocol
{
    public class GpibCore : Prot
    {
        public int Address { get; set; }
        public int Timeout { get; set; }
        public int BufSize { get; set; }

        private string msg;

        // TODO： 与日志类耦合，需要改进
        private FileLogger GpibLog = new FileLogger("logs\\gpiblog");

        public GpibCore(int address)
        {
            Address = address;
            Timeout = 2000;
            BufSize = 1024;
        }

        private int DefaultSessionId = 0;
        private int SessionId = 0;

        public override void Connect()
        {
            //Session Open
            int result = visa32.viOpenDefaultRM(out DefaultSessionId);
            if (result != 0)
            {
                msg = "Failed to viOpenDefaultRM.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }

            //Connection Open
            result = visa32.viOpen(DefaultSessionId,
                "GPIB0::" + this.Address.ToString() + "::INSTR", 0, 0, out SessionId);
            if (result != 0)
            {
                msg = "Failed to viOpen.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }

            //// Set the termination character to carriage return (i.e., 13);
            //visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR, 13);
            //// Set the flag to terminate when receiving a termination character
            //visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR_EN, 1);
            // Set timeout in milliseconds; set the timeout for your requirements
            result = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TMO_VALUE, Timeout);
            if (result != 0)
            {
                msg = "Failed to set timeout.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }
        }

        public override void Close()
        {
            int result = visa32.viClose(SessionId);

            if (result != 0)
            {
                msg = "Failed to Close.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }
        }

        public override void Send(string Command)
        {
            //Communication
            int result = visa32.viPrintf(SessionId, Command + "\n");

            if (result != 0)
            {
                msg = "Failed to Send.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }
        }

        public override string Read()
        {
            string buffer;

            int result = visa32.viRead(SessionId, out buffer, BufSize);

            if (result != 0)
            {
                msg = "Failed to Read.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }

            return buffer;
        }

        public short ReadSTB()
        {
            short status = 0; // 用于存储状态字节的变量

            // 调用 viReadSTB 函数读取状态字节
            int result = visa32.viReadSTB(SessionId, ref status);

            if (result != 0)
            {
                msg = "Failed to read status byte.";
                GpibLog.Error(msg);
                throw new InvalidOperationException(msg);
            }

            return status;
        }
    }
}
