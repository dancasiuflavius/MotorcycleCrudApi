using Microsoft.AspNetCore.Mvc;
using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;
using MotorcycleCrudApi.Motorcycles.Repository;
using MotorcycleCrudApi.Motorcycles.Repository.Interfaces;

namespace CarsCrudApi.Cars.Controller
{
    [ApiController]
    [Route("bikes")]

    public class MotorcycleController : ControllerBase
    {
        private readonly ILogger<MotorcycleController> _logger;

        private readonly IMotorcycleRepository _carRepository;

        public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }



        [HttpGet("api/v1/all")]
        public async Task<ActionResult<IEnumerable<Motorcycle>>> GetAll()
        {

            var products = await _carRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("api/v1/getName/{name}")]
        public async Task<ActionResult<Motorcycle>> GetName([FromRoute] string name)
        {
            var product = await _carRepository.GetByNameAsync(name);
            return Ok(product);
        }
        [HttpGet("api/v1/getAllByPrice")]
        public async Task<ActionResult<Double>> GetAllAsyncPrice()
        {
            var cars = await _carRepository.GetAllAsyncPrice();
            return Ok(cars);
        }
        [HttpPost("api/v1/create")]

        public async Task<ActionResult<Motorcycle>> CreateProduct([FromBody] CreateMotorcycleRequest createCarRequest)
        {
            var product = await _carRepository.CreateAsync(createCarRequest);


            return Ok(product);

        }
    }
}
