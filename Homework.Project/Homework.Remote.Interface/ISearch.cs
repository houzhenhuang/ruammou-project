using Homework.Framework.Models;
using Homework.Remote.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Remote.Interface
{
    public interface ISearch
    {
        /// <summary>
        ///  分页获取商品信息数据
        /// </summary>
        /// <param name="pageIndex">类别id的集合 可为null</param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="categoryList"></param>
        /// <param name="priceFilter">[13,50]  13,50且包含13到50   {13,50}  13,50且不包含13到50</param>
        /// <param name="priceOrderBy">price desc   price asc</param>
        /// <returns></returns>
        PageResult<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryList, string priceFilter, string priceOrderBy);
    }
}
