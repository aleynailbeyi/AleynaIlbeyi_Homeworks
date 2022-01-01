using Microsoft.AspNetCore.Mvc;
using ProductApi.Model;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOperationsController : ControllerBase
    {
        private static List<Product> productsList = new List<Product>()
        {
            new Product
            {
                ProductID = 1,
                ProductName = "OliveOil",
                ProductCount = 1,
                ProductPrice = 42.90m
            },
            new Product
            {
                ProductID = 2,
                ProductName = "Flour",
                ProductCount = 5,
                ProductPrice = 37.90m
            },
            new Product
            {
                ProductID = 3,
                ProductName = "Sugar",
                ProductCount = 2,
                ProductPrice = 13.90m
            }
        };

        Result _result = new Result();

        // Get all products.
        [HttpGet]
        public List<Product> getProducts()
        {
            productsList = productsList.OrderBy(x => x.ProductID).ToList();
            return productsList;
        }

        // Get products by Id.
        [HttpGet("{id}")]
        public Product getProducts(int id)
        {
            Product resultObject = new Product();
            resultObject = productsList.FirstOrDefault(x => x.ProductID == id);

            return resultObject;
        }

        // Add new product.
        [HttpPost]

        public Result Post(Product product)
        {
            // Is there any product on the product list with given Id?
            Product prod = productsList.Where(p => p.ProductID == product.ProductID).FirstOrDefault();

            if (prod is null)
            {
                // Add new product.
                productsList.Add(product);
                _result.status = 1;
                _result.Message = "Yeni ürün listeye eklendi.";
                _result.productList = productsList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Bu ürün zaten listede var.";
                _result.productList = productsList;
            }

            return _result;
        }


        // Update the product.
        [HttpPut("{id}")]
        public Result Update(int id, Product newProduct)
        {
            // Find product by given Id.
            Product? _oldProduct = productsList.Find(y => y.ProductID == id);
            if (_oldProduct != null)
            {
                productsList.Add(newProduct);
                productsList.Remove(_oldProduct);

                _result.status = 1;
                _result.Message = "Ürün bilgileri başarıyla güncellendi";
                _result.productList = productsList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Bu ürünü içeride bulamadık.";
                _result.productList = productsList;

            }
            return _result;
        }
        // Delete the product.
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            // Find product by given Id.
            Product? _oldProduct = productsList.Find(y => y.ProductID == id);
            if (_oldProduct != null)
            {
                productsList.Remove(_oldProduct);
                _result.status = 1;
                _result.Message = "Ürün silindi";
                _result.productList = productsList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Ürün zaten silinmişti";
                _result.productList = productsList;
            }

            return _result;
        }
    }
}
