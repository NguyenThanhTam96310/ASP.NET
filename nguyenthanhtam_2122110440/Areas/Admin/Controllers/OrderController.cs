using nguyenthanhtam_2122110440.Context;
using nguyenthanhtam_2122110440.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            var listOrder = objEcommerce_MVC_2Entities.Order.ToList();
            return View(listOrder);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            
            OrderModel objOrderModels = new OrderModel();
            objOrderModels.Order=objEcommerce_MVC_2Entities.Order.Where(n => n.Id == id).FirstOrDefault();
            objOrderModels.OrderDetail=objEcommerce_MVC_2Entities.OrderDetail.Where(n => n.OrderId == id).ToList();
            var productIds = objOrderModels.OrderDetail.Select(od => od.ProductId).Distinct().ToList();
            objOrderModels.lstProduct = objEcommerce_MVC_2Entities.Product
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            return View(objOrderModels);
        }
    }
}