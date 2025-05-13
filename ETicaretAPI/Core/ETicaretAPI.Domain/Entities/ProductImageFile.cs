using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class ProductImageFile:BaseEntity
    {

        public string FileName { get; set; }
        public string Path { get; set; }

        // Foreign Key
        public Guid ProductId { get; set; }

        // Navigation Property
        public Product Product { get; set; }

    }
}
