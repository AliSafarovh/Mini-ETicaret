using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetImagesByProductIdQueryHandler : IRequestHandler<GetImagesByProductIdQueryRequest, GetImagesByProductIdQueryResponse>
    {
        private readonly IFileService _fileService;

        public GetImagesByProductIdQueryHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<GetImagesByProductIdQueryResponse> Handle(GetImagesByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var imagePaths = await _fileService.GetFileByProductIdAsync(request.ProductId);

            return new GetImagesByProductIdQueryResponse
            {
                ImagePaths = imagePaths
            };
        }
    }
}
