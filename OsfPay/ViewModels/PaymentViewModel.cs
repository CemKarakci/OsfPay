using OsfPay.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.ViewModels
{
    public class PaymentViewModel
    {
        public Payment Payment { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
