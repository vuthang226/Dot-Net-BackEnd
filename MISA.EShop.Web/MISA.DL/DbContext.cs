using Dapper;
using MISA.DL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class DbContext<TEntity>:IDbContext<TEntity>
    {
        #region DECLARE
        //Khởi tạo
        protected string _connectionString = "Host=localhost;User Id=root; password=;Database=cukcuk_demo;port=3306;Character Set=utf8";
        protected IDbConnection _dbConnection;
        public DbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetData(string sqlCommand = null,object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var tableName = typeof(TEntity).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"Proc_Get{tableName}s";
            }           
            var entity = _dbConnection.Query<TEntity>(sqlCommand,param: parameters, commandType: commandType);
            return entity;
        }

        

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="string">Chuỗi</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        public List<string> GetListString(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var tableName = typeof(TEntity).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"Proc_Get{tableName}Code";
            }
            var entity = _dbConnection.Query<string>(sqlCommand, param: parameters, commandType: commandType).AsList<string>();
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
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            var query = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Dữ liệu</returns>
        public IEnumerable<TEntity> GetAll() 
        {
            var tableName = typeof(TEntity).Name;
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{tableName}", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }


            }
            var query = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public int Delete(string id)
        {
            var tableName = typeof(TEntity).Name;   
            var sqlString = $"Proc_Delete{tableName}ById";
            var query = _dbConnection.Execute(sqlString, new {id = id }, commandType: CommandType.StoredProcedure);
            return query;
        }
        #endregion

    }
}
