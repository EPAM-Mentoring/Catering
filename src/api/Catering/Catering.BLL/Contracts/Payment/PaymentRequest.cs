using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.BLL.Contracts.Payment
{
    public class PaymentRequest
    {
        public string PersonId { get; set; }

        public int OrderId { get; set; }

        public decimal Amount { get; set; }
    }
}
