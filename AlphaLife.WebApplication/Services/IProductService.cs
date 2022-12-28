using AlphaLife.WebApplication.Data.ViewModels;
using AlphaLife.WebApplication.Models;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public interface IProductService : ICRUD<Product>
    {
        Task<Product> GetProductById(int id);
        Task UpdateProduct(NewProdcutVM entity);
        Task AddNewProduct(NewProdcutVM entity);
    }
}
