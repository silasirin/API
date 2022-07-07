using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Northwind_Odev.Models
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

    }
}