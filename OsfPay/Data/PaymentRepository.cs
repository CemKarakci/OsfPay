using OsfPay.Data.Entities;
using OsfPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OsfPayContext _osfPayContext;
        private readonly ShoppingCart _shoppingCart;

        public PaymentRepository(OsfPayContext osfPayContext,
            ShoppingCart shoppingCart,
            IOrderRepository orderRepository)
        {
            _osfPayContext = osfPayContext;
            _shoppingCart = shoppingCart;
        }

        public void Pay(Payment payment)
        {
            
            _osfPayContext.Payments.Add(payment);
            _osfPayContext.SaveChanges();
        }
        

    }
}

