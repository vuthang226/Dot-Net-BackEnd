using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IBaseDL<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Lấy dữ liệu theo proc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetDataById(string id);

        /// <summary>
        /// Lấy dữ liệu theo proc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntityByCode(string code);

        /// <summary>
        /// Lấy dữ liêu theo trang và filter
        /// </summary>
        /// <param name="pageNum">Số trang </param>
        /// <param name="numInPage">Số bản ghi 1 trang</param>
        /// <param name="column">cột</param>
        /// <param name="filter">Từ cần tìm kiếm</param>
        /// <param name="typeSort">Cách sắp</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetDataByPageAndFilter(int pageNum, int numInPage, int column, string filter, int type);

        /// <summary>
        /// Lấy ra lít code phù hợp với chuỗi
        /// </summary>
        /// <param name="string">Chuỗi chuyền vào</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public List<string> GetListCodeMatch(string code);

        /// <summary>
        /// Thêm mới bản ghi dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(TEntity entity);

        /// <summary>
        /// Thêm mới một list các bản ghi
        /// </summary>
        /// <typeparam name="List">List các bản ghi</typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(List<TEntity> entities);

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(TEntity entity);

        /// <summary>
        /// Chỉnh sủa list dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(List<TEntity> entities);

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public int Delete(string id);


        public List<string> GetNumEntities();
    }
}
