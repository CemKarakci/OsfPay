using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OsfPay.Data;
using OsfPay.Data.Entities;
using OsfPay.Models;
using OsfPay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentApiController : ControllerBase
    {
        private readonly IPaymentRepository _repository;
        private readonly ILogger<PaymentApiController> _logger;
        private readonly OsfPayContext _context;


        public PaymentApiController(IPaymentRepository repository,
            ILogger<PaymentApiController> logger,
            OsfPayContext context)
        {
            _repository = repository;
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        public List<Order> Get()
        {
            return _context.Orders.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]PaymentViewModel paymentView)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var payment = new Payment
                    {
                        CardNumber = paymentView.Payment.CardNumber,
                        Name = paymentView.Payment.Name,
                        LastName = paymentView.Payment.LastName,
                        ExpritaionDate = paymentView.Payment.ExpritaionDate,
                        CVV = paymentView.Payment.CVV,
                        PaidAmount = paymentView.Payment.PaidAmount
   
                    };

                    _repository.Pay(payment);

                    var orderStatus = new OrderStatus { Status = "Completed" };
                    _context.OrderStatuses.Add(orderStatus);
                    _context.SaveChanges();


                    return Ok();
                    
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new payment: {ex}");
            }

            return BadRequest("Failed to save new payment.");
        }
    }
}
