using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crawler.Model;
using Crawler.Utility;
using HtmlAgilityPack;
using System.IO;
using Newtonsoft.Json;

namespace Crawler
{
    public class CommoditySearch
    {
        private Category _category = null;
        public CommoditySearch(Category category)
        {
            this._category = category;
        }


        public void Crawler()
        {
            try
            {
                if (string.IsNullOrEmpty(_category.Url))
                {
                    Console.Write(string.Format("Url为空,Name={0} Level={1} Url={2}", _category.Name, _category.CategoryLevel, _category.Url));
                    return;
                }
                else
                {
                    string html = HttpHelper.DownloadUrl(_category.Url);//下载html

                    HtmlDocument hDoc = new HtmlDocument();
                    hDoc.LoadHtml(html);
                    string pageXPath = @"//*[@id='J_topPage']/span/i";
                    HtmlNode pageNode = hDoc.DocumentNode.SelectSingleNode(pageXPath);
                    if (pageNode != null)
                    {
                        string sPage = pageNode.InnerText;
                        //for (int i = 1; i <= int.Parse(sPage); i++)
                        for (int i = 1; i <= 1; i++)
                        {
                            //https://list.jd.com/list.html?cat=9987,653,655&page=2&sort=sort_rank_asc&trans=1&JL=6_0_0&ms=6#J_main

                            string pageUrl = string.Format("{0}&page={1}&sort=sort_rank_asc&trans=1&JL=6_0_0&ms=6#J_main", _category.Url, i);

                            try
                            {
                                List<Commodity> commodityList = GetCommodityList(_category, pageUrl);
                                foreach (var item in commodityList)
                                {
                                    Console.WriteLine("productId={0},Title={1},Price={2},Url={3},ImageUrl={4}",item.ProductId,item.Title.TrimEnd().TrimStart(),item.Price,item.Url,item.ImageUrl);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.Write("Crawler的commodityRepository.SaveList(commodityList)出现异常", ex);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write("CrawlerMuti出现异常", ex);
                Console.Write(string.Format("出现异常,Name={0} Level={1} Url={2}", _category.Name, _category.CategoryLevel, _category.Url));
            }
        }

        public List<Commodity> GetCommodityList(Category category, string url)
        {
            string html = HttpHelper.DownloadUrl(url);
            List<Commodity> commodityList = new List<Commodity>();
            try
            {
                if (string.IsNullOrEmpty(html)) return commodityList;
                HtmlDocument hDoc = new HtmlDocument();
                hDoc.LoadHtml(html);
                string liPath = @"//*[@id='plist']/ul/li";
                HtmlNodeCollection nodeList = hDoc.DocumentNode.SelectNodes(liPath);
                if (nodeList == null || nodeList.Count == 0)
                {
                    Console.WriteLine(string.Format("GetCommodityList商品数据为空,Name={0} Level={1} category.Url={2} url={3}", category.Name, category.CategoryLevel, category.Url, url));
                    return commodityList;
                }
                foreach (var item in nodeList)
                {
                    HtmlDocument childDoc = new HtmlDocument();
                    childDoc.LoadHtml(item.OuterHtml);

                    Commodity commodity = new Commodity { CategoryId = category.Id };

                    string urlPath = @"//*[@class='p-img']/a";////*[@id="plist"]/ul/li[2]/div/div[1]/a
                    HtmlNode urlNode = childDoc.DocumentNode.SelectSingleNode(urlPath);
                    if (urlNode == null)
                    {
                        continue;
                    }
                    commodity.Url = urlNode.Attributes["href"].Value;
                    if (!commodity.Url.StartsWith("http:"))
                        commodity.Url = "http:" + commodity.Url;

                    string pId = Path.GetFileName(commodity.Url).Replace(".html", "");
                    commodity.ProductId = long.Parse(pId);

                    string titlePath = @"//*[@class='p-name']/a/em/text()";//*[@id="plist"]/ul/li[1]/div/div[4]/a/em
                    HtmlNode titleNode = childDoc.DocumentNode.SelectSingleNode(titlePath);
                    string title = titleNode.InnerText;
                    commodity.Title = title;

                    string imgSrcPath = @"//*[@class='p-img']/a/img";
                    HtmlNode imgNode = childDoc.DocumentNode.SelectSingleNode(imgSrcPath);
                    if (imgNode == null)
                    {
                        continue;
                    }
                    if (imgNode.Attributes.Contains("src"))
                        commodity.ImageUrl = imgNode.Attributes["src"].Value;
                    else if (imgNode.Attributes.Contains("original"))
                        commodity.ImageUrl = imgNode.Attributes["original"].Value;
                    else if (imgNode.Attributes.Contains("data-lazy-img"))
                        commodity.ImageUrl = imgNode.Attributes["data-lazy-img"].Value;
                    else
                    {
                        continue;
                    }
                    if (!commodity.ImageUrl.StartsWith("http:"))
                        commodity.ImageUrl = "http:" + commodity.ImageUrl;

                    commodityList.Add(commodity);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format("GetCommodityList出现异常,url={0}", url));
            }
            return GetCommodityPrice(commodityList);
        }

        private List<Commodity> GetCommodityPrice(List<Commodity> commodityList)
        {
            if (commodityList == null || commodityList.Count == 0)
                return commodityList;
            try
            {
                //https://p.3.cn/prices/mgets?callback=jQuery1323882&ext=11000000&pin=&type=1&area=1_72_4137_0&skuIds=
                //J_5181380%2CJ_3888216%2CJ_4914531%2CJ_3726830%2CJ_3133827%2CJ_2962435%2CJ_4720749%2CJ_5089253%2CJ_7081550%2CJ_6558982%2CJ_6631219%2CJ_5284327%2CJ_4082786%2CJ_4884236%2CJ_4510588%2CJ_4503858%2CJ_4586850%2CJ_3494451%2CJ_4154589%2CJ_6946631%2CJ_6600258%2CJ_3234250%2CJ_5159276%2CJ_5001213%2CJ_5159264%2CJ_6055046%2CJ_3355143%2CJ_2600242%2CJ_5089273%2CJ_5159242&pdbp=0&pdtk=&pdpin=&pduid=15250541986301059572903&source=list_pc_front&_=1525150523786

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("https://p.3.cn/prices/mgets?callback=jQuery1323882&ext=11000000&pin=&type=1&area=1_72_4137_0&skuIds={0}&pdbp=0&pdtk=&pdpin=&pduid=15250541986301059572903&source=list_pc_front&_=1525150523786", string.Join("%2C", commodityList.Select(p => p.ProductId)));
                string html = HttpHelper.DownloadUrl(sb.ToString());
                if (string.IsNullOrWhiteSpace(html))
                {
                    Console.WriteLine(string.Format("获取url={0}时获取的html为空", sb.ToString()));
                }
                html = html.Substring(html.IndexOf("(") + 1);
                html = html.Substring(0, html.LastIndexOf(")"));
                List<CommodityPrice> priceList = JsonConvert.DeserializeObject<List<CommodityPrice>>(html);
                commodityList.ForEach(c => c.Price = priceList.FirstOrDefault(p => p.id.Equals(string.Format("J_{0}", c.ProductId))).p);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCommodityPrice出现异常", ex);
            }
            return commodityList;
        }

    }
}
