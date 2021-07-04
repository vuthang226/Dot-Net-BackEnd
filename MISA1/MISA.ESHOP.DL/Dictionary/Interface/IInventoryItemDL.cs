using MISA.ESHOP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ESHOP.DL
{
    public interface IInventoryItemDL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="sort"></param>
        /// <param name="filter">chuoi filter, name = SKU AND code = 1</param>
        /// <returns></returns>
        List<InventoryItem> GetPagingInventoryItems(int page, int limit, string sort, string filter);
    }
}
