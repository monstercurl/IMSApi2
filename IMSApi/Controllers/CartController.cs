using IMSApi.EntityModel.DTO.CartDTO;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CartController : ControllerBase
    {
        ICartService cartService;
      
        public CartController(ICartService cart)
        {
            cartService = cart;
        }

        [AllowAnonymous]
        [HttpPost("AddToCart")]
        public IActionResult AddToCart(CartDTO cartDto)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            string prr = cartService.AddToCart(cartDto.userId, cartDto.productId);


            return Ok(prr);


        }
        [AllowAnonymous]
        [HttpPost("GetAllCartItems")]
        public IActionResult GetAllCartItems(CartDTO cartDto)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            var prr = cartService.getAllCartItemsForThisUser(cartDto.userId);


            return Ok(prr);


        }
        [AllowAnonymous]
        [HttpPost("DeleteCartItem")]
        public IActionResult DeleteCartItem(CartItemDTO cartItemDto)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            var prr = cartService.DeleteFromCart(cartItemDto.cartItemId,cartItemDto.userId);
            return Ok(prr);


        }

    }
}
