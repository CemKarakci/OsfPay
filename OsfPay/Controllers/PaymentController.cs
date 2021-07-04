using Microsoft.AspNetCore.Mvc;
using OsfPay.Data;
using OsfPay.Data.Entities;
using OsfPay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OsfPay.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ShoppingCart _shoppingCart;



        public PaymentController(IPaymentRepository paymentRepository, ShoppingCart shoppingCart)
        {
            _paymentRepository = paymentRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var payment = new Payment
            {
                CardNumber = null,
                Name = "",
                LastName = "",
                ExpritaionDate = null,
                CVV = null
                
            };
            var paymentView = new PaymentViewModel
            {
                Payment = payment,
                ShoppingCart = _shoppingCart
                
            };

            return View(paymentView);
        }

        [HttpPost]
        public ActionResult Index(PaymentViewModel paymentView)
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            paymentView.Payment.PaidAmount = Convert.ToDouble(_shoppingCart.GetShoppingCartTotal());
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("http://localhost:41085/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("api/PaymentApi", paymentView);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }


               
                PaymentViewModel newPaymentView = new PaymentViewModel
                {
                    ShoppingCart = _shoppingCart,
                    Payment = new Payment
                    {
                        CardNumber = null,
                        Name = "",
                        LastName = "",
                        ExpritaionDate = null,
                        CVV = null

                    }
            };

                return View(newPaymentView);
            }
        }
    public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order !";
            return View();
        }

    }
}

