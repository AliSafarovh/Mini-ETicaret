using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetImagesByProductIdQueryRequest : IRequest<GetImagesByProductIdQueryResponse>
    {
        public string ProductId { get; set; }

    }

}
