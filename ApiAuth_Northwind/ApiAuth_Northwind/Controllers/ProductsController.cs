using ApiAuth_Northwind.Entity;
using ApiAuth_Northwind.Filters;
using ApiAuth_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAuth_Northwind.Controllers
{
    [BasicAuth]
    public class ProductsController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetProducts()
        {
            return Ok(ProductList());
        }

        public List<ProductDTO> ProductList()
        {
            var products = db.Products.Select(x => new ProductDTO
            {
                ID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            }).ToList();

            return products;
        }
    }
}
