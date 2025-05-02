using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParametrs;
using ETicaretAPI.Application.ViewModels.Product;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;

        public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] Pagination pagination)
        {
            var product = _readRepository.GetAll(false);
            var totalCount = product.Count();
            var pageData = product
                .Skip(pagination.Page * pagination.Size) //ilk n mehsulu atla
                .Take(pagination.Size)                   //novbeti n mehsulu gotur
                .ToList();

            return Ok(new
            {
                totalCount,
                data = pageData
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Product product = await _readRepository.GetByIdAsync(id,false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(VM_Create_Product model)
        {
            await _writeRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = 15,
                Stock = 5
            });
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(VM_Update_Product model)
        {
            Product product = await _readRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _writeRepository.DeleteAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }

    }
}
