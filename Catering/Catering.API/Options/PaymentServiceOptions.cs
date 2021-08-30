using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Options
{
    public class PaymentServiceOptions
    {
        public const string Section = "PaymentClient";
        public string Url { get; set; }
        public string Action { get; set; }
    }
}
