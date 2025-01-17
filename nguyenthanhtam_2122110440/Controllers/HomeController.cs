using nguyenthanhtam_2122110440.Context;
using nguyenthanhtam_2122110440.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static nguyenthanhtam_2122110440.Common;

namespace nguyenthanhtam_2122110440.Controllers
{
    public class HomeController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        public ActionResult Index()
        {
            HomeModels objHomeModels=new HomeModels();

            objHomeModels .ListCategory= objEcommerce_MVC_2Entities.Category.ToList();
            objHomeModels .ListProduct=objEcommerce_MVC_2Entities.Product.ToList();    
            return View(objHomeModels);
        }
        public PartialViewResult GetCategories()
        {
            var categories = objEcommerce_MVC_2Entities.Category.ToList();
            return PartialView("_CategoryList", categories);
        }
        void loadData()
        {
            Common objCommon = new Common();
            //gọi cate từ db
            var lstCat = objEcommerce_MVC_2Entities.Category.ToList();
            ListToDataTableConverter converter = new ListToDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");


            //gọi brand từ db
            var lstBrand = objEcommerce_MVC_2Entities.Brand.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //chọn dạng typeId
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProducType = new ProductType();
            objProducType.Id = 01;
            objProducType.Name = "Giảm giá sốc";
            lstProductType.Add(objProducType);

            objProducType = new ProductType();
            objProducType.Id = 02;
            objProducType.Name = "Đề xuất";
            lstProductType.Add(objProducType);


            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

    }

}