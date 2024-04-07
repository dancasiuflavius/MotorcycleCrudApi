using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;


namespace MotorcycleCrudApi.Motorcycles.Service.Interfaces;


public interface IMotorcycleComandService
{
    Task<Motorcycle> CreateProduct(CreateMotorcycleRequest productRequest);

    Task<Motorcycle> UpdateProduct(int id, UpdateMotorcycleRequest productRequest);

    Task<Motorcycle> DeleteProduct(int id);
}
