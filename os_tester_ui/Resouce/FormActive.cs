using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace os_tester_ui.Resouce
{
    public class FormActive
    {
        public static void ShowContextMenuStrip(MainForm form, ContextMenuStrip contextMenuStrip)
        {
            // 获取鼠标点击位置
            Point point = form.PointToClient(Control.MousePosition);

            // 在点击位置显示 ContextMenuStrip
            contextMenuStrip.Show(form, point);
        }
    }
}
