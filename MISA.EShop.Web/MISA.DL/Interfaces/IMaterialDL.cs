using MISA.Common;
using MISA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IMaterialDL:IBaseDL<Material>
    {
        /// <summary>
        /// Check trùng
        /// </summary>
        /// <param name="name">Tên trường cần check</param>
        /// <param name="value">Giá trị check</param>
        /// <returns></returns>
        public IEnumerable<Material> CheckDuplicate(string name, string value);
    }
}
