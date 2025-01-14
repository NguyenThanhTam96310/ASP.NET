using nguyenthanhtam_2122110440.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Controllers
{
    public class CategoryController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Category
        public ActionResult AllCategory()
        {
            var ListCategory = objEcommerce_MVC_2Entities.Category.ToList();
            return View(ListCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var ListProduct=objEcommerce_MVC_2Entities.Product.Where(n => n.CategoryId==Id).ToList();   
            return View(ListProduct);
        }
    }
}