using API_Northwind_Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Northwind_Odev.Controllers
{
    public class CustomerController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetCustomers() //tum siparisleri listeleme
        {
            return Ok(db.Customers.ToList());
        }

        public HttpResponseMessage GetCustomers(string id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (customer != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Customers);
                return response;
            }

            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Musteri Bulunamadi!");
                return errorResponse;
            }

        }
    }
}
