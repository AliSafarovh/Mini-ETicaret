using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest productQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(productQueryRequest);
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest productQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(productQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest productCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(productCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest productCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(productCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] RemoveProductCommandRequest productCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(productCommandRequest);
            return Ok(response);
        }

        
    }
}
