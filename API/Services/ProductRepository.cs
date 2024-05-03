using API.Data;
using API.Services.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Product>> Get()
        {
            return await _db.Products.ToListAsync();
        }
        public async Task<Product?> Get(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
