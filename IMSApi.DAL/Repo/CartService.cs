using IMSApi.EntityModel.Entities.CartAndWishList;
using IMSApi.EntityModel.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.DAL.Repo
{
   
    
    public class CartService : ICartService

    {
        private readonly IMSApiDbContext _context;
        public CartService(IMSApiDbContext context)
        {
        
            _context = context;
    
        }
        public string AddToCart(int userId, long productId)
        {


            using (_context)
            {
                try
                {
                    CartItem cartItem = new CartItem() { product = _context.product.Where(e => e.Product_ID == productId).FirstOrDefault() };
                    if (cartItem == null) {
                        return "No product exist please choose a right product";
                    }
                    Cart cartOfUser = _context.cart.Where(e => e.AccountId == userId).Include(e => e.cartItems).FirstOrDefault();
                    if (cartOfUser == null)
                    {
                        _context.cart.Add(new Cart()
                        {
                            AccountId = userId,
                            account = _context.account.Where(e => e.Id == userId).FirstOrDefault(),
                            cartItems = new List<CartItem>() { cartItem }
                        });

                    }
                    else
                    {

                        cartOfUser.cartItems.Add(cartItem);
                    }

                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return "Unable to add due to exception as >>> "+e.Message;

                }
            }
            
            return "Saved Successfully";


        }
        

        public string DeleteFromCart(long CartItemId, int UserId)
        {
            _context.cartItems.Remove(  _context.cartItems.Where(e => e.Id == CartItemId).FirstOrDefault());
            _context.SaveChanges();
            return "deleted successfully";
        }

        public ICollection<CartItem> getAllCartItemsForThisUser(int userId)
        {
            Cart cartOfUser = _context.cart.Where(e => e.AccountId == userId).Include(e => e.cartItems).ThenInclude(e=>e.product).FirstOrDefault();
            return cartOfUser.cartItems;

        }
    }
    

}