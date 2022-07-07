using ApiAuth_Northwind.Entity;
using ApiAuth_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAuth_Northwind.Tools
{
    public class LoginCredentials
    {
        public static bool AnyUser(string firstname, string lastname)
        {
            NorthwindEntities db = new NorthwindEntities();
            bool result = db.Employees.Any(x => x.FirstName == firstname && x.LastName == lastname);
            return result;
        }
    }
}