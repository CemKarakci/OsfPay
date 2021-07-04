using OsfPay.Data.Entities;
using OsfPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data
{
    public class OrderRepository:IOrderRepository
    {
        private readonly OsfPayContext _osfPayContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(OsfPayContext osfPayContext, ShoppingCart shoppingCart)
        {
            _osfPayContext = osfPayContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderItems = new List<OrderItem>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderItem = new OrderItem
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.Price
                   
                };
                

                order.OrderItems.Add(orderItem);
            }

         

            _osfPayContext.Orders.Add(order);

            _osfPayContext.SaveChanges();
        }
       
    }
  
}
