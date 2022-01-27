using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class ProductDetail
    {
        [Key]
      
        public string? ProductName { get; set; }
        public string PhotoUrl { get; set; }


    }
}
