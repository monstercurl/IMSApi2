using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.CartAndWishList
{
    public class Cart
    {
        public long Id { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account account  {get;set;}

        public ICollection<CartItem> cartItems { get; set;}



    }
}
