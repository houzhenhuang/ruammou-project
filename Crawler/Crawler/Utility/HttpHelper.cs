using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace Crawler.Utility
{
    public class HttpHelper
    {
        /// <summary>
        /// 根据url下载内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadUrl(string url)
        {
            return DownloadHtml(url, Encoding.UTF8);
        }
        public static string DownloadHtml(string url, Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
               // request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(string.Format("DownloadHtml抓取{0}保存失败", url), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    Console.WriteLine("远程服务器返回错误: (306)。", ex);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
