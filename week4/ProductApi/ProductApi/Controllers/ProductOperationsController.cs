using DAL.Model;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOperationsController : ControllerBase
    {
      
        Result _result = new Result();
        ProductContext productOperation = new ProductContext();
        DBOperations dbOperations = new DBOperations();

        // Get all products.
        [HttpGet]
        public List<Product> GetProducts()
        {
            return dbOperations.GetProducts();
            //productsList = productsList.OrderBy(x => x.ProductID).ToList();
            //return productsList;
        }

        
        [HttpGet("/Detail")]
        public List<ProductDetail> GetProductDetails()
        {
           return dbOperations.GetProductDetail();
        }


        // Get products by Id.
        [HttpGet("{ProductID}")]
        public Product GetProduct(int ProductID)
        {
            return dbOperations.GetProduct(ProductID:ProductID);
        }

        
        // Add new product.
        [HttpPost]
        public Result Post(Product product)
        {
            if (dbOperations.GetProduct(product.ProductID) == null)
            {
                      // Add new product.
                    if (dbOperations.AddModel(product))
                    {
                        _result.status = 1;
                        _result.Message = "Yeni ürün listeye eklendi.";
                        _result.productList = dbOperations.GetProducts();
                    }
                    else
                    {
                        _result.status = 0;
                        _result.Message = "Bu ürün eklenemedi.";
                        _result.productList = dbOperations.GetProducts();
                }

            }
            else
            {
                _result.status = 0;
                _result.Message = "Bu ürün zaten listede var.";

            }
            return _result;
        }
            

        // Update the product.
        [HttpPut("{ProductID}")]
        public Result Update(Product product)
        {
            // Find product by given Id.
            Product? _oldProduct = dbOperations.GetProduct(ProductID:product.ProductID);
            if (_oldProduct != null)
            {
                if (dbOperations.UpdateModel(product))
                {
                    _result.status = 1;
                    _result.Message = "Ürün bilgileri başarıyla güncellendi";

                }
            
            else
            {
                _result.status = 0;
                _result.Message = "Bu ürünü güncelleyemedik.";
            }
        }
            else
            {
                _result.status = 0;
                _result.Message = "Bu ürünü içeride bulamadık. ";
            }
            return _result;
        }
        
        // Delete the product.
        [HttpDelete("{ProductID}")]
        public Result Delete(int ProductID)
        {
            if (dbOperations.DeleteModel(ProductID))
            {
                _result.status = 1;
                _result.Message = "Ürün silindi";         
            }
            else
            {
                _result.status = 0;
                _result.Message = "Ürün zaten silinmişti";
               
            }
            return _result;
        }
    }
}
