using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAuth_Northwind.Entity
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}