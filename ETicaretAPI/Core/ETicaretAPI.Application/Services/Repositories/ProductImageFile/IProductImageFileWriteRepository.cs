﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services.Repositories
{
    public interface IProductImageFileWriteRepository : IWriteRepository<ProductImageFile>
    {
    }
}
