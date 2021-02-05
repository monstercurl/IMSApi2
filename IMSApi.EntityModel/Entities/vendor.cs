﻿using System;
using System.ComponentModel.DataAnnotations;

namespace IMSApi.EntityModel.Entities
{
    public class Vendor
    {
        public int Id { get; set; } 
        public string Vendor_name { get; set; }
        public string Store_name { get; set; }
        public string Supplier_code { get; set; }
        public string Gstin { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string IsDeleted { get; set; }



    }
}
