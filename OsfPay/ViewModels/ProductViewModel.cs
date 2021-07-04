using OsfPay.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
