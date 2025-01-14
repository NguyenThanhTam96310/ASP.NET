using nguyenthanhtam_2122110440.Context;
using nguyenthanhtam_2122110440.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace nguyenthanhtam_2122110440.Controllers
{
    public class HomeController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        public ActionResult Index()
        {
            HomeModels objHomeModels=new HomeModels();

            objHomeModels .ListCategory= objEcommerce_MVC_2Entities.Category.ToList();
            objHomeModels .ListProduct= objEcommerce_MVC_2Entities.Product.ToList();
            return View(objHomeModels);
        }
        
    }
}