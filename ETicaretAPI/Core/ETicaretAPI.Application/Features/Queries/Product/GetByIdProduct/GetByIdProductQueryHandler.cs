using ETicaretAPI.Application.Repositories;
using MediatR;
using P=ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _readRepository;
        public GetByIdProductQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetByIdProductQueryResponse
            {
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
            };
        }
    }
}
