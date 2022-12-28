using AlphaLife.WebApplication.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaLife.WebApplication.Data.ViewModels
{
    public class NewProdcutVM : Product
    {
        [Display(Name = "اختار التصنيفات")]
        [Required(ErrorMessage = "إختر تصنيف على الأقل")]
        public List<int> CategoriesIds { get; set; }
    }
}
