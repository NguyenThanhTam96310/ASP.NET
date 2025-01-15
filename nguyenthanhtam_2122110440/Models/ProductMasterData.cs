using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace nguyenthanhtam_2122110440.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Vui lòng nhập tên sản phẩm")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDes { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập slug")]
        public string Slug { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [Display(Name = "Mô tả đây đủ")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [Display(Name = "Giá sản phẩm")]
        public double Price { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Thương hiệu")]
        public int BrandId { get; set; }
        [Display(Name = "Giảm giá")]
        public Nullable<double> PriceDiscount { get; set; }
        public bool ShowOnHomePage { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
       
    }
}