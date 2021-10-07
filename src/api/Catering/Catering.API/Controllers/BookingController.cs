using AutoMapper;
using Catering.API.Dtos;
using Catering.API.Dtos.Booking;
using Catering.API.Errors;
using Catering.API.Extensions;
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
    public class BookingController : BaseApiController
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(BookingDto bookingDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var booking = await _service.CreateBooking(email, bookingDto.RestaurantId);

            if(booking == null)  return BadRequest(new ApiResponse(400, "Problem creating Booking"));

            return booking;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookingDto>>> GetBookingsForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var bookings = await _service.GetBookingsForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Booking>, IReadOnlyList<BookingToReturnDto>>(bookings));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingToReturnDto>> GetBookingForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var booking = await _service.GetBookingByIdAsync(id, email);

            if (booking == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Booking, BookingToReturnDto>(booking);
        }
    }
}
