using Homework.Framework.Models;
using Homework.Remote.Interface;
using Homework.Remote.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Remote.Service
{
    public class SearchService : ISearch
    {
        public PageResult<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryList, string priceFilter, string priceOrderBy)
        {
            RemoteSearchService.SearcherClient client = null;
            try
            {
                client = new RemoteSearchService.SearcherClient();
                string result = client.QueryCommodityPage(pageIndex, pageSize, keyword, categoryList.ToArray(), priceFilter, priceOrderBy);
                client.Close();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PageResult<CommodityModel>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (client != null)
                    client.Abort();
                throw ex;
            }
        }
    }
}
