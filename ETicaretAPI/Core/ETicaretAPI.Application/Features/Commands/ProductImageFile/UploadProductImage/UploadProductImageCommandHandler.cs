using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProduct
{
    //public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    //{
    //    readonly IFileService _fileService;
    //    readonly IProductReadRepository _readRepository;
    //    readonly IProductWriteRepository _writeRepository;
    //    public UploadProductImageCommandHandler(IFileService fileService, IProductReadRepository readRepository, IProductWriteRepository writeRepository)
    //    {
    //        _fileService = fileService;
    //        _readRepository = readRepository;
    //        _writeRepository = writeRepository;
    //    }
    //    public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    //    {
    //        var product = await _readRepository.GetByIdAsync(request.Id);
    //        var uploadResults = await _fileService.UploadAsync("resource/product-images", request.Files);
    //        return new();
    //    }
    //}
}
