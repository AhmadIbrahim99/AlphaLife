using AlphaLife.WebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public interface IResturantService : ICRUD<Resturant>
    {
        Task<List<Resturant>> GetResturantByUserIdAndRoleAsync(string userId);
    }
}
