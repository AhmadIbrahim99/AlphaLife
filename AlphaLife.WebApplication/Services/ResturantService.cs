using AlphaLife.WebApplication.Data;
using AlphaLife.WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public class ResturantService : CRUD<Resturant>, IResturantService
    {
        private readonly ApplicationDbContext _context;
        public ResturantService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Resturant>> GetResturantByUserIdAndRoleAsync(string userId)
        {
            var resturants = await _context.Resturants.ToListAsync();
            if (userId != null)
            {
                resturants = resturants.Where(x => x.UserId == userId).ToList();
            }

            return resturants;
        }
    }
}
