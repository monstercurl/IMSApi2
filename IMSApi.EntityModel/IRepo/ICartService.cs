using IMSApi.EntityModel.Entities.CartAndWishList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.IRepo
{
    public interface ICartService
    {
        public string AddToCart(int userId, long productId);
        public string DeleteFromCart(long CartItemId, int UserId);
        public ICollection<CartItem> getAllCartItemsForThisUser(int userId);

        //below are for WishListItems
        public string AddToWishList(int userId, long productId);
        public string DeleteFromWishList(long CartItemId, int UserId);
        public ICollection<WishListItem> getAllWishListItemsForThisUser(int userId);




    }
}
