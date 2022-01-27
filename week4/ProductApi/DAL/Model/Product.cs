using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
     
    }
}
