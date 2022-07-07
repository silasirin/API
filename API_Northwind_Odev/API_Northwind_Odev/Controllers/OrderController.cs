using API_Northwind_Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Northwind_Odev.Controllers
{
    public class OrderController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetOrders() //tum siparisleri listeleme
        {
            return Ok(db.Orders.ToList());
        }

        public HttpResponseMessage GetOrders(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (order != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Orders);
                return response;
            }

            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Siparis Bulunamadi!");
                return errorResponse;
            }

        }
    }
}
