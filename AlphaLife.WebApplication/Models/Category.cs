using AlphaLife.WebApplication.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaLife.WebApplication.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "صورة التصنيف")]
        [Required(ErrorMessage = "الرجاء إدخال رابط الصورة")]
        public string Image { get; set; }
        [Display(Name = "اسم التصنيف بالعربي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم التصنيف بالعربي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameAR { get; set; }
        [Display(Name = "اسم التصنيف بالإنجليزي")]
        [Required(ErrorMessage = "الرجاء إدخال اسم التصنيف بالإنجليزي")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يكون الاسم بين 2|50 حرفاً")]
        public string NameEN { get; set; }
        [Display(Name = "وصف التصنيف")]
        [Required(ErrorMessage = "الرجاء إدخال وصف للتصنيف")]
        public string Description { get; set; }
        public List<Product_Category> Product_Categories { get; set; }
    }
}
