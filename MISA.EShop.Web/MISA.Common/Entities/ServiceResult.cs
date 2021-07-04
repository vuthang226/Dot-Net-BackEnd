using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    public class ServiceResult
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISACode ErrorCode { get; set; }
        public ServiceResult()
        {
            this.Success = true;
        }
        public void OnSussess(object data, string message = "", MISACode errorCode = MISACode.Success)
        {
            this.Data = data;
            this.Success = true;
            this.Message = message;
            this.ErrorCode = errorCode;
        }
        public void OnError(object data = null, string message = "", MISACode errorCode = MISACode.Fail)
        {
            this.Data = data;
            this.Success = false;
            this.Message = message;
            this.ErrorCode = errorCode;
        }
        public void HandleException(object data = null, Exception ex = null, MISACode errorCode = MISACode.Exception)
        {
            this.Data = data;
            this.Success = false;
            this.Message = ex != null ? ex.ToString() : string.Empty;
            this.ErrorCode = errorCode;
        }
    }
}
