using nguyenthanhtam_2122110440.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Areas.Admin.Controllers
{
    public class UserAdminController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Admin/UserAdmin
        public ActionResult Index()
        {
            var listUser = objEcommerce_MVC_2Entities.User.ToList();
            return View(listUser);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = objEcommerce_MVC_2Entities.User.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    objEcommerce_MVC_2Entities.Configuration.ValidateOnSaveEnabled = false;
                    objEcommerce_MVC_2Entities.User.Add(_user);
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại.";
                    return View();
                }


            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objUser = objEcommerce_MVC_2Entities.User.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = objEcommerce_MVC_2Entities.User.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Delete(User objCate)
        {
            var objUser = objEcommerce_MVC_2Entities.User.Where(n => n.Id == objCate.Id).FirstOrDefault();
            objEcommerce_MVC_2Entities.User.Remove(objUser);
            objEcommerce_MVC_2Entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = objEcommerce_MVC_2Entities.User.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = objEcommerce_MVC_2Entities.User.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    objEcommerce_MVC_2Entities.Configuration.ValidateOnSaveEnabled = false;
                    objEcommerce_MVC_2Entities.Entry(_user).State = EntityState.Modified;
                    objEcommerce_MVC_2Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại.";
                    return View();
                }


            }
            return View();
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}