using ETicaretAPI.Application.Repositories;
using MediatR;
using p = ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductWriteRepository _writeRepository;
        readonly IProductReadRepository _readRepository;
        public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            p.Product product = await _readRepository.GetByIdAsync(request.Id);
            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;
            await _writeRepository.SaveAsync();
            return new ();
        }
    }
}
