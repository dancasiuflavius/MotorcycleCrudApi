using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;
using Microsoft.AspNetCore.Mvc;

namespace MotorcycleCrudApi.Motorcycles.Controller.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class MotorcycleApiController : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(statusCode: 200, type: typeof(List<Motorcycle>))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<IEnumerable<Motorcycle>>> GetProducts();

    [HttpPost("create")]
    [ProducesResponseType(statusCode: 200, type: typeof(Motorcycle))]
    [ProducesResponseType(statusCode: 400, type: typeof(String))]
    public abstract Task<ActionResult<Motorcycle>> CreateProduct([FromBody] CreateMotorcycleRequest productRequest);

    [HttpPut("update")]
    [ProducesResponseType(statusCode: 200, type: typeof(Motorcycle))]
    [ProducesResponseType(statusCode: 400, type: typeof(String))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<Motorcycle>> UpdateProduct([FromQuery] int id, [FromBody] UpdateMotorcycleRequest productRequest);

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(statusCode: 200, type: typeof(Motorcycle))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<Motorcycle>> DeleteProduct([FromRoute] int id);
}
