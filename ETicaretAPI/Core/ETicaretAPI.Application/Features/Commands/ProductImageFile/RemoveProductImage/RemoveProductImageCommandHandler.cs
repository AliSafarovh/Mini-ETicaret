using ETicaretAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProduct
{
    //public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    //{
    //    private readonly IFileService _fileService;

    //    public RemoveProductImageCommandHandler(IFileService fileService)
    //    {
    //        _fileService = fileService;
    //    }
    //    public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
    //    {
    //        string folder = "resource/product-images";
    //        await _fileService.DeleteAsync("resource/product-images", request.FileName);
    //        return new ();
    //    }
    //}
}
