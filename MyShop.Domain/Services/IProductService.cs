using Microsoft.AspNetCore.Http;
using MyShop.Domain.Models;
using MyShop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
    public interface IProductService
    {
        Task AddAsync(AddProductDTO productDTO);
        Task UpdateAsync(int id, AddProductDTO productDTO);
        Task<PagedProductsDTO> Find(ProductFilterDTO filter);
    }
}
