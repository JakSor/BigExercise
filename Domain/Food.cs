using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Food: Product
    {
        public DateTime ExpireDate { get; set; }
        public int QuantityInPackage { get; set; }
        public bool IsDrink { get; set; }
        public bool IsFood { get; set; } = true;

    }
}
