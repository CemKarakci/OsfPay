
using OsfPay.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data
{
    public interface IPaymentRepository
    {
        void Pay(Payment payment);

    }
}
