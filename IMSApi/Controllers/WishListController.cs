using IMSApi.EntityModel.DTO;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IMSApi.EntityModel.DTO.CartDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        ICartService cartService;

        public WishListController(ICartService cart)
        {
            cartService = cart;
        }


        [AllowAnonymous]
        [HttpPost("AddToWishList")]
        public IActionResult AddToWishList(WishListDTO wishlistDto)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            string prr = cartService.AddToWishList(wishlistDto.userId, wishlistDto.productId);


            return Ok(new MessaageCommonResponse() { message = prr });


        }
        [AllowAnonymous]
        [HttpPost("GetAllWishListItemsItems")]
        public IActionResult GetAllCartItems(CartDTOUser WishListDTO)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            var prr = cartService.getAllWishListItemsForThisUser(WishListDTO.userId);


            return Ok(prr);


        }
        [AllowAnonymous]
        [HttpPost("DeleteWishListItem")]
        public IActionResult DeleteCartItem(WishListItemDTO wishlistItemDTO)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            var prr = cartService.DeleteFromWishList(wishlistItemDTO.cartItemId, wishlistItemDTO.userId);
            return Ok(new MessaageCommonResponse() { message = prr });


        }


    }
}
