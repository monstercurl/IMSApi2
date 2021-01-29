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
    public class ProductController : ControllerBase
    {
         IProductService _prd;
        public ProductController(IProductService prd) {
            _prd = prd;
        }
        [AllowAnonymous]
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(string PrdName, string prdColor)
        {

            return Ok(_prd.AddProduct(PrdName, prdColor));
                
             }
    

    }
    
}

