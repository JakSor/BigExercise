using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NonFood : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public bool IsFood { get; set; } = false;
    }
}
