using IMSApi.DAL;
using IMSApi.DAL.Common;
using IMSApi.EntityModel.DTO.ProductDTONs;
using IMSApi.EntityModel.Entities.Product;
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
        [HttpPost("AddProductHeader")]
        public IActionResult AddProductHeader(ProdcutRequest prdReq)
        {
            //List<ProdcutDesignDTO> prdList = JsonConvert.DeserializeObject<List<ProdcutDesignDTO>>(productDesignList);
            ProductIDResponse prr = new ProductIDResponse() { ProductId = _prd.AddProductHeader(prdReq) ,message = "Product Added"};
            
            
            return Ok(prr);
            

        }
        [AllowAnonymous]
        [HttpPost("AddProductDesignWithImages")]
        public IActionResult AddProductDesigns([FromForm] ProdcutDesignDTO prdDesgn)
        {
            List<ProductSizeAndQuantityJson> qtlist = JsonConvert.DeserializeObject<List<ProductSizeAndQuantityJson>>(prdDesgn.ProductSizeAndQuantityJson);
            return Ok(_prd.AddProductDesign(prdDesgn, _webHostEnvironment, qtlist));


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
        public IActionResult GetAllProducts([FromQuery]ProductPagingParameters productPagingParameters)
        {
            var prodcutFromRepo = _prd.GeAllProducts(Request, productPagingParameters);
            var prodcutRes = prodcutFromRepo.Item1;
            var prodcuts = prodcutFromRepo.Item2;
            var metadata = new
            {
                prodcuts.TotalCount,
                prodcuts.PageSize,
                prodcuts.CurrentPage,
                prodcuts.TotalPages,
                prodcuts.HasNext,
                prodcuts.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(prodcutRes);

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
        [AllowAnonymous]
        [HttpPost("CalculateSellingCost")]
        public IActionResult CalculateSellingCost(CostCalculateRequest costCalculateRequest)
        {
            return Ok(_prd.CostWithTax(costCalculateRequest));

        }
        [AllowAnonymous]
        [HttpPost("ActivateProduct")]
        public IActionResult ActivateProduct(int Id)
        {
            return Ok(_prd.ActivateProduct(Id));

        }
        [AllowAnonymous]
        [HttpPost("DactivateProduct")]
        public IActionResult DactivateProduct(int Id)
        {
            return Ok(_prd.DeactivateProduct(Id));

        }



    }
    
}

