using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Protocol
{
    public abstract class Prot : IPort
    {
        public abstract void Connect();
        public abstract void Close();
        public abstract void Send(string Command);
        public abstract string Read();
    }
}
