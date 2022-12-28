using AlphaLife.WebApplication.Data;
using AlphaLife.WebApplication.Models;

namespace AlphaLife.WebApplication.Services
{
    public class CategoryService : CRUD<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
