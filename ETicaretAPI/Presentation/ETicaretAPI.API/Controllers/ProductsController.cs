using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
            var data=await _readRepository.GetAll().ToListAsync();
            return Ok(data);
            //await _writeRepository.AddRangeAsync(new()
            //{
            //    new() { Id=Guid.NewGuid(), Name="P1",Price=1,CreatedDate=DateTime.UtcNow,Stock=5},
            //    new() { Id=Guid.NewGuid(), Name="P2",Price=1,CreatedDate=DateTime.UtcNow,Stock=5},
            //    new() { Id=Guid.NewGuid(), Name="P3",Price=1,CreatedDate=DateTime.UtcNow,Stock=5},
                
            //});
            //var count=await _writeRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            Product product =await _readRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
