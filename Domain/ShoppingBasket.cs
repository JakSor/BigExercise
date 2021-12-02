using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingBasket : IShopBaseItem
    {
        public int Id { get; set; }
        public IEnumerable<ShoppingBasketItem> Items { get; set; }

    }
}
