using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Model
{
    public class ConvertUnit
    { 
        public Guid ConvertId { get; set; }
        public Guid ConvertMaterialId { get; set; }
        public string ConvertUnitName { get; set; }
        public string ConvertRatio { get; set; }
        public int ConvertOperation { get; set; }
        public string ConvertDescription { get; set; }
        public int ConvertHandle { get; set; }
    }
}
