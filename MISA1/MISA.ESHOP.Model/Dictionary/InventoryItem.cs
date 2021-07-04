using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ESHOP.Model
{
    public  class InventoryItem
    {
        private string _name;
        public string Name { get; set; }

        public bool Validate(string shortName, decimal price)
        {
            return true;
        }
    }
}
