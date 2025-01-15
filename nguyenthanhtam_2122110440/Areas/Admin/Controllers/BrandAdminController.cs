using nguyenthanhtam_2122110440.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Areas.Admin.Controllers
{
    public class BrandAdminController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Admin/BrandAdmin
        public ActionResult Index()
        {
            var listBrand = objEcommerce_MVC_2Entities.Brand.ToList();
            return View(listBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/brand/"), fileName));
                    }
                    objBrand.UpdateDate = DateTime.Now;
                    objBrand.CreatedBy = "Admin";
                    objBrand.CreatedDate = DateTime.Now;
                    objBrand.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Brand.Add(objBrand);
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();

                }
            }
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = objEcommerce_MVC_2Entities.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objEcommerce_MVC_2Entities.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand objCate)
        {
            var objBrand = objEcommerce_MVC_2Entities.Brand.Where(n => n.Id == objCate.Id).FirstOrDefault();
            objEcommerce_MVC_2Entities.Brand.Remove(objBrand);
            objEcommerce_MVC_2Entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objEcommerce_MVC_2Entities.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(Brand objBrand)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/brand/"), fileName));
                    }
                    objBrand.UpdateDate = DateTime.Now;
                    objBrand.CreatedBy = "Admin";
                    objBrand.CreatedDate = DateTime.Now;
                    objBrand.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Entry(objBrand).State = EntityState.Modified;
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(objBrand);
        }
    }
}