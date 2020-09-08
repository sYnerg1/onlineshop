using MyShop.Data.Models;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MyShop.Domain.Models;
using AutoMapper;

namespace MyShop.Domain.Services.Defaults
{
    class ShopCartService : IShopCartService
    {
        private readonly IProductRepository _products;
        private readonly IShopCartItemRepository _items;
        private readonly IMapper _mapper;

        public ShopCartService(IProductRepository products, IShopCartItemRepository items, IMapper mapper)
        {
            _products = products;
            _items = items;
            _mapper = mapper;
        }

        public async Task<bool> AddToCartAsync(int productId,int shopCartId)
        {
            bool operationResult = false;

            var productToAdd = await _products.GetByIdAsync(productId);

            if(productToAdd.Amount > 0)
            {
                var item = await _items.FindOne(x => x.ProductId == productId && x.ShopCartId == shopCartId);

                if (item == null)
                {
                    ShopCartItem newItem = new ShopCartItem()
                    {
                        ShopCartId = shopCartId,
                        Product = productToAdd,
                        Quantity = 1
                    };
                    operationResult = await _items.AddAsync(newItem);
                }
                else
                {
                    item.Quantity++;
                    operationResult = await _items.UpdateAsync(item);
                }
                productToAdd.Amount--;

                await _products.UpdateAsync(productToAdd);
            }
         
            return operationResult;
        }

        public async Task DeleteCartItemAsync(int itemId)
        {
            var existItem = await _items.FindOne(x=>x.Id==itemId);
            if(existItem!=null)
            {
                var reletadProduct = await _products.GetByIdAsync(existItem.ProductId);

                await _items.DeleteAsync(existItem);

                reletadProduct.Amount += existItem.Quantity;

                await _products.UpdateAsync(reletadProduct);
            }
            else
            {
                throw new ArgumentNullException("Shop Cart doesn't consist this item");
            }            
        }

        public async Task<ShopCartDTO> GetShopCartForUserAsync(int shopCartId)
        {
            var cartItems = await _items.GetAll(shopCartId);

            var cartItemDTOs = _mapper.Map<IEnumerable<ShopCartItem>,IEnumerable<ShopCartItemDTO>>(cartItems);

            ShopCartDTO shopCartDTO= new ShopCartDTO()
            {
                ItemDTOs = cartItemDTOs,
                TotalCost = cartItemDTOs.Sum(x=>x.Quantity* x.Price)
            };

            return shopCartDTO;
        }
    }
}
