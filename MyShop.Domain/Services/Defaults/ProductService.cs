using AutoMapper;
using MyShop.Data.Models;
using MyShop.Data.Repositories;
using MyShop.Domain.Models;
using MyShop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MyShop.Domain.Services.Defaults
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
             _mapper = mapper; ;
    }

        public async Task AddAsync(AddProductDTO productDTO)
        {            
            Product product = _mapper.Map<AddProductDTO,Product>(productDTO);

            if (productDTO.Photo!=null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await productDTO.Photo.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }

            await _repo.AddAsync(product);
        }

        public async Task<PagedProductsDTO> Find(ProductFilterDTO filter)
        {
            var productQuery = _repo.GetQuery();

            productQuery = productQuery
                .Skip((filter.PageNumber - 1) * filter.PageCapacity)
                .Take(filter.PageCapacity);

            var products = await productQuery.ToListAsync();

            PagedProductsDTO result = new PagedProductsDTO()
            {
                PageNumber = filter.PageNumber,
                Products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products)
            };

            return result;
        }

        public async Task UpdateAsync(int id, AddProductDTO productDTO)
        {

           Product product =  _mapper.Map<AddProductDTO,Product>(productDTO);

            if (productDTO.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await productDTO.Photo.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }

            await _repo.UpdateAsync(product);
        }
    }
}
