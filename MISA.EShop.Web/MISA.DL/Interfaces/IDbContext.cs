using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="string">Chuỗi</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        public List<string> GetListString(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Thêm mới bản ghi dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(TEntity entity);

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Dữ liệu</returns>
        public IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(TEntity entity);

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public int Delete(string id);
    }
}
