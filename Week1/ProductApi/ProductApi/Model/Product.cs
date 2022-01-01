namespace ProductApi.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
