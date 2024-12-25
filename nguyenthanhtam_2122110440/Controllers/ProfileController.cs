using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Seller()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }
    }
}