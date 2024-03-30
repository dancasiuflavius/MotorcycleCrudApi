using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotorcycleCrudApi.Data;
using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;
using MotorcycleCrudApi.Motorcycles.Repository.Interfaces;

namespace MotorcycleCrudApi.Motorcycles.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public MotorcycleRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<IEnumerable<Motorcycle>> GetAllAsync()
        {
            return await _context.Motorcycles.ToListAsync();
        }
        public async Task<Motorcycle> GetByNameAsync(string name)
        {
            return await _context.Motorcycles.FirstOrDefaultAsync(car => car.Name.Equals(name));

        }
        public async Task<IEnumerable<Double>> GetAllAsyncPrice()
        {

            return await _context.Motorcycles.Select(product => product.Price).ToListAsync();
        }

        public async Task<Motorcycle> CreateAsync(CreateMotorcycleRequest carRequest)
        {

            var car = _mapper.Map<Motorcycle>(carRequest);


            _context.Motorcycles.Add(car);

            await _context.SaveChangesAsync();

            return car;

        }
    }
}
