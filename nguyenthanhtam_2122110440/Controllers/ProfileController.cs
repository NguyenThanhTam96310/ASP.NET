using nguyenthanhtam_2122110440.Context;
using nguyenthanhtam_2122110440.Models;
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
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();

        public ActionResult Orders()
        {
            List<UserOrderModel> objUserOrderModels = new List<UserOrderModel>();
            int userId = Convert.ToInt32(Session["idUser"]);
            var orders = objEcommerce_MVC_2Entities.Order.Where(n => n.UserId == userId).ToList();

            if (orders != null && orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    var orderDetails = objEcommerce_MVC_2Entities.OrderDetail.Where(n => n.OrderId == order.Id).ToList();
                    var productIds = orderDetails.Select(od => od.ProductId).Distinct().ToList();
                    var products = objEcommerce_MVC_2Entities.Product.Where(p => productIds.Contains(p.Id)).ToList();
                    var userOrderModel = new UserOrderModel
                    {
                        lstOrder = new List<Order> { order },
                        OrderDetail = orderDetails,
                        lstProduct = products
                    };

                    objUserOrderModels.Add(userOrderModel);
                }
            }
            return View(objUserOrderModels);
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