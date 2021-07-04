using MISA.Common;
using MISA.Common.Entities;
using MISA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IMaterialBL
    {
        /// <summary>
        /// Lấy nguyên vật liệu và đơn vị chuyển đổi của nó
        /// </summary>
        /// <param name="id">id của nguyên vật liệu</param>
        /// <returns></returns>
        public ServiceResult GetEntityById(string id);

        /// <summary>
        /// Lấy mã code cao nhất phù hợp
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ServiceResult GetHighestCodeMatch(string code);

        /// <summary>
        /// lẤY DATA theo số trang và sắp xếp
        /// </summary>
        /// <param name="pageNum">Số trang</param>
        /// <param name="numInPage">Số bản ghi 1 trang</param>
        /// <param name="column">Cột</param>
        /// <param name="filter">Từ khóa tìm kiếm</param>
        /// <param name="type">tăng / giảm dần</param>
        /// <returns></returns>
        public ServiceResult GetDataByPageAndFilter(int pageNum, int numInPage, int column, string filter, int type);

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Insert(MaterialRespone materialRespone);

        /// <summary>
        /// Chỉnh sửa một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Update(MaterialRespone materialRespone);

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        public ServiceResult Delete(Material material);
    }
}
