using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string PersonId { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
