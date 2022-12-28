using AlphaLife.WebApplication.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaLife.WebApplication.Models
{
    public class Resturant : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "رقم الجوال")]
        [Required(ErrorMessage ="الرجاء إدخال الرقم")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "يجب أن يحتوي على 10 أرقام")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رقم الواتس اب مع مقدمة الدولة")]
        [Required(ErrorMessage = "الرجاء إدخال الرقم")]
        public string WhatsAppNumber { get; set; }
        [Display(Name = "صورة المتجر")]
        [Required(ErrorMessage = "الرجاء إدخال رابط الصورة")]
        public string Image { get; set; }
        [Display(Name = "اسم المتجر بالعربي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم المتجر بالعربي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameAR { get; set; }
        [Display(Name = "اسم المتجر بالإنجليزي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم المتجر بالإنجليزي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameEN { get; set; }
        [Display(Name = "وصف المتجر")]
        [Required(ErrorMessage = "الرجاء إدخال وصف للمتجر")]
        public string Description { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public List<Product> Products{ get; set; }
    }
}
