using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using p=ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Services.Repositories;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProduct
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductImageFileWriteRepository _productImageWriteRepository;

        public UploadProductImageCommandHandler(
            IFileService fileService,
            IProductReadRepository readRepository,
            IProductWriteRepository writeRepository,
            IProductImageFileWriteRepository productImageWriteRepository)
        {
            _fileService = fileService;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _productImageWriteRepository = productImageWriteRepository;
        }
        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _readRepository.GetByIdAsync(request.Id);
            var fileNames = await _fileService.UploadAsync(request.Files, "wwwroot/resource/product-images");

            List<p.ProductImageFile> productImageFiles = fileNames.Select(fileName => new p.ProductImageFile
            {
                FileName = fileName,
                Path = $"resource/product-images/{fileName}",
                Product = product
            }).ToList();
            await _productImageWriteRepository.AddRangeAsync(productImageFiles);
            await _writeRepository.SaveAsync();

            return new();
        }
    }
}
