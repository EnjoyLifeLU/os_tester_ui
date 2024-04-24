using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Protocol
{
    /// <summary>
    /// Port接口
    /// </summary>
    public interface IPort
    {
        int Connect();
        void Close();
        int Send(string Command);
        int Read(string Command, out string Buf);
    }
}
