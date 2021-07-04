using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
