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
        void Connect();
        void Close();
        void Send(string Command);
        string Read();
    }
}
