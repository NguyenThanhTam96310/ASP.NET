//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nguyenthanhtam_2122110440.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string ShortDes { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }
        public Nullable<int> TypeId { get; set; }
        public int BrandId { get; set; }
        public Nullable<double> PriceDiscount { get; set; }
        public bool ShowOnHomePage { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        //[NotMapped]
        //public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }

}
