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
    [ApiController]
    [Route("api/foods")]
    public class FoodsController : ControllerBase
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
        public async Task<IActionResult> GetFood(int foodId)
        {
            var foodEntity = await _service.GetFood(foodId);
            return Ok(_mapper.Map<FoodDto>(foodEntity));
        }

        [HttpPost("create/{shopId}")]
        [Authorize("Admin")]
        public async Task<ActionResult<FoodDto>> CreateFood(int shopId, FoodCreateDto createDto)
        {
            var foodEntity =  _mapper.Map<Food>(createDto);
            await _service.AddFood(shopId, foodEntity);

            var toReturn = _mapper.Map<FoodDto>(foodEntity);
            return CreatedAtRoute("GetFood", new { shopId = shopId, foodId = toReturn.Id}, toReturn);
            //return CreatedAtRoute("GetFood", new { shopId = shopId }, toReturn);
        }
        

        [HttpPut("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateFood(int foodId, FoodUpdateDto createDto)
        {
            var food = await _service.GetFood(foodId);
            _mapper.Map(createDto, food);

           await _service.UpdateFood(food);
           return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteFood(int foodId)
        {
            var food = await _service.GetFood(foodId);
            if(food == null)
            {
                return NotFound();
            }

            await _service.DeleteFood(food);
            return NoContent();
        }
    }
             
}
