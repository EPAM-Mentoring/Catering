using AutoMapper;
using Catering.API.Dtos.Order;
using Catering.API.Integrations;
using Catering.BLL.Contracts.Payment;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public OrdersController(IOrderService service, IMapper mapper, IPaymentService paymentService)
        {
            _service = service;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        [HttpGet("PaidStatus")]
        public async Task<IActionResult> PaidStatus([FromQuery] int orderId, [FromQuery] bool isPaid)
        {
            await _service.OrderIsPaid(orderId, isPaid);

            return Ok();
        }

        [HttpGet("{orderId}", Name = "GetOrder")]
        public  async Task<IActionResult> GetOrder(int orderId)
        {
            var orderFromRepo = await _service.GetOrder(orderId);

            if (orderFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OrderDto>(orderFromRepo));
        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _service.AddOrder(orderEntity);

            var payment = new PaymentRequest()
            {
                PersonId = orderEntity.PersonId,
                OrderId = orderEntity.Id,
                Amount = orderEntity.Total()
            };

             _paymentService.CreatePayment(payment);

            var toReturn = _mapper.Map<OrderDto>(orderEntity);

            return CreatedAtRoute("GetOrder", new { orderId = toReturn.Id }, toReturn);
        }
    }
}
