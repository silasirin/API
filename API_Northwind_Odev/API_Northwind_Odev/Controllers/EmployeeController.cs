using API_Northwind_Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Northwind_Odev.Controllers
{
    public class EmployeeController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetEmployees() 
        {
            var employees = db.Employees.Select(x => new EmployeeDTO
            {
                ID = x.EmployeeID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title

            });

            return Json(employees);
        }
    }
}
