using API_Northwind_Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Northwind_Odev.Controllers
{
    public class ProductController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        //products icin Crud islemleri
        public IHttpActionResult GetProducts() //tum urunleri listeleme
        {
            var products = db.Products.Select(x => new ProductDTO
            {
                ID=x.ProductID,
                ProductName=x.ProductName,
                UnitPrice=x.UnitPrice,
                UnitsInStock=x.UnitsInStock

            });

            return Json(products);
        }

        public HttpResponseMessage GetProducts(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID == id);

            if (product != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Products);
                return response;
            }

            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Urun Bulunamadi!");
                return errorResponse;
            }

        }

        public IHttpActionResult PostProduct(Product product) //veri ekleme
        {
            if (product != null)
            {
                db.Products.Add(product);
                return Ok(product);
            }
            else
            {
                return BadRequest(); //hatali istek
            }

        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Product product =db.Products.FirstOrDefault(x => x.ProductID == id);
                return Ok("Veri silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public HttpResponseMessage Put(Product product) //veri guncelleme
        {
            Product updated = db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (updated != null)
            {
                updated.CategoryID = product.CategoryID;
                updated.ProductName = product.ProductName;
                updated.UnitPrice = product.UnitPrice;
                updated.UnitsInStock = product.UnitsInStock;

                return Request.CreateResponse(HttpStatusCode.OK, updated);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Urun bulunamadi");
            }
        }
    }
}
