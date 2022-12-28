using AlphaLife.WebApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaLife.WebApplication.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "صورة المنتج")]
        [Required(ErrorMessage = "الرجاء إدخال رابط الصورة")]
        public string Image { get; set; }
        [Display(Name = "اسم المنتج بالعربي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم المنتج بالعربي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameAR { get; set; }
        [Display(Name = "اسم المنتج بالإنجليزي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم المنتج بالإنجليزي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameEN { get; set; }
        [Display(Name = "وصف المنتج")]
        [Required(ErrorMessage = "الرجاء إدخال وصف للمنتج")]
        public string Description { get; set; }
        [Display(Name = "السعر")]
        [Required(ErrorMessage = "الرجاء إدخال سعر المنتج")]
        public double Price { get; set; }
        [Display(Name = "% الخصم")]
        [Range(0,100,ErrorMessage ="الخصم ما بين 0 إلى 100 % نسبة مئوية")]
        public double OnSale { get; set; }
        [Display(Name = "السعر بعد الخصم")]
        public double SalePrice { get; set; }
        [Display(Name = "تاريخ العرض")]
        [Required(ErrorMessage = "الرجاء إدخال تاريخ العرض")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "الرجاء إدخال تاريخ الإنتهاء")]
        public DateTime EndDate { get; set; }
        [Display(Name = "المطعم")]
        [Required(ErrorMessage = "يجب اختيار المطعم")]
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public List<Product_Category> Product_Categories{ get; set; }
    }
}
