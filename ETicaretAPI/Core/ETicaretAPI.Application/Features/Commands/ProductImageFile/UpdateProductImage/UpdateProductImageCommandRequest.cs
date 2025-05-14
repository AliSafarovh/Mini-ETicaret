using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UpdateProductImage
{
    public class UpdateProductImageCommandRequest:IRequest<UpdateProductImageCommandResponse>
    {
        public string ProductId { get; set; } = null!;
        public string ImageId { get; set; } = null!;
        public IFormFile FormFile { get; set; } = null!;
    }
}
