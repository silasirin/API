using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //public Category GetCategorByID(int id)
        //{
        //    List<Category> categories = new List<Category>
        //    {
        //        new Category{ID =1,CategoryName="TestCategory-1",Description="Desc-1"},
        //        new Category{ID =2,CategoryName="TestCategory-2",Description="Desc-2"},
        //        new Category{ID =3,CategoryName="TestCategory-3",Description="Desc-3"}
        //    };

        //    Category category = categories.FirstOrDefault(x => x.ID == id);
        //    return category;
        //}

        public IHttpActionResult Get(int id)
        {
            List<Category> categories = new List<Category>
            {
                new Category{ID =1,CategoryName="TestCategory-1",Description="Desc-1"},
                new Category{ID =2,CategoryName="TestCategory-2",Description="Desc-2"},
                new Category{ID =3,CategoryName="TestCategory-3",Description="Desc-3"}
            };

            Category category = categories.FirstOrDefault(x => x.ID == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
    }
}
