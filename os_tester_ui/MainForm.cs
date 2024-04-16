using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace os_tester_ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            var con = new SQLiteHelper("TestSqlite.sqlite");//创建连接
            var version = con.GetSqlResult("SELECT SQLITE_VERSION()");
            MessageBox.Show("SQLite version:" + version); 
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
            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox1, btnSiteBk1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox2, btnSiteBk2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox3, btnSiteBk3);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox4, btnSiteBk4);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox5, btnSiteBk5);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox6, btnSiteBk6);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox7, btnSiteBk7);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            SiteOperationSettings(checkBox8, btnSiteBk8);
        }

        private void btnSite1_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite2_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite3_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite4_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite5_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite6_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite7_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void btnSite8_Click(object sender, EventArgs e)
        {
            ShowContextMenuStrip(sender, e);
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option Check selected");
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option Log selected");
        }

        private void SiteOperationSettings(CheckBox checkBox, Button button)
        {
            if (checkBox.Checked)
            {
                button.BackColor = Color.White;
            }
            else
            {
                button.BackColor = Color.Silver;
            }
        }

        private void ShowContextMenuStrip(object sender, EventArgs e)
        {
            // 获取鼠标点击位置
            Point point = this.PointToClient(Control.MousePosition);

            // 在点击位置显示 ContextMenuStrip
            contextMenuStrip1.Show(this, point);
        }
    }
}
