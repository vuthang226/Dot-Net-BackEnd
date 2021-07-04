using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Entities;
using MISA.DL.Interfaces;
using System.Data;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaterialsController 
    {
        #region DECLARE
        IMaterialBL _materialBL;
        IDbContext<Material> _dbContext;
        public MaterialsController(IMaterialBL materialBL, IDbContext<Material> dbContext)
        {
            _materialBL = materialBL;
            _dbContext = dbContext;
        }
        #endregion

        /// <summary>
        /// Lấy Nguyên vật liệu và đơn vị chuyển đổi bằng id
        /// </summary>
        /// <param name="id">id nguyên vật liệu</param>
        /// <returns></returns>
        [HttpGet]
        public ServiceResult GetMaterialById(string id)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.GetEntityById(id);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        /// <summary>
        /// lẤY DATA theo số trang và sắp xếp
        /// </summary>
        /// <param name="pageNum">Số trang</param>
        /// <param name="numInPage">Số bản ghi 1 trang</param>
        /// <param name="column">Cột</param>
        /// <param name="filter">Từ khóa tìm kiếm</param>
        /// <param name="type">tăng / giảm dần</param>
        /// <returns></returns>
        [HttpGet("page")]
        public ServiceResult GetDataByPageAndFilter(int pageNum, int numInPage, int column, string filter, int type)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.GetDataByPageAndFilter(pageNum, numInPage, column, filter, type);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        /// <summary>
        /// Lấy Mã code cao nhất theo chuỗi truyền vào
        /// </summary>
        /// <param name="code">Mã code cần lấy phù hợp</param>
        /// <returns></returns>
        [HttpGet("code")]
        public ServiceResult GetHighestCodeMatch(string code)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.GetHighestCodeMatch(code);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới nguyện vật liệu và đơn vị chuyển đổi nếu có
        /// </summary>
        /// <param name="materialRespone">nguyện vật liệu và đơn vị chuyển đổi</param>
        /// <returns></returns>
        [HttpPost]
        public ServiceResult Insert(MaterialRespone materialRespone)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.Insert(materialRespone);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        /// <summary>
        /// Cập nhật nguyện vật liệu và đơn vị chuyển đổi
        /// </summary>
        /// <param name="materialRespone">nguyện vật liệu và đơn vị chuyển đổi</param>
        /// <returns></returns>
        [HttpPut]
        public ServiceResult Update(MaterialRespone materialRespone)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.Update(materialRespone);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        /// <summary>
        /// Xóa một nguyên vật liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public ServiceResult Delete(Material material)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = _materialBL.Delete(material);
            }
            catch (Exception ex)
            {
                serviceResult.HandleException(ex: ex);
            }
            return serviceResult;
        }

        





    }
}
