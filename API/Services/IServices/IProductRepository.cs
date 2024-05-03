using Domain;

namespace API.Services.IServices
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product?> Get(int id);
    }
}