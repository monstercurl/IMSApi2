using System;
using System.ComponentModel.DataAnnotations;

namespace IMSApi.EntityModel
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public string Brand { get; set; }
      public  string Phone { get; set; }

    }
}
