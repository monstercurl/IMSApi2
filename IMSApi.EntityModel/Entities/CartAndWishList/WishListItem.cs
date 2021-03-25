using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.CartAndWishList
{
   public class WishListItem
    {
        public long Id { get; set; }
        public Product.Product product { get; set; }
    }
}
