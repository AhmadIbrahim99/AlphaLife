using AlphaLife.WebApplication.Models;
using System.Collections.Generic;

namespace AlphaLife.WebApplication.Data.ViewModels
{
    public class NewProductDropDownsVM
    {
        public NewProductDropDownsVM()
        {
            Resturants = new List<Resturant>();
            Categories = new List<Category>();
        }
        public List<Category> Categories { get; set; }
        public List<Resturant> Resturants { get; set; }
    }
}
