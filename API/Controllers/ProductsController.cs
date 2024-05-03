using API.Data;
using API.Services.IServices;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var model = await _repository.Get(id);
            if (model is null)
            {
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(model);
        }
    }
}
