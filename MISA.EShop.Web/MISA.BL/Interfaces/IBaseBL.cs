using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IBaseBL<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public ServiceResult GetAll();
        /// <summary>
        /// Lấy dữ liệu từ id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntityById(string id);
        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Insert(TEntity entity);
        /// <summary>
        /// Update dữ liệu theo Id
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Update(TEntity entity);
        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="id">id bản ghi truyền vảo</param>
        /// <returns></returns>
        public ServiceResult Delete(string id);
    }
}
