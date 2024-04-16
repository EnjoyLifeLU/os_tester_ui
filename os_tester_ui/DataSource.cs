using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace os_tester_ui
{
    class DataSource
    {
        public class AllSite
        {
            public int SiteCount { get; set; }
            public int AllSiteStatus { get; set; }
            public int AllSiteResult { get; set; }
        }

        public enum SiteNumber
        {
            Site1 = 1,
            Site2,
            Site3,
            Site4,
            Site5,
            Site6,
            Site7,
            Site8
        }

        public enum SiteStatus
        {
            Closed = 0,
            Open = 1
        }

        public enum SiteResult
        {
            Fail = 0,
            Pass = 1
        }

        public class Site
        {
            public SiteNumber number { get; set; }
            public SiteStatus status { get; set; }
            public SiteResult result { get; set; }
        }

        public interface ISiteDataSource
        {
            // 获取所有Site状态
            List<Site> GetAllSiteStatus();

            // 获取所有Site测试结果
            List<Site> GetAllSiteResult();

            // 开启指定Site
            bool OpenSite(int siteNumber);

            // 关闭指定Site
            bool CloseSite(int siteNumber);

            // 开启所有Site
            bool OpenAllSite();

            // 关闭所有Site
            bool CloseAllSite();
        }

        public class SiteDataSource : ISiteDataSource
        {
            private List<Site> sites;

            public SiteDataSource()
            {
                // 初始化示例数据
                //sites = new List<Site>
                //{
                //    new Site { SiteNumber = 1, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 2, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 3, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 4, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 5, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 6, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 7, SiteStatus = 1, SiteResult = 0 },
                //    new Site { SiteNumber = 8, SiteStatus = 1, SiteResult = 0 },
                //};
            }

            public List<Site> GetAllSiteStatus()
            {
                // Todo
                //SitesStatus = new List<sites.SiteNumber, sites.SiteStatus>;

                return sites;
            }

            public List<Site> GetAllSiteResult()
            {
                // Todo

                return sites;
            }

            public bool OpenSite(int siteNumber)
            {
                // Todo

                return true;
            }

            public bool CloseSite(int siteNumber)
            {
                // Todo

                return true;
            }

            public bool OpenAllSite()
            {
                // Todo

                return true;
            }

            public bool CloseAllSite()
            {
                // Todo

                return true;
            }
        }
    }
}
