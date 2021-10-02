using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Order
{
    public class OrderDto
    {
        public int BasketId { get; set; }

        public int DeliveryMethodId { get; set; }

        public AddressDto ShipToAddress { get; set; }
    }
}
