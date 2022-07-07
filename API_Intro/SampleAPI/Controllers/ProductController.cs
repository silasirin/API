using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class ProductController : ApiController
    {
        IEnumerable<Product> GetFakeProducts
        {
            get
            {
                return new List<Product>
                { new Product
                {
                    ProductName = "Product 1",
                    UnitPrice = 5
                },

                 new Product
                { ProductName = "Product 2",
                UnitPrice= 10
                },

                 new Product
                { ProductName = "Product 3",
                UnitPrice= 15}

                };

            }
        }

        public HttpResponseMessage Get()
        {
            var products =  GetFakeProducts.ToList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
            return response;
        }

    }
}
