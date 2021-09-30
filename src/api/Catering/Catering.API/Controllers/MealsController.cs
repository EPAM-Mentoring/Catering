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
    public class MealsController : BaseApiController
    {
        private readonly IMealService _service;
        private readonly IMapper _mapper;

        public MealsController(IMealService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<MealDto>>> GetMeals()
        {
            var meals = await _service.GetMeals();

            return Ok(_mapper.Map<IEnumerable<MealDto>>(meals));
        }

        [HttpGet("{id}", Name = "GetMeal")]
        public async Task<ActionResult<MealDto>> GetMeal(int id)
        {
            var meal = await _service.GetMeal(id);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MealDto>(meal));
        }

        [HttpPost("create/{restaurantId}")]
        public async Task<ActionResult<MealDto>> CreateMeal(int restaurantId, MealCreateDto createDto)
        {
            var mealEntity = _mapper.Map<Meal>(createDto);
            await _service.AddMeal(restaurantId, mealEntity);
            
            var toReturn = _mapper.Map<MealDto>(mealEntity);
            return CreatedAtRoute("GetMeal", new { restaurantId, id = toReturn.Id}, toReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(int id, MealUpdateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var meal = await _service.GetMeal(id);
            
            _mapper.Map(createDto, meal);

            await _service.UpdateMeal(meal);

            return Ok(createDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _service.GetMeal(id);

            if (meal == null)
            {
                return NotFound();
            }

            await _service.DeleteMeal(meal);
            return NoContent();
        }
    }
}
