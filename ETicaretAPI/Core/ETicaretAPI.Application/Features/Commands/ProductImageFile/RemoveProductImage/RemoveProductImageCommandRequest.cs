using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProduct
{
    public class RemoveProductImageCommandRequest:IRequest<RemoveProductImageCommandResponse>
    {
        public string ProductId { get; set; } // Məhsulun ID-si
        public string FileName { get; set; }   // Silinəcək faylın adı
    }
}
