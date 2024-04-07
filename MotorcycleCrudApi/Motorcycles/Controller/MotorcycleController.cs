using Microsoft.AspNetCore.Mvc;
using MotorcycleCrudApi.Motorcycles.Controller.Interfaces;
using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;
using MotorcycleCrudApi.Motorcycles.Repository.Interfaces;
using MotorcycleCrudApi.Motorcycles.Service;
using MotorcycleCrudApi.Motorcycles.Service.Interfaces;
using MotorcycleCrudApi.System.Exceptions;

namespace MotorcyclesCrudApi.Motorcycles.Controller
{
    [ApiController]
    [Route("motorcycles")]

    public class MotorcycleController : MotorcycleApiController
    {
        private readonly ILogger<MotorcycleController> _logger;
        private IMotorcycleQuerryService _productQueryService;
        private IMotorcycleComandService _productCommandService;


        public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleQuerryService productQueryService, IMotorcycleComandService productCommandService)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _productCommandService = productCommandService;
        }



        [HttpGet("api/v1/all")]
        [HttpGet("api/v1/all")]
        public override async Task<ActionResult<IEnumerable<Motorcycle>>> GetProducts()
        {
            try
            {
                var products = await _productQueryService.GetAllProducts();
                return Ok(products);
            }
            catch (ItemsDoNotExist ex)
            {
                return NotFound(ex.Message);
            }


        }


        //[HttpGet("api/v1/getName/{name}")]
        //public async Task<ActionResult<Product>> GetName([FromRoute] string name)
        //{
        //    var product = await _productRepository.GetByNameAsync(name);
        //    return Ok(product);
        //}
        //[HttpGet("api/v1/getAllByPrice")]
        //public async Task<ActionResult<Double>> GetAllAsyncPrice()
        //{
        //    var productPrices = await _productRepository.GetAllAsyncPrice();
        //    return Ok(productPrices);
        //}

        //[HttpPost("api/v1/create")]

        public override async Task<ActionResult<Motorcycle>> CreateProduct(CreateMotorcycleRequest productRequest)
        {
            _logger.LogInformation(message: $"Rest request: Create product with DTO:\n{productRequest}");
            try
            {
                var product = await _productCommandService.CreateProduct(productRequest);

                return Ok(product);
            }
            catch (InvalidPrice ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ItemAlreadyExists ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }



        }
        // [HttpPut("api/v1/update")]
        public override async Task<ActionResult<Motorcycle>> UpdateProduct([FromQuery] int id, [FromBody] UpdateMotorcycleRequest request)
        {
            _logger.LogInformation(message: $"Rest request: Create product with DTO:\n{request}");
            try
            {

                Motorcycle response = await _productCommandService.UpdateProduct(id, request);

                return Accepted(response);
            }
            catch (InvalidPrice ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        //[HttpDelete("api/v1/delete")]
        public override async Task<ActionResult<Motorcycle>> DeleteProduct([FromQuery] int id)
        {
            _logger.LogInformation(message: $"Rest request: Delete product with id:\n{id}");
            try
            {
                Motorcycle product = await _productCommandService.DeleteProduct(id);

                return Ok(product);
            }
            catch (ItemDoesNotExist ex)
            {
                _logger.LogError(ex.Message + $"Error while trying to delete product: \n{id}");
                return NotFound(ex.Message);
            }
        }
    }
}
