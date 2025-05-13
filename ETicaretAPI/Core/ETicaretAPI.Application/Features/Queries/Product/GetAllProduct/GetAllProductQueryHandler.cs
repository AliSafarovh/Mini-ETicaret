using ETicaretAPI.Application.RequestParametrs;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _readRepository;
        public GetAllProductQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _readRepository.GetAll(false).Count();
            var products = _readRepository.GetAll(false)
            .Skip(request.Page * request.Size) //ilk n mehsulu atla
                .Take(request.Size).Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                }).ToList();
            return new()
            {
                Products=products,
                TotalCount=totalCount
            };
        }
    }
}
