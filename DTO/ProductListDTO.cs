using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductListDTO
    {
        //todo: list producten, stockfilter, countproduct
        public List<ProductDTO> ProductDTOs { get; set; } = new List<ProductDTO>();
        public int CountProducts { get; set; }
        public string Filter { get; set; }
    }
}
