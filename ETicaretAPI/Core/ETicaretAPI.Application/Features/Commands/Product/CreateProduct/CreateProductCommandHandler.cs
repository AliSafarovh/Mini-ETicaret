using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _writeRepository;
        public CreateProductCommandHandler(IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
                {
                Name=request.Name,
                Stock=request.Stock,
                Price=request.Price,
            });
            await _writeRepository.SaveAsync();
            return new CreateProductCommandResponse();
        }
    }
}
