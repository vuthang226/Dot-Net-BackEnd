using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class BaseDL<TEntity>:IBaseDL<TEntity>
    {
        #region DECLARE
        IDbContext<TEntity> _dbContext;
        public BaseDL(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public IEnumerable<TEntity> GetAll()
        {
            var entity = _dbContext.GetAll();
            return entity;
        }

        /// <summary>
        /// Lấy dữ liêu theo trang và filter
        /// </summary>
        /// <param name="pageNum">Số trang </param>
        /// <param name="numInPage">Số bản ghi 1 trang</param>
        /// <param name="column">cột</param>
        /// <param name="filter">Từ cần tìm kiếm</param>
        /// <param name="typeSort">Cách sắp</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetDataByPageAndFilter(int pageNum, int numInPage,int column,string filter,int typeSort)
        {
            var tableName = typeof(TEntity).Name;
            var sqlProc = $"Proc_Get{tableName}ByPageAndFilter";
            var entitys = _dbContext.GetData(sqlProc,new { pageNum = pageNum, numInPage = numInPage, columnSort = column, filter = filter, typeSort = typeSort });
            return entitys;
        }

        /// <summary>
        /// Lấy dữ liệu theo proc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetDataById( string id)
        {
            var tableName = typeof(TEntity).Name;
            var sqlProc = $"Proc_Get{tableName}ById";
            var entity = _dbContext.GetData(sqlProc, new { id = id }, CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Lấy dữ liệu theo proc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntityByCode(string code)
        {
            var tableName = typeof(TEntity).Name;
            var sqlProc = $"Proc_Get{tableName}ByCode";
            var entity = _dbContext.GetData(sqlProc, new { code = code }, CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(TEntity entity)
        {
            var rowaffect = _dbContext.Insert(entity);
            return rowaffect;
        }

        /// <summary>
        /// Thêm mới một list các bản ghi
        /// </summary>
        /// <typeparam name="List">List các bản ghi</typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(List<TEntity> entities)
        {
            var rowaffect = 0; 
            foreach(TEntity entity in entities)
            {
                rowaffect += _dbContext.Insert(entity);
            }
            return rowaffect;
        }

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(TEntity entity)
        {
            var rowaffect = _dbContext.Update(entity);
            return rowaffect;
        }


        /// <summary>
        /// Chỉnh sủa list dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(List<TEntity> entities)
        {
            var rowaffect = 0;
            foreach (TEntity entity in entities)
            {
                rowaffect += _dbContext.Update(entity);
            }
            return rowaffect;
        }


        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public int Delete(string id)
        {
            var rowaffect = _dbContext.Delete(id);
            return rowaffect;
        }

        /// <summary>
        /// Lấy ra lít code phù hợp với chuỗi
        /// </summary>
        /// <param name="string">Chuỗi chuyền vào</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public List<string> GetListCodeMatch(string code)
        {
            var tableName = typeof(TEntity).Name;
            var listCode = _dbContext.GetListString($"Proc_Get{tableName}Code", new { code = code }, CommandType.StoredProcedure);
            return listCode;
        }


        public List<string> GetNumEntities()
        {
            var tableName = typeof(TEntity).Name;
            var nums = _dbContext.GetListString($"Proc_Count{tableName}", CommandType.StoredProcedure);
            return nums;
        }



    }
}
