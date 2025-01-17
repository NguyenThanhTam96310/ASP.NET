using nguyenthanhtam_2122110440.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nguyenthanhtam_2122110440.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public List<Product> lstProduct { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

    }
}