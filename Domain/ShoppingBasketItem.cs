using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class ShoppingBasketItem : IShopBaseItem
    {
        public int Id { get; set; }
        public ShoppingBasket Basket { get; set; }
        public int Amount { get; set; }
        public Product Item { get; set; }
    }
}
