using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL.Entities.Order
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod,
            decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            OrderItems = orderItems;
            Subtotal = subtotal;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
        }

        public string BuyerEmail { get; set; }

        public Address ShipToAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}
