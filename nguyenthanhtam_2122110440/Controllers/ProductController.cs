using nguyenthanhtam_2122110440.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static nguyenthanhtam_2122110440.Common;

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
        public ActionResult AllProduct(string searchTerm,string CurrentFilter, int? page)
        {
            var listProduct = new List<Product>();

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = CurrentFilter;
            }
            if (string.IsNullOrEmpty(searchTerm))
            {
                listProduct = objEcommerce_MVC_2Entities.Product.ToList();
            }
            else
            {
                listProduct = objEcommerce_MVC_2Entities.Product
                                .Where(n => n.Name.Contains(searchTerm))
                                .ToList();
            }
            ViewBag.CurrentFilter = searchTerm;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            listProduct = listProduct.OrderByDescending(n => n.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
      
    }
}