using OsfPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data.Entities
{
    public class ProductRepository:IProductRepository
    {
        private readonly OsfPayContext _osfPayContext;

        public ProductRepository(OsfPayContext osfPayContext)
        {
            _osfPayContext = osfPayContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _osfPayContext.Products.ToList();
            }
        }

       
        public Product GetProductById(int productId)
        {
            return _osfPayContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
