using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.DTO.CartDTO
{
   public class CartDTO
    {
      public  int userId { get; set; }
       public long productId { get; set; }
    }
    public class CartItemDTO
    {
        public long cartItemId { get; set; }
        public int userId { get; set; }
    }
}
