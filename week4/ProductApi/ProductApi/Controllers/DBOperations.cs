using DAL.Model;
using Entities;
using System.Linq;

namespace ProductApi.Controllers
{
    public class DBOperations
    {
        private ProductContext _context = new ProductContext();
        Logger logger = new Logger();
        public bool AddModel(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.createLog("HATA " + ex.Message);
                return false;
            }
        }

        public bool DeleteModel(int ProductID)
        {
            try
            {
                _context.Products.Remove(GetProduct(ProductID:ProductID));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.createLog("HATA " + ex.Message);
                return false;
            }
        }
        public bool UpdateModel(Product product)
        {
            try
            {
                Product? exist = _context.Products.Find(product.ProductID);
                _context.Entry(exist).CurrentValues.SetValues(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.createLog("HATA " + ex.Message);
                return false;
            }
        }
       
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products = _context.Products.OrderBy(p => p.ProductID).ToList<Product>();
            return products;
        }
        public List<ProductDetail> GetProductDetail()
        {           
            return _context.Products.Join(_context.Product_Photos, p => p.ProductID, pp => pp.ProductID,
                (product, product_photos) => new ProductDetail { ProductName = product.ProductName, PhotoUrl = product_photos.PhotoUrl }).ToList();
        }
        public Product GetProduct(int ProductID)
        {
            Product? product = new Product();

            product = _context.Products.FirstOrDefault(p => p.ProductID == ProductID);

            return product;
        }

    }
}
