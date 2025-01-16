using nguyenthanhtam_2122110440.Context;
using nguyenthanhtam_2122110440.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440.Controllers
{
    public class PaymentController : Controller
    {
        Ecommerce_MVC_2Entities objEcommerce_MVC_2Entities = new Ecommerce_MVC_2Entities();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];

                //gán dl cho order
                Order objOrder=new Order();
                objOrder.Name = "Donhang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedDate = DateTime.Now;
                objOrder.Status = 1;
                objEcommerce_MVC_2Entities.Order.Add(objOrder);
                objEcommerce_MVC_2Entities.SaveChanges();

                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.ProductId = item.Product.Id;
                    obj.OrderId = intOrderId;
                    lstOrderDetail.Add(obj);
                }
                objEcommerce_MVC_2Entities.OrderDetail.AddRange(lstOrderDetail);
                objEcommerce_MVC_2Entities.SaveChanges();
            }
            return View();
        }
    }
}