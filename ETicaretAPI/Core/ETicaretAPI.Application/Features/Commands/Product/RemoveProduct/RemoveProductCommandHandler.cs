using ETicaretAPI.Application.Repositories;
using MediatR;
using p = ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        readonly IProductReadRepository _readRepository;
        readonly IProductWriteRepository _writeRepository;
        public RemoveProductCommandHandler(IProductReadRepository readRepository,IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.DeleteAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
