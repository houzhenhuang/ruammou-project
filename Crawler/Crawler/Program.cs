using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crawler.Utility;
using Newtonsoft.Json;
using Crawler.Model;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 测试DownloadHtml
                {
                    //string html = HttpHelper.DownloadHtml(@"https://list.jd.com/list.html?cat=9987,653,655",Encoding.UTF8);
                    //Console.WriteLine(html);
                }
                #endregion
                #region 测试获取分类页
                {
                    //string html = HttpHelper.DownloadHtml(@"https://www.jd.com/allSort.aspx", Encoding.UTF8);
                    //Console.WriteLine(html);
                }
                #endregion
                #region 测试抓取商品列表
                {
                    string testCategory = "{\"Id\":73,\"Code\":\"02f01s01T\",\"ParentCode\":\"02f01s\",\"Name\":\"烟机/灶具\",\"Url\":\"https://list.jd.com/list.html?cat=9987,653,655\",\"Level\":3}";
                    new CommoditySearch(JsonConvert.DeserializeObject<Category>(testCategory)).Crawler();
                } 
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
