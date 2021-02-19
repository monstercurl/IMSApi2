using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.DTO.ProductDTONs
{
    public class ProdcutRequest
    {
       
        public int Category_Id{ get; set; }
        public int StichingTypeId { get; set; }
        public int Fabric_Id { get; set; }

        public string Description { get; set; }

        
        
        public int VendorId { get; set; }
        public int CustomerShippingCost { get; set; }
        public int VendorShippingCost { get; set; }
        public int TraderMarginRupees { get; set; }
        public int TraderPrice { get; set; }
        public int CustomerMarginRupees { get; set; }
        public int CustomerPrice { get; set; }
        public int Cost_Price { get; set; }

    }
    public class ProdcutDesignDTO
    {
       public long ProductId { get; set; }
        [Required]
        public int colorID { get; set; }

        public string ProductSizeAndQuantityJson  { get; set; } 

        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public List<IFormFile> ImagesWithDesign{ get; set; }



    }
    public class ProductSizeAndQuantityJson
    {

        public int SizeID { get; set; }
        [Required]
        public int Qty { get; set; }
    }

        public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
  foreach(var v in (List<IFormFile>)value) 
            {          
                var file = v as IFormFile;
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }
    }
}



