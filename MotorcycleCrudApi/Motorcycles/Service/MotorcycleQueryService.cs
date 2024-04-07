using MotorcycleCrudApi.Motorcycles.Model;
using MotorcycleCrudApi.Motorcycles.Repository;
using MotorcycleCrudApi.Motorcycles.Repository.Interfaces;
using MotorcycleCrudApi.Motorcycles.Service.Interfaces;
using MotorcycleCrudApi.System.Constants;
using MotorcycleCrudApi.System.Exceptions;

namespace MotorcycleCrudApi.Motorcycles.Service;

public class MotorcycleQueryService : IMotorcycleQuerryService
{
    private IMotorcycleRepository _repository;

    public MotorcycleQueryService(IMotorcycleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Motorcycle>> GetAllProducts()
    {
        IEnumerable<Motorcycle> products = await _repository.GetAllAsync();

        if (products.Count() == 0)
        {
            throw new ItemsDoNotExist(Constants.NO_PRODUCTS_EXIST);
        }

        return products;
    }

    public async Task<IEnumerable<Motorcycle>> GetProductsWithCategory(string category)
    {
        IEnumerable<Motorcycle> products = (await _repository.GetAllAsync())
            .Where(product => product.Category.Equals(category));

        if (products.Count() == 0)
        {
            throw new ItemsDoNotExist(Constants.NO_PRODUCTS_EXIST);
        }

        return products;
    }

    public async Task<IEnumerable<Motorcycle>> GetProductsWithNoCategory()
    {
        IEnumerable<Motorcycle> products = (await _repository.GetAllAsync())
            .Where(product => product.Category == null!);

        if (products.Count() == 0)
        {
            throw new ItemsDoNotExist(Constants.NO_PRODUCTS_EXIST);
        }

        return products;
    }

    public async Task<IEnumerable<Motorcycle>> GetProductsInPriceRange(double min, double max)
    {
        IEnumerable<Motorcycle> products = (await _repository.GetAllAsync())
            .Where(product => product.Price >= min && product.Price <= max);

        if (products.Count() == 0)
        {
            throw new ItemsDoNotExist(Constants.NO_PRODUCTS_EXIST);
        }

        return products;
    }

    public async Task<Motorcycle> GetProductById(int id)
    {
        Motorcycle product = await _repository.GetByIdAsync(id);

        if (product == null)
        {
            throw new ItemDoesNotExist(Constants.PRODUCT_DOES_NOT_EXIST);
        }

        return product;
    }
}
