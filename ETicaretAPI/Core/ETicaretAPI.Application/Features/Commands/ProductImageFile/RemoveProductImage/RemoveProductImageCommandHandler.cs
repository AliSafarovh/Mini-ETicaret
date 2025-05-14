using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProduct
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IFileService _fileService;

        public RemoveProductImageCommandHandler(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IFileService fileService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _fileService = fileService;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            // Id-ləri parse edirik və yoxlayırıq
            if (!Guid.TryParse(request.Id, out Guid productId) || !Guid.TryParse(request.ImageId, out Guid imageId))
                throw new ArgumentException("Yanlış formatda ID göndərildi.");

            // Məhsulu şəkilləri ilə birlikdə DB-dən alırıq
            var product = await _productReadRepository.Table
                .Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

            if (product == null)
                throw new Exception("Məhsul tapılmadı.");

            // Silinəcək şəkli tapırıq
            var productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == imageId);
            if (productImageFile == null)
                throw new Exception("Şəkil tapılmadı.");

            // Fiziki yol
            string path = productImageFile.Path.TrimStart('/', '\\');
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);

            // Faylı silirik
            _fileService.Delete(fullPath);

            // DB-dən şəkli silirik
            product.ProductImageFiles.Remove(productImageFile);
            await _productWriteRepository.SaveAsync();

            return new RemoveProductImageCommandResponse
            {
                Message = "Şəkil uğurla silindi."
            };
        }
    }
}
