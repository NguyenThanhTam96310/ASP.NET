using nguyenthanhtam_2122110440.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Controllers
{
    public class ProductController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();

        // GET: Product
        public ActionResult Detail(int Id)
        {
            var ObjProduct= objEcommerce_MVC_2Entities.Product.Where(n=>n.Id==Id).FirstOrDefault();
            return View(ObjProduct);
        }
        public ActionResult AllProduct()
        {
            return View();
        }
       
    }
}