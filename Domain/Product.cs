using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class Product : IShopBaseItem
    {
     
        public double Price { get; set; }
        public string  Description { get; set; }
        public bool IsActive { get; set; }
        public int AmountInStock { get; set; }
     [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
}
