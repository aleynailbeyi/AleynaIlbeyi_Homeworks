namespace DAL.Model
{
    public class Result
    {
        public int status { get; set; }
        public string? Message { get; set; }
        public List<Product>? productList { get; set; }
    }
}
