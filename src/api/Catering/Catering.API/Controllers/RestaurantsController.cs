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
    public class RestaurantsController : BaseApiController
    { 
        private readonly IRestaurantService _service;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurants()
        {
            var restaurantsFromRepo = await _service.GetRestaurants();

            return Ok(_mapper.Map<IEnumerable<RestaurantDto>>(restaurantsFromRepo));
        }

        [HttpGet("{id}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restFromRepo = await  _service.GetRestaurant(id);

            if(restFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RestaurantDto>(restFromRepo));
        }

        [HttpPost("create")]
        public async Task<ActionResult<RestaurantDto>> CreateRestaurant(RestaurantCreateDto createDto)
        {
            var restEntity = _mapper.Map<Restaurant>(createDto);
            await _service.AddRestaurant(restEntity);

            var toReturn = _mapper.Map<RestaurantDto>(restEntity);

            return CreatedAtRoute("GetRestaurant", new { id = toReturn.Id }, toReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantUpdateDto updateDto)
        {
            var restaurant = await _service.GetRestaurant(id);
            _mapper.Map(updateDto, restaurant);

            await _service.UpdateRestaurant(restaurant);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restFromRepo = await _service.GetRestaurant(id);

            if(restFromRepo == null)
            {
                return NotFound();
            }

            await _service.DeleteRestaurant(restFromRepo);
            return NoContent();
        }
    }

}
