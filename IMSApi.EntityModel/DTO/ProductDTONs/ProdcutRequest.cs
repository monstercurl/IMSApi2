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
        public string Name { get; set; }
        public string Description { get; set; }


        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public List<IFormFile> Image {get; set;}
        public int Cost_Price { get; set; }
         public int Selling_price { get; set; }
        public int VendorId { get; set; }
    }
    public class ProdcutDesignDTO
    {
        [Required]
        public int colorID { get; set; }

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



