using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Northwind_Odev.Models
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
    }
}