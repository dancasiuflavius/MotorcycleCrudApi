using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;

namespace MotorcycleCrudApi.Motorcycles.Repository.Interfaces
{
    public interface IMotorcycleRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync();
        Task<Motorcycle> GetByNameAsync(string name);

        Task<IEnumerable<Double>> GetAllAsyncPrice();
        //Task<Product> GetByIdAsync(int id);
        Task<Motorcycle> CreateAsync(CreateMotorcycleRequest carRequest);
        //Task<Product> UpdateAsync(int id, UpdateProductRequest productRequest);
        //Task DeleteAsync(int id);
    }
}
