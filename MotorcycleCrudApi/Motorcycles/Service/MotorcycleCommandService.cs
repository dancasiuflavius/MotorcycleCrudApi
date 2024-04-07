using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;
using MotorcycleCrudApi.Motorcycles.Repository;
using MotorcycleCrudApi.Motorcycles.Repository.Interfaces;
using MotorcycleCrudApi.Motorcycles.Service.Interfaces;
using MotorcycleCrudApi.System.Constants;
using MotorcycleCrudApi.System.Exceptions;

namespace MotorcycleCrudApi.Motorcycles.Service
{
    public class MotorcycleCommandService : IMotorcycleComandService
    {
        private IMotorcycleRepository _repository;

        public MotorcycleCommandService(IMotorcycleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Motorcycle> CreateProduct(CreateMotorcycleRequest productRequest)
        {
            if(productRequest.Price < 0)
            {
                throw new InvalidPrice(Constants.INVALID_PRICE);
            }

            Motorcycle product = await _repository.GetByNameAsync(productRequest.Name);

            if(product !=null)
            {
                throw new ItemAlreadyExists(Constants.PRODUCT_ALREADY_EXISTS);
            }

            product = await _repository.CreateAsync(productRequest);
            return product;
        }
        public async Task<Motorcycle> UpdateProduct(int id, UpdateMotorcycleRequest productRequest)
        {
            if (productRequest.Price < 0)
            {
                throw new InvalidPrice(Constants.INVALID_PRICE);
            }

            Motorcycle product = await _repository.GetByIdAsync(productRequest.Id);
            if (product == null)
            {
                throw new ItemDoesNotExist(Constants.PRODUCT_DOES_NOT_EXIST);
            }
            product = await _repository.UpdateAsync(id,productRequest);
            return product;
        }
        public async Task<Motorcycle> DeleteProduct(int id)
        {
            Motorcycle product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ItemDoesNotExist(Constants.PRODUCT_DOES_NOT_EXIST);
            }

            await _repository.DeleteAsync(id);
            return product;
        }
    }
}
