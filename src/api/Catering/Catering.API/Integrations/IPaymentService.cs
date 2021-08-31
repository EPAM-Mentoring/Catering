using Catering.BLL.Contracts.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Integrations
{
    public interface IPaymentService
    {
        public Task CreatePayment(PaymentRequest paymentRequest);
    }
}
