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
        private readonly IUserRepository _users;
        private readonly IShopCartItemRepository _items;
        private readonly IMapper _mapper;

        public ShopCartService(IUserRepository users, IShopCartItemRepository items, IMapper mapper)
        {
            _users = users;
            _items = items;
            _mapper = mapper;
        }

        public async Task<bool> AddToCartAsync(int productId,int shopCartId)
        {

            var item = await _items.FindOne(x=>x.ProductId == productId && x.ShopCartId == shopCartId);

            bool operationResult = false;

            if(item==null)
            {
                ShopCartItem newItem = new ShopCartItem()
               {
                    ShopCartId = shopCartId,
                    ProductId = productId,
                    Quantity = 1
               };
                operationResult =  await _items.AddAsync(newItem);
            }
            else
            {
                item.Quantity++;
                operationResult = await _items.UpdateAsync(item);
            }
            return operationResult;
        }

        public async Task<bool> DeleteCartItemsAsync(IEnumerable<ShopCartItem> shopCartItems)
        {
            bool result = await _items.DeleteRangeAsync(shopCartItems);

            return result;
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
