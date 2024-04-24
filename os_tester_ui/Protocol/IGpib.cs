using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Protocol
{
    /// <summary>
    /// GPIB接口
    /// </summary>
    public interface IGpib
    {
        int Connect(int Address);
        void Close();
        int Send(string Command);
        int Read(string Command, out string Buf);
    }
}
