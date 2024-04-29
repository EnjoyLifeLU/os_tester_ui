using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using os_tester_ui.Resouce;
using os_tester_ui.Data;

namespace os_tester_ui
{
    public partial class MPSetupForm : Form
    {
        private SiteData site1;
        private SiteData site2;
        private SiteData site3;
        private SiteData site4;
        private SiteData site5;
        private SiteData site6;
        private SiteData site7;
        private SiteData site8;

        public MPSetupForm(MainForm mainForm)
        {
            InitializeComponent();

            this.site1 = mainForm.site1;
            this.site2 = mainForm.site2;
            this.site3 = mainForm.site3;
            this.site4 = mainForm.site4;
            this.site5 = mainForm.site5;
            this.site6 = mainForm.site6;
            this.site7 = mainForm.site7;
            this.site8 = mainForm.site8;

            button1.ForeColor = (site1.Status == TestStatus.On) ? Color.Green : Color.Red;
            button2.ForeColor = (site2.Status == TestStatus.On) ? Color.Green : Color.Red;
            button3.ForeColor = (site3.Status == TestStatus.On) ? Color.Green : Color.Red;
            button4.ForeColor = (site4.Status == TestStatus.On) ? Color.Green : Color.Red;
            button5.ForeColor = (site5.Status == TestStatus.On) ? Color.Green : Color.Red;
            button6.ForeColor = (site6.Status == TestStatus.On) ? Color.Green : Color.Red;
            button7.ForeColor = (site7.Status == TestStatus.On) ? Color.Green : Color.Red;
            button8.ForeColor = (site8.Status == TestStatus.On) ? Color.Green : Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.ForeColor == Color.Green)
            {
                button1.ForeColor = Color.Red;
            }
            else
            {
                button1.ForeColor = Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.ForeColor == Color.Green)
            {
                button2.ForeColor = Color.Red;
            }
            else
            {
                button2.ForeColor = Color.Green;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.ForeColor == Color.Green)
            {
                button3.ForeColor = Color.Red;
            }
            else
            {
                button3.ForeColor = Color.Green;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.ForeColor == Color.Green)
            {
                button4.ForeColor = Color.Red;
            }
            else
            {
                button4.ForeColor = Color.Green;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.ForeColor == Color.Green)
            {
                button5.ForeColor = Color.Red;
            }
            else
            {
                button5.ForeColor = Color.Green;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.ForeColor == Color.Green)
            {
                button6.ForeColor = Color.Red;
            }
            else
            {
                button6.ForeColor = Color.Green;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.ForeColor == Color.Green)
            {
                button7.ForeColor = Color.Red;
            }
            else
            {
                button7.ForeColor = Color.Green;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.ForeColor == Color.Green)
            {
                button8.ForeColor = Color.Red;
            }
            else
            {
                button8.ForeColor = Color.Green;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Green;
            button2.ForeColor = Color.Green;
            button3.ForeColor = Color.Green;
            button4.ForeColor = Color.Green;
            button5.ForeColor = Color.Green;
            button6.ForeColor = Color.Green;
            button7.ForeColor = Color.Green;
            button8.ForeColor = Color.Green;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
            button2.ForeColor = Color.Red;
            button3.ForeColor = Color.Red;
            button4.ForeColor = Color.Red;
            button5.ForeColor = Color.Red;
            button6.ForeColor = Color.Red;
            button7.ForeColor = Color.Red;
            button8.ForeColor = Color.Red;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.site1.Status = (button1.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site2.Status = (button2.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site3.Status = (button3.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site4.Status = (button4.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site5.Status = (button5.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site6.Status = (button6.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site7.Status = (button7.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;
            this.site8.Status = (button8.ForeColor == Color.Green) ? TestStatus.On : TestStatus.Off;

            this.Close();
        }
    }
}
