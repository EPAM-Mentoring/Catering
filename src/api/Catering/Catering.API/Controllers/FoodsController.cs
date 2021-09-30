using AutoMapper;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.FoodShops;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    public class FoodsController : BaseApiController
    {
        private readonly IFoodService _service;
        private readonly IMapper _mapper;

        public FoodsController(IFoodService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foodsEntity = await _service.GetFoods();

            return Ok(_mapper.Map<IEnumerable<FoodDto>>(foodsEntity));
        }

        [HttpGet("{id}", Name ="GetFood")]
        public async Task<IActionResult> GetFood(int id)
        {
            var foodEntity = await _service.GetFood(id);
            return Ok(_mapper.Map<FoodDto>(foodEntity));
        }

        [HttpPost("create/{shopId}")]
        [Authorize("Admin")]
        public async Task<ActionResult<FoodDto>> CreateFood(int shopId, FoodCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var foodEntity =  _mapper.Map<Food>(createDto);
            await _service.AddFood(shopId, foodEntity);

            var toReturn = _mapper.Map<FoodDto>(foodEntity);
            return CreatedAtRoute("GetFood", new { shopId = shopId, id = toReturn.Id}, toReturn);
        }
        
        [HttpPut("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateFood(int id, FoodUpdateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var food = await _service.GetFood(id);

            if (food == null) return BadRequest();

            _mapper.Map(createDto, food);

           await _service.UpdateFood(food);
           return Ok(createDto);
        }

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteFood(int id)
        {
            var food = await _service.GetFood(id);
            if(food == null)
            {
                return NotFound();
            }

            await _service.DeleteFood(food);
            return NoContent();
        }
    }
             
}
