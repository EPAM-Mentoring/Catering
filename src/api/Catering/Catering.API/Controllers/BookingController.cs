using AutoMapper;
using Catering.API.Dtos;
using Catering.BLL.Contracts.Booking;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetBooking")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var bookingEntity = await _service.GetAsync(id);

            return Ok(_mapper.Map<Booking>(bookingEntity));
        }

        [Authorize]
        [HttpPost("")]
        public IActionResult CreateBooking([FromBody] BookingDto bookingDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingDto);

            _service.CreateBooking(bookingEntity);

            var toReturn = _mapper.Map<BookingRequestDto>(bookingEntity);

            return CreatedAtRoute("GetBooking", new { bookingId = toReturn.BookingId }, toReturn);
        }
    }
}
