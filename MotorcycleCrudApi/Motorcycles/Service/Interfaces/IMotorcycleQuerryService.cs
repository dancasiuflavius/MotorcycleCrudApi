using MotorcycleCrudApi.Motorcycles.Model;

namespace MotorcycleCrudApi.Motorcycles.Service.Interfaces
{
    public interface IMotorcycleQuerryService
    {
        Task<IEnumerable<Motorcycle>> GetAllProducts();
        Task<IEnumerable<Motorcycle>> GetProductsWithCategory(string category);
        Task<IEnumerable<Motorcycle>> GetProductsWithNoCategory();
        Task<IEnumerable<Motorcycle>> GetProductsInPriceRange(double min, double max);
        Task<Motorcycle> GetProductById(int id);
    }
}
