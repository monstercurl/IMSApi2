using IMSApi.DAL;
using IMSApi.EntityModel.DTO.ProductDTONs;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;



namespace IMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _prd;
        IMSApiDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService prd, IWebHostEnvironment webHostEnvironment,IMSApiDbContext con) {
            _prd = prd;
            _webHostEnvironment = webHostEnvironment;
            _context = con;
        }
        [AllowAnonymous]
        [HttpPost("AddProductWithImage")]
        public IActionResult AddProductWithImage([FromForm]ProdcutRequest prdReq, [FromForm] string productDesignList)
        {
            List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            return Ok(_prd.AddProduct(prdReq, _webHostEnvironment,prdList));
            

        }
        
        [AllowAnonymous]
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CategoryDTO prdReq)
        {
            return Ok(_prd.AddCategory(prdReq));

        }
        [AllowAnonymous]
        [HttpPost("AddSize")]
        public IActionResult AddColor(ProductSizeDTO prdReq)
        {
            return Ok(_prd.AddSize(prdReq));

        }
        [AllowAnonymous]
        [HttpPost("AddColor")]
        public IActionResult AddColor(ProductColorDTO prdReq)
        {
            return Ok(_prd.AddColor(prdReq));

        }
        [AllowAnonymous]
        [HttpGet("existingData")]
        public IActionResult ExistingCategoryAttributeData()
        {
            return Ok(_prd.ExistingData());

        }
        [AllowAnonymous]
        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_prd.GeAllProducts(Request));

        }

        [AllowAnonymous]
        [HttpGet("getAllDesignsForGivenProduct")]
        public IActionResult GetAllDesignsForGivenProduct(int Id)
        {
            return Ok(_prd.GetDesignsForGivenProduct(Id));

        }
        [AllowAnonymous]
        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(int Product_Id)
        {
            return Ok(_prd.DeleteProduct(Product_Id));

        }



    }
    
}

