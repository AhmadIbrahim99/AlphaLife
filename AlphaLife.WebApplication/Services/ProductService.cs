using AlphaLife.WebApplication.Data;
using AlphaLife.WebApplication.Data.ViewModels;
using AlphaLife.WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public class ProductService : CRUD<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;
        
        public ProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewProduct(NewProdcutVM entity)
        {
            var product = new Product() 
            {
                NameAR = entity.NameAR,
                NameEN = entity.NameEN,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Image = entity.Image,
                Price = entity.Price,
                SalePrice = entity.SalePrice,
                ResturantId = entity.ResturantId,
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            foreach (var catId in entity.CategoriesIds)
            {
                var product_category = new Product_Category() { 
                CategoryId = catId,
                ProductId = product.Id
                };
                await _context.Products_Categories.AddAsync(product_category);
            }
            await _context.SaveChangesAsync();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProduct(NewProdcutVM entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
