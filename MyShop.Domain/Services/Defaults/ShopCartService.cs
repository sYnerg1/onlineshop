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

        public async Task<bool> AddToCartAsync(int productId,string userName)
        {
            var user = await _users.GetUserByUserName(userName);

            var cartId = user.ShopCartId;

            var item = await _items.FindOne(x=>x.ProductId == productId && x.ShopCartId == cartId);

            bool operationResult = false;

            if(item==null)
            {
                ShopCartItem newItem = new ShopCartItem()
               {
                    ShopCartId = cartId,
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

        public async Task<IEnumerable<ShopCartItemDTO>> GetAllItemsDTOForUserAsync(string userName)
        {
            var user = await _users.GetUserByUserName(userName);

            var cartId = user.ShopCartId;

            var cartItems = await _items.GetAll(cartId);

            var cartItemDTOs = _mapper.Map<IEnumerable<ShopCartItem>,IEnumerable<ShopCartItemDTO>>(cartItems);

            return cartItemDTOs;

        }

        public async Task<IEnumerable<ShopCartItem>> GetAllItemsForUserAsync(string userName)
        {
            var user = await _users.GetUserByUserName(userName);

            var cartId = user.ShopCartId;

            var cartItems = await _items.GetAll(cartId);

            return cartItems;

        }
    }
}
