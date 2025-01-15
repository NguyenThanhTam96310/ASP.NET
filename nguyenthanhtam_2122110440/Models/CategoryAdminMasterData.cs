using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nguyenthanhtam_2122110440.Models
{
    public class CategoryAdminMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập slug")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public bool ShowOnHomePage { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}