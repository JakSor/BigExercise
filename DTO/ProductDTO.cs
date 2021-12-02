using System;

namespace DTO
{
    public class ProductDTO
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public int AmountInStock { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFood { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool IsDrink { get; set; }
        public DateTime ExpireDate { get; set; }
        public int QuantityInPackage { get; set; }
    }
}
