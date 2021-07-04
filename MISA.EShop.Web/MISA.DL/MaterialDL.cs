using MISA.Common;
using MISA.DL;
using MISA.DL.Interfaces;
using MISA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL
{
    public class MaterialDL : BaseDL<Material> ,IMaterialDL
    {
        #region DECLARE
        IDbContext<Material> _dbContext;
        public MaterialDL(IDbContext<Material> dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        /// <summary>
        /// Check trùng
        /// </summary>
        /// <param name="name">Tên trường cần check</param>
        /// <param name="value">Giá trị check</param>
        /// <returns></returns>
        public IEnumerable<Material> CheckDuplicate(string name, string value)
        {
            var shop = _dbContext.GetData($"Proc_GetMaterialBy{name}",new {data = value });
            return shop;
        }
    }
}
