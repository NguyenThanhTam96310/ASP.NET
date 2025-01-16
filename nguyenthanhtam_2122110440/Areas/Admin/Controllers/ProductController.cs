using nguyenthanhtam_2122110440.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static nguyenthanhtam_2122110440.Common;

namespace nguyenthanhtam_2122110440.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Admin/Product
        public ActionResult Index(string SearchString,string CurrentFilter,int? page)
        {
           var listProduct =new List<Product>();

            if (SearchString!=null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            if (string.IsNullOrEmpty(SearchString))
            {
                listProduct = objEcommerce_MVC_2Entities.Product.ToList();
            }
            else
            {
                listProduct = objEcommerce_MVC_2Entities.Product
                                .Where(n => n.Name.Contains(SearchString))
                                .ToList();
            }
            ViewBag.CurrentFilter=SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listProduct=listProduct.OrderByDescending(n=>n.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.loadData();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.loadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }
                    objProduct.UpdateDate = DateTime.Now;
                    objProduct.CreatedBy = "Admin";
                    objProduct.CreatedDate = DateTime.Now;
                    objProduct.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Product.Add(objProduct);
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();

                }
            }
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct=objEcommerce_MVC_2Entities.Product.Where(n=>n.Id== id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objEcommerce_MVC_2Entities.Product.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objEcommerce_MVC_2Entities.Product.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objEcommerce_MVC_2Entities.Product.Remove(objProduct);
            objEcommerce_MVC_2Entities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objEcommerce_MVC_2Entities.Product.Where(n => n.Id == id).FirstOrDefault();
            this.loadData();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            this.loadData();
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }
                    objProduct.UpdateDate = DateTime.Now;
                    objProduct.CreatedBy = "Admin";
                    objProduct.CreatedDate = DateTime.Now;
                    objProduct.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Entry(objProduct).State = EntityState.Modified;
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(objProduct);
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