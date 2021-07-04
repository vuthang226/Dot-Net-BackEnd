using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Model
{
    public class Material
    {
        public Guid MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialUnit { get; set; }
        public string MaterialStore { get; set; }
        public int MaterialDate { get; set; }
        public string MaterialDateUnit { get; set; }
        public int MaterialNum { get; set; }
        public string MaterialDescription { get; set; }
        
    }
}
