using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage.GetProductImagesQueryResponse;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    //public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, GetProductImagesQueryResponse>
    //{
    //    private readonly IFileService _fileService;

    //    public GetProductImagesQueryHandler(IFileService fileService)
    //    {
    //        _fileService = fileService;
    //    }

    //    public async Task<GetProductImagesQueryResponse> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
    //    {
    //        var images = await _fileService.GetAllImagesAsync($"resource/product-images/{request.Id}");
    //        return new();
    //    }
    //}
}
