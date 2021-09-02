using AutoMapper;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Restaurnt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _service;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurants()
        {
            var restaurantsFromRepo = await _service.GetRestaurants();

            return Ok(_mapper.Map<RestaurantDto>(restaurantsFromRepo));
        }

        [HttpGet("{restaurantId}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurant(int restaurantId)
        {
            var restFromRepo = await  _service.GetRestaurant(restaurantId);

            if(restFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RestaurantDto>(restFromRepo));
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<ActionResult<RestaurantDto>> CreateRestaurant(RestaurantCreateDto createDto)
        {
            var restEntity = _mapper.Map<Restaurant>(createDto);
            await _service.AddRestaurant(restEntity);

            var toReturn = _mapper.Map<RestaurantDto>(restEntity);

            return CreatedAtRoute("GetRestaurant", new { restaurantId = toReturn.Id }, toReturn);
        }

        [HttpDelete("{restaurantId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var restFromRepo = await _service.GetRestaurant(restaurantId);

            if(restFromRepo == null)
            {
                return NotFound();
            }

            await _service.DeleteRestaurant(restFromRepo);
            return NoContent();
        }
    }

}
