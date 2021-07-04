using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.EntitiesController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        #region DECLARE
        /// <summary>
        /// Khởi tạo
        /// </summary>
        IBaseBL<TEntity> _baseBL;
        public BaseEntitiesController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns>Trạng thái và dữ liệu</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseBL.GetAll());
        }

        /// <summary>
        /// Thêm mới dữ liệu có check dữ liệu trùng
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>Status</returns>
        [HttpPost]
        public ServiceResult Post(TEntity entity)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _baseBL.Insert(entity);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(Resources.ErroException);
            }
            return serviceResult;
        }
    }
}
