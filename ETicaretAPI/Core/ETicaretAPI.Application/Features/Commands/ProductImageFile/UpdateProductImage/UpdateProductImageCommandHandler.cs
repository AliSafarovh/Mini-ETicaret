using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProductImage
{
    //public class UpdateProductImageCommandHandler
    //{
    //    private readonly IProductReadRepository _productReadRepository;
    //    private readonly IProductWriteRepository _productWriteRepository;
    //    private readonly IFileService _fileService;

    //    public UpdateProductImageCommandHandler(
    //        IProductReadRepository productReadRepository,
    //        IProductWriteRepository productWriteRepository,
    //        IFileService fileService)
    //    {
    //        _productReadRepository = productReadRepository;
    //        _productWriteRepository = productWriteRepository;
    //        _fileService = fileService;
    //    }

    //    public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
    //    {
    //        var product = await _productReadRepository.Table
    //            .Include(p => p.ProductImageFiles)
    //            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.ProductId), cancellationToken);

    //        var productImage = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

    //        if (productImage == null)
    //            throw new Exception("Şəkil tapılmadı.");

    //        string rootPath = "wwwroot/images/product"; // düz yoldur: öz layihəndə necədirsə onu yaz
    //        string oldFilePath = Path.Combine(rootPath, productImage.Path);

    //        string newFileName = await _fileService.UpdateAsync(request.FormFile, oldFilePath, rootPath);

    //        productImage.FileName = newFileName;
    //        productImage.Path = newFileName;

    //        await _productWriteRepository.SaveAsync();

    //        return new UpdateProductImageCommandResponse();
    //    }
    //}
}
