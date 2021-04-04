using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.DTO.CartDTO
{
 public   class WishListDTO
    {
        public int userId { get; set; }
        public long productId { get; set; }
    }
   public class WishListItemDTO
    {
        public long cartItemId { get; set; }
        public int userId { get; set; }
    }
}
