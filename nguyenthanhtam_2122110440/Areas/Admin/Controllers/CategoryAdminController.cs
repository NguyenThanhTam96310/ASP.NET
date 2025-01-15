using nguyenthanhtam_2122110440.Context;
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
    public class CategoryAdminController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Admin/CategoryAdmin
        public ActionResult Index()
        {
            var listCate = objEcommerce_MVC_2Entities.Category.ToList();
            return View(listCate);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/cate/"), fileName));
                    }
                    objCategory.UpdateDate = DateTime.Now;
                    objCategory.CreatedBy = "Admin";
                    objCategory.CreatedDate = DateTime.Now;
                    objCategory.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Category.Add(objCategory);
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                } 
                catch (Exception)
                {
                    return View();

                }
            }
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = objEcommerce_MVC_2Entities.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = objEcommerce_MVC_2Entities.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objCate)
        {
            var objCategory = objEcommerce_MVC_2Entities.Category.Where(n => n.Id == objCate.Id).FirstOrDefault();
            objEcommerce_MVC_2Entities.Category.Remove(objCategory);
            objEcommerce_MVC_2Entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = objEcommerce_MVC_2Entities.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/cate/"), fileName));
                    }
                    objCategory.UpdateDate = DateTime.Now;
                    objCategory.CreatedBy = "Admin";
                    objCategory.CreatedDate = DateTime.Now;
                    objCategory.UpdateBy = "Admin";
                    objEcommerce_MVC_2Entities.Entry(objCategory).State = EntityState.Modified;
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(objCategory);
        }
    }
}