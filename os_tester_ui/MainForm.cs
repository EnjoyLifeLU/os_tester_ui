using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using os_tester_ui.Data;
using os_tester_ui.DB;
using os_tester_ui.Logger;
using os_tester_ui.Protocol;
using os_tester_ui.Resouce;

namespace os_tester_ui
{
    public partial class MainForm : Form
    {
        FileLogger logger = new FileLogger("logs\\uilog");
        GpibCore gpibConn = new GpibCore(5);

        SiteData site1 = new SiteData();
        SiteData site2 = new SiteData();
        SiteData site3 = new SiteData();
        SiteData site4 = new SiteData();
        SiteData site5 = new SiteData();
        SiteData site6 = new SiteData();
        SiteData site7 = new SiteData();
        SiteData site8 = new SiteData();

        public MainForm()
        {
            InitializeComponent();

            btnSiteBk1.DataBindings.Add("BackColor", site1, "StatusColor");
            btnSiteBk2.DataBindings.Add("BackColor", site2, "StatusColor");
            btnSiteBk3.DataBindings.Add("BackColor", site3, "StatusColor");
            btnSiteBk4.DataBindings.Add("BackColor", site4, "StatusColor");
            btnSiteBk5.DataBindings.Add("BackColor", site5, "StatusColor");
            btnSiteBk6.DataBindings.Add("BackColor", site6, "StatusColor");
            btnSiteBk7.DataBindings.Add("BackColor", site7, "StatusColor");
            btnSiteBk8.DataBindings.Add("BackColor", site8, "StatusColor");

            btnSiteBk1.DataBindings.Add("Text", site1, "BinText");
            btnSiteBk2.DataBindings.Add("Text", site2, "BinText");
            btnSiteBk3.DataBindings.Add("Text", site3, "BinText");
            btnSiteBk4.DataBindings.Add("Text", site4, "BinText");
            btnSiteBk5.DataBindings.Add("Text", site5, "BinText");
            btnSiteBk6.DataBindings.Add("Text", site6, "BinText");
            btnSiteBk7.DataBindings.Add("Text", site7, "BinText");
            btnSiteBk8.DataBindings.Add("Text", site8, "BinText");

            site1.Status = TestStatus.On;
            site2.Status = TestStatus.On;
            site3.Status = TestStatus.Off;
            site4.Status = TestStatus.Off;
            site5.Status = TestStatus.Off;
            site6.Status = TestStatus.Off;
            site7.Status = TestStatus.Off;
            site8.Status = TestStatus.Off;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit the program?", "system information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // 取消关闭事件
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            site1.SBin = SoftBin.Bin1;
            site2.Result = TestResult.NoTest;
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            PwdForm pwdForm = new PwdForm();
            pwdForm.StartPosition = FormStartPosition.Manual;
            pwdForm.Location = new Point(
                this.Location.X + (this.Width - pwdForm.Width) / 2,
                this.Location.Y + (this.Height - pwdForm.Height) / 2);
            pwdForm.ShowDialog();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            logger.Info("Info");

            //var con = new SQLiteHelper("TestSqlite.sqlite");//创建连接
            //var result = con.GetSqlResult("SELECT SQLITE_VERSION()");
            //MessageBox.Show(result); 
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                gpibConn.Connect();
                short sqr = gpibConn.ReadSTB();
                MessageBox.Show(sqr.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnMPActive_Click(object sender, EventArgs e)
        {
            MPSetupForm mpSetupForm = new MPSetupForm();
            mpSetupForm.StartPosition = FormStartPosition.Manual;
            mpSetupForm.Location = new Point(
                this.Location.X + (this.Width - mpSetupForm.Width) / 2,
                this.Location.Y + (this.Height - mpSetupForm.Height) / 2);
            mpSetupForm.ShowDialog();
        }

        private void btnSite1_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite2_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite3_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite4_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite5_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite6_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite7_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void btnSite8_Click(object sender, EventArgs e)
        {
            FormActive.ShowContextMenuStrip(this, contextMenuStrip1);
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option Check selected");
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option Log selected");
        }
    }
}
