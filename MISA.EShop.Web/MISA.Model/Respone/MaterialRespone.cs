using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Model
{
    public class MaterialRespone
    {
        public Material Material { get; set; }
        public List<ConvertUnit> ConvertUnits { get; set; }
    }
}
