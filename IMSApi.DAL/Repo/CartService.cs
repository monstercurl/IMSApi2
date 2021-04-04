using IMSApi.EntityModel.Entities.CartAndWishList;
using IMSApi.EntityModel.Entities.Product;
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

                    List<Product> listOfProducts; 
                    
                 
                        _context.product.Include(acc => acc.Category).ToList();
                        _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.product_design_images).ThenInclude(acc => acc.ProductImage).ToList();
                        _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productColor).ToList();
                        _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productSize).ToList();

                        _context.product.Include(acc => acc.product_images).ToList();
                        _context.product.Include(acc => acc.StichingType).ToList();
                        _context.product.Include(acc => acc.Fabric).ToList();
                        _context.product.Include(acc => acc.Vendor).ToList();

                        listOfProducts = _context.product.ToList();


                    
                    CartItem cartItem = new CartItem() { product = listOfProducts.Where(e => e.Product_ID == productId).FirstOrDefault() };
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

        public string AddToWishList(int userId, long productId)
        {

            using (_context)
            {
                try
                {

                    List<Product> listOfProducts;


                    _context.product.Include(acc => acc.Category).ToList();
                    _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.product_design_images).ThenInclude(acc => acc.ProductImage).ToList();
                    _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productColor).ToList();
                    _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productSize).ToList();

                    _context.product.Include(acc => acc.product_images).ToList();
                    _context.product.Include(acc => acc.StichingType).ToList();
                    _context.product.Include(acc => acc.Fabric).ToList();
                    _context.product.Include(acc => acc.Vendor).ToList();

                    listOfProducts = _context.product.ToList();



                    WishListItem wishListItem = new WishListItem() { product = listOfProducts.Where(e => e.Product_ID == productId).FirstOrDefault() };
                    if (wishListItem == null)
                    {
                        return "No product exist please choose a right product";
                    }
                    WishList wishListOfUser = _context.wishList.Where(e => e.AccountId == userId).Include(e => e.WishListItems).FirstOrDefault();
                    if (wishListOfUser == null)
                    {
                        _context.wishList.Add(new WishList()
                        {
                            AccountId = userId,
                            account = _context.account.Where(e => e.Id == userId).FirstOrDefault(),
                             WishListItems= new List<WishListItem>() { wishListItem }
                        });

                    }
                    else
                    {

                        wishListOfUser.WishListItems.Add(wishListItem);
                    }

                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return "Unable to add due to exception as >>> " + e.Message;

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

        public string DeleteFromWishList(long WishListItemId, int UserId)
        {
            _context.wishListItems.Remove(_context.wishListItems.Where(e => e.Id == WishListItemId).FirstOrDefault());
            _context.SaveChanges();
            return "deleted successfully";
        }

        public ICollection<CartItem> getAllCartItemsForThisUser(int userId)
        {
            Cart cartOfUser = null;
            using (_context)
            {
                _context.product.Include(acc => acc.Category).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.product_design_images).ThenInclude(acc => acc.ProductImage).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productColor).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productSize).ToList();

                _context.product.Include(acc => acc.product_images).ToList();
                _context.product.Include(acc => acc.StichingType).ToList();
                _context.product.Include(acc => acc.Fabric).ToList();
                _context.product.Include(acc => acc.Vendor).ToList();
                cartOfUser = _context.cart.Where(e => e.AccountId == userId).Include(e => e.cartItems).ThenInclude(e => e.product).FirstOrDefault();

            }
            return cartOfUser.cartItems;

        }

        public ICollection<WishListItem> getAllWishListItemsForThisUser(int userId)
        {
            WishList WishListOfUser = null;
            using (_context)
            {
                _context.product.Include(acc => acc.Category).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.product_design_images).ThenInclude(acc => acc.ProductImage).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productColor).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productSize).ToList();

                _context.product.Include(acc => acc.product_images).ToList();
                _context.product.Include(acc => acc.StichingType).ToList();
                _context.product.Include(acc => acc.Fabric).ToList();
                _context.product.Include(acc => acc.Vendor).ToList();
                WishListOfUser = _context.wishList.Where(e => e.AccountId == userId).Include(e => e.WishListItems).ThenInclude(e => e.product).FirstOrDefault();

            }
            return WishListOfUser.WishListItems;
        }
    }
    

}