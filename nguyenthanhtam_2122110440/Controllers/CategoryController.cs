using nguyenthanhtam_2122110440.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static nguyenthanhtam_2122110440.Common;

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
        public ActionResult ProductCategory(int Id, string CurrentFilter, int? page)
        {
            var listProduct = objEcommerce_MVC_2Entities.Product.Where(n => n.CategoryId == Id).ToList();

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                listProduct = objEcommerce_MVC_2Entities.Product
                                 .Where(n => n.Name.Contains(CurrentFilter) && n.CategoryId == Id)
                                 .ToList();
            }

            ViewBag.CurrentFilter = CurrentFilter;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listProduct = listProduct.OrderByDescending(n => n.Id).ToList();
            Common objCommon = new Common();
            //gọi cate từ db
            var Cate = objEcommerce_MVC_2Entities.Category.Where(n=>n.Id==Id).FirstOrDefault();
            ListToDataTableConverter converter = new ListToDataTableConverter();
            ViewBag.nameCategory = Cate.Name;

            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
        
    }
}