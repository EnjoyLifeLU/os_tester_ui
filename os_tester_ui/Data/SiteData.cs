using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace os_tester_ui.Data
{
    public class SiteData : DataBinding
    {
        private TestStatus m_Status;
        private TestResult m_Result = TestResult.NoTest;
        private HardBin m_HBin;
        private SoftBin m_SBin;

        private TestData m_TestData;
        public SiteData(TestData testData)
        {
            m_TestData = testData;
        }

        public Color StatusColor { get; private set; }
        public string BinText { get; private set; }

        public TestStatus Status
        {
            get { return m_Status; }
            set 
            {
                m_Status = value;
                //StatusColor = Status ? Color.White : Color.Silver;

                switch (m_Status)
                {
                    case TestStatus.On:
                        StatusColor = Color.White;
                        break;
                    case TestStatus.Off:
                        StatusColor = Color.DarkGray;
                        break;
                    default:
                        break;
                }

                NotifyPropertyChanger("StatusColor");
            }
        }

        public TestResult Result
        {
            get { return m_Result; }
            set
            {
                m_Result = value;
                //StatusColor = Status ? Color.White : Color.Silver;

                if (m_Status == TestStatus.On && m_Result == TestResult.NoTest)
                {
                    StatusColor = Color.LightGray;
                }
                else if (m_Status == TestStatus.On && m_Result == TestResult.Pass)
                {
                    StatusColor = Color.ForestGreen;
                    m_TestData.Pass += 1;
                }
                else if (m_Status == TestStatus.On && m_Result == TestResult.Fail)
                {
                    StatusColor = Color.Crimson;
                    m_TestData.Fail += 1;
                }
                else
                {
                    StatusColor = Color.DarkGray;
                }

                NotifyPropertyChanger("StatusColor");
            }
        }

        public HardBin HBin
        {
            get { return m_HBin; }
            set
            {
                m_HBin = value;

                if (m_HBin == HardBin.Bin1 && m_Status == TestStatus.On)
                {
                    BinText = "Bin1";
                    Result = TestResult.Pass;
                }
                else if (m_HBin == HardBin.Bin2 && m_Status == TestStatus.On)
                {
                    BinText = "Bin2";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin3 && m_Status == TestStatus.On)
                {
                    BinText = "Bin3";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin4 && m_Status == TestStatus.On)
                {
                    BinText = "Bin4";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin5 && m_Status == TestStatus.On)
                {
                    BinText = "Bin5";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin6 && m_Status == TestStatus.On)
                {
                    BinText = "Bin6";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin7 && m_Status == TestStatus.On)
                {
                    BinText = "Bin7";
                    Result = TestResult.Fail;
                }
                else if (m_HBin == HardBin.Bin8 && m_Status == TestStatus.On)
                {
                    BinText = "Bin8";
                    Result = TestResult.Fail;
                }
                else
                {
                    BinText = "";
                    Result = TestResult.NoTest;
                }

                NotifyPropertyChanger("BinText");
            }
        }

        public SoftBin SBin
        {
            get { return m_SBin; }
            set
            {
                m_SBin = value;

                switch (m_SBin)
                {
                    case SoftBin.Bin1:
                        HBin = HardBin.Bin1;
                        break;
                    case SoftBin.Bin2:
                        HBin = HardBin.Bin2;
                        break;
                    case SoftBin.Bin3:
                        HBin = HardBin.Bin3;
                        break;
                    case SoftBin.Bin4:
                        HBin = HardBin.Bin4;
                        break;
                    case SoftBin.Bin5:
                        HBin = HardBin.Bin5;
                        break;
                    case SoftBin.Bin6:
                        HBin = HardBin.Bin6;
                        break;
                    case SoftBin.Bin7:
                        HBin = HardBin.Bin7;
                        break;
                    case SoftBin.Bin8:
                        HBin = HardBin.Bin8;
                        break;
                    default:
                        HBin = HardBin.Bin1001;
                        break;
                }
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

    public enum TestStatus
    {
        On = 0,
        Off,
    }

    public enum TestResult
    {
        NoTest = 0,
        Pass,
        Fail
    }

    public enum HardBin
    {
        Bin1 = 1,
        Bin2,
        Bin3,
        Bin4,
        Bin5,
        Bin6,
        Bin7,
        Bin8,
        Bin1001
    }

    public enum SoftBin
    {
        Bin1 = 1,
        Bin2,
        Bin3,
        Bin4,
        Bin5,
        Bin6,
        Bin7,
        Bin8,
        Bin1001
    }
}
