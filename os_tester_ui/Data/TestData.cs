using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Data
{
    public class TestData : DataBinding
    {
        private int m_Total;
        private int m_Pass;
        private int m_Fail;

        public string TotalText { get; set; }
        public string PassText { get; set; }
        public string FailText { get; set; }

        public int Total
        {
            get { return m_Total; }
            set { m_Total = value; }
        }

        public int Pass
        {
            get { return m_Pass; }
            set
            {
                m_Pass = value;
                m_Total++;

                float PassRate = ((float)m_Pass / (float)m_Total * 100);
                float FailRate = ((float)m_Fail / (float)m_Total * 100);

                PassText = m_Pass.ToString() + "   " + String.Format("{0:0.00}%", PassRate);
                FailText = m_Fail.ToString() + "   " + String.Format("{0:0.00}%", FailRate);
                TotalText = m_Total.ToString();

                NotifyPropertyChanger("TotalText");
                NotifyPropertyChanger("PassText");
                NotifyPropertyChanger("FailText");
            }
        }

        public int Fail
        {
            get { return m_Fail; }
            set
            {
                m_Fail = value;
                m_Total++;

                float PassRate = ((float)m_Pass / (float)m_Total * 100);
                float FailRate = ((float)m_Fail / (float)m_Total * 100);

                PassText = m_Pass.ToString() + "   " + String.Format("{0:0.00}%", PassRate);
                FailText = m_Fail.ToString() + "   " + String.Format("{0:0.00}%", FailRate);
                TotalText = m_Total.ToString();

                NotifyPropertyChanger("TotalText");
                NotifyPropertyChanger("PassText");
                NotifyPropertyChanger("FailText");
            }
        }


        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanger(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
