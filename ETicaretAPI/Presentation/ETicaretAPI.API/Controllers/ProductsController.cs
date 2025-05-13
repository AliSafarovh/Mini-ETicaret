using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IFileService _fileService;
        readonly IMediator _mediator;
        public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository, IFileService fileService, IMediator mediator)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] UploadProductImageCommandRequest request)
        {
            UploadProductImageCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteImage([FromForm] RemoveProductImageCommandRequest request)
        {
            RemoveProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetAllProductImages(GetProductImagesQueryRequest request )
        {
            GetProductImagesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
