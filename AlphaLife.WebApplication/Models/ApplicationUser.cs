using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaLife.WebApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "الاسم كامل")]
        public string FullName { get; set; }
        public List<Resturant> Resturants { get; set; }
    }
}
