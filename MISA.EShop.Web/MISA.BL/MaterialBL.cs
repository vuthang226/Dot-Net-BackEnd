using MISA.BL;
using MISA.BL.Interfaces;
using MISA.Model;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Entities;
using MISA.Common.Properties;
using System.Linq;
using MISA.Common;
using System.Text.RegularExpressions;
using System.Transactions;

namespace MISA.BL
{
    public class MaterialBL: IMaterialBL
    {
        #region DECLARE
        IMaterialDL _materialDL;
        IBaseDL<ConvertUnit> _convertUnit;
        public MaterialBL(IMaterialDL materialDL, IBaseDL<ConvertUnit> convertUnit)
        {
            _materialDL = materialDL;
            _convertUnit = convertUnit;
        }
        #endregion

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public ServiceResult GetAll()
        {
            var serviceResult = new ServiceResult();
            var entity = _materialDL.GetAll();
            if (entity != null)
            {
                serviceResult.OnSussess(entity, Resources.SuccessService_GetSuccess);
            }
            else
            {
                serviceResult.OnSussess(entity, Resources.SuccessService_GetSuccess);
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
        public ServiceResult GetDataByPageAndFilter(int pageNum, int numInPage, int column, string filter, int type)
        {
            var serviceResult = new ServiceResult();
            if(string.IsNullOrEmpty(filter)) { filter = ""; }
            var entities = _materialDL.GetDataByPageAndFilter(pageNum, numInPage, column, filter, type);
            var numMaterials = _materialDL.GetNumEntities();
            serviceResult.OnSussess(new{ materials = entities,numMaterials= numMaterials });
            return serviceResult;
        }

        /// <summary>
        /// Lấy nguyên vật liệu và đơn vị chuyển đổi của nó
        /// </summary>
        /// <param name="id">id của nguyên vật liệu</param>
        /// <returns></returns>
        public ServiceResult GetEntityById(string id)
        {
            var serviceResult = new ServiceResult();
            MaterialRespone result = new MaterialRespone();
            result.Material = _materialDL.GetDataById(id).ElementAt(0);
            result.ConvertUnits = (List<ConvertUnit>)_convertUnit.GetDataById(id);
            serviceResult.OnSussess(result);
            return serviceResult;
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Insert(MaterialRespone materialRespone)
        {
            var material = materialRespone.Material;
            var convertUnits = materialRespone.ConvertUnits;
            material.MaterialId = Guid.NewGuid();
            var serviceResult = new ServiceResult();
            var isValid = Validate(material, 1);
            if (isValid.ErrorCode != MISACode.IsValid)
            {
                return isValid;
            }
            
                var query = _materialDL.Insert(material);
                var query2 = 0;
                if (query > 0)
                {
                    if (convertUnits.Any())
                    {
                        foreach (ConvertUnit convertUnit in convertUnits)
                        {
                            convertUnit.ConvertMaterialId = material.MaterialId;
                        }
                        query2 = _convertUnit.Insert(convertUnits);
                    }
                    if (query2 == convertUnits.Count)
                    {
                        serviceResult.OnSussess(true, Resources.SuccessService_InsertSuccess);
                    }
                }
                else
                {
                    serviceResult.OnSussess(false, Resources.SuccessService_InsertNotSuccess);
                }
                
            return serviceResult;
        }


        /// <summary>
        /// Chỉnh sửa một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Update(MaterialRespone materialRespone)
        {
            var material = materialRespone.Material;
            var convertUnits = materialRespone.ConvertUnits;
            var serviceResult = new ServiceResult();
            var isValid = Validate(material, 2);
            if (isValid.ErrorCode != MISACode.IsValid)
            {
                return isValid;
            }
            //using (var tss = new TransactionScope())
            //{
                var query = _materialDL.Update(material);
                var query2 = 0;
                if (query > 0)
                {
                    if (convertUnits.Any())
                    {
                        foreach (ConvertUnit convertUnit in convertUnits)
                        {
                            convertUnit.ConvertMaterialId = material.MaterialId;
                        }
                        query2 = _convertUnit.Update(convertUnits);
                    }
                    if (query2 == convertUnits.Count)
                    {
                        serviceResult.OnSussess(true, Resources.SuccessService_UpdateSuccess);
                    }
                }
                else
                {
                    serviceResult.OnSussess(false, Resources.SuccessService_UpdateNotSuccess);
                }
            //    tss.Complete();
            //}
            return serviceResult;
        }

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        public ServiceResult Delete(Material material)
        {
            var serviceResult = new ServiceResult();
            var query = _materialDL.Delete(material.MaterialId.ToString());
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
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>ServiceResult</returns>
        
        /// <summary>
            /// Overrride hàm kiểm tra dữ liệu
            /// </summary>
            /// <param name="shop">Khách hàng</param>
            /// <returns>ServiceResult</returns>
        public ServiceResult Validate(Material material, int type)
        {
            var serviceResult = new ServiceResult();
            var materialCode = material.MaterialCode;
            //Kiểm tra mã có bị để trống
            if (string.IsNullOrEmpty(materialCode) || string.IsNullOrEmpty(materialCode.Trim()))
            {
                
                serviceResult.ErrorCode = MISACode.NotValid;
                serviceResult.Message = Resources.ErroService_EmptyMaterialCode;
                serviceResult.Data = false;
                return serviceResult;
            }
            //Kiểm tra trùng mã
            var checkCode = _materialDL.CheckDuplicate("Code", material.MaterialCode);
            if (checkCode.Count() > 0)
            {
                if (type == 1 || checkCode.ElementAt(0).MaterialId != material.MaterialId)
                {
                    
                    serviceResult.ErrorCode = MISACode.NotValid;
                    serviceResult.Message = Resources.ErroService_DuplicateMaterialCode;
                    serviceResult.Data = false;
                    return serviceResult;
                }
            }
            var materialName = material.MaterialName;
            //Kiểm tra tên có bị để trống
            if (string.IsNullOrEmpty(materialName) || string.IsNullOrEmpty(materialName.Trim()))
            {

                serviceResult.ErrorCode = MISACode.NotValid;
                serviceResult.Message = Resources.ErroService_EmptyMaterialName;
                serviceResult.Data = false;
                return serviceResult;
            }
            var materialUnit = material.MaterialUnit;
            //Kiểm tra đơn vị tính có bị để trống
            if (string.IsNullOrEmpty(materialUnit) || string.IsNullOrEmpty(materialUnit.Trim()))
            {

                serviceResult.ErrorCode = MISACode.NotValid;
                serviceResult.Message = Resources.ErroService_EmptyMaterialUnit;
                serviceResult.Data = false;
                return serviceResult;
            }
            serviceResult.ErrorCode = MISACode.IsValid;
            serviceResult.Message = Resources.SuccessService_IsVaid;
            serviceResult.Data = true;
            return serviceResult;

        }
    
        /// <summary>
        /// Lấy mã code cao nhất phù hợp
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ServiceResult GetHighestCodeMatch(string code)
        {
            var serviceResult = new ServiceResult();
            var listCode = _materialDL.GetListCodeMatch(code);
            var codeLength = code.Length;
            var codeMax = 0;
            Regex rgx = new Regex(@"^" + code + "[0-9]*$");
            for (int i = 0; i < listCode.Count; i++)
            {
                if (!rgx.IsMatch(listCode[i]))
                {

                }
                else
                {
                    try
                    {
                        int codeNum = Int32.Parse(listCode[i].Substring(codeLength));
                        if (codeMax < codeNum) codeMax = codeNum;
                    }
                    catch 
                    {
                        serviceResult.OnSussess(1, "Có lỗi khi lấy mã code");
                        return serviceResult;
                    }

                }
            }
            serviceResult.OnSussess(codeMax + 1, "Thành công");
            return serviceResult;
        }
    }
}
