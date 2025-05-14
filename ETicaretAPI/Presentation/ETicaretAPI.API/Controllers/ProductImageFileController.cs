using ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProductImage;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IFileService _fileService;
        readonly IMediator _mediator;

        public ProductImageFileController(IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] UploadProductImageCommandRequest request)
        {
            UploadProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteImage([FromForm] RemoveProductImageCommandRequest request)
        {
            RemoveProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetAllProductImages(GetProductImagesQueryRequest request)
        {
            GetProductImagesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("update-image")]
        public async Task<IActionResult> UpdateImage([FromForm] UpdateProductImageCommandRequest request)
        {
            UpdateProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
