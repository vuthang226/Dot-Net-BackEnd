using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.BL
{
    public class BaseBL<TEntity> : IBaseBL<TEntity>
    {
        #region DECLARE
        IBaseDL<TEntity> _baseDL;
        public BaseBL(IBaseDL<TEntity> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public ServiceResult GetAll()
        {
            var serviceResult = new ServiceResult();
            var entity = _baseDL.GetAll();
            if(entity != null) 
            {
                serviceResult.OnSussess(entity, Resources.SuccessService_InsertSuccess);
            }
            else
            {
                serviceResult.OnSussess(entity, Resources.SuccessService_InsertSuccess);
            }
            return serviceResult;
            
        }

        /// <summary>
        /// Lấy dữ liệu qua id
        /// </summary>
        /// <param name="id">id của dữ liệu cần lấy</param>
        /// vhthang 26/03/2021
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntityById(string id)
        { 
            var entity = _baseDL.GetDataById(id) ;
            return entity;
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Insert(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            var isValid = Validate(entity, 1);
            if (isValid.ErrorCode != MISACode.IsValid)
            {
                return isValid;
            }
            var query = _baseDL.Insert(entity);
            if (query > 0)
            {
                serviceResult.OnSussess(query, Resources.SuccessService_InsertSuccess);
            }
            else
            { 
                serviceResult.OnSussess(query, Resources.SuccessService_InsertNotSuccess);
            }
            return serviceResult;
        }

        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>ServiceResult</returns>
        protected virtual ServiceResult Validate(TEntity entity, int type)
        {
            var serviceResult = new ServiceResult();
            serviceResult.OnSussess(true, Resources.SuccessService_IsVaid, MISACode.IsValid);
            return serviceResult;
        }

        /// <summary>
        /// Update dữ liệu theo Id
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Update(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            var isValid = Validate(entity, 2);
            if (isValid.ErrorCode != MISACode.IsValid)
            {
                return isValid;
            }
            var query = _baseDL.Update(entity);
            if (query > 0)
            {
                serviceResult.OnSussess(query, Resources.SuccessService_UpdateSuccess);
            }
            else
            {
                serviceResult.OnSussess(query, Resources.SuccessService_UpdateNotSuccess);
            }
            return serviceResult;
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="id">id bản ghi truyền vảo</param>
        /// <returns></returns>
        public ServiceResult Delete(string id)
        {
            var serviceResult = new ServiceResult();
            var query = _baseDL.Delete(id);
            if (query > 0)
            {
                serviceResult.OnSussess(query, Resources.SuccessService_DeleteSuccess);
            }
            else
            {
                serviceResult.OnSussess(query, Resources.SuccessService_DeleteNotSuccess);
            }
            return serviceResult;
        }

        /// <summary>
        /// Lấy ra code max
        /// </summary>
        /// <returns></returns>
        public virtual string GetHighestCodeAddOne()
        {
            var stringg = "";
            return stringg;
        }

        #endregion

    }
}
