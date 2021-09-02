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
    [Route("api/meals")]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _service;
        private readonly IMapper _mapper;

        public MealsController(IMealService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealDto>>> GetMeals()
        {
            var meals = await _service.GetMeals();

            return Ok(_mapper.Map<IEnumerable<MealDto>>(meals));
        }

        [HttpGet("{mealId}", Name = "GetMeal")]
        public async Task<ActionResult<MealDto>> GetMeal(int mealId)
        {
            var meal = await _service.GetMeal(mealId);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MealDto>(meal));
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<ActionResult<MealDto>> CreateMeal(int restaurantId, MealCreateDto createDto)
        {
            var mealEntity = _mapper.Map<Meal>(createDto);
            await _service.AddMeal(restaurantId, mealEntity);
            
            var toReturn = _mapper.Map<MealDto>(mealEntity);
            return CreatedAtRoute("GetMeal", new { restaurantId, mealId = toReturn.Id}, toReturn);

        }

        [HttpPut("{mealId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateMeal(int mealId, MealCreateDto createDto)
        {
            var meal = await _service.GetMeal(mealId);
            
            _mapper.Map(createDto, meal);

            await _service.UpdateMeal(meal);

            return Ok();
        }

        [HttpDelete("{mealId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var meal = await _service.GetMeal(mealId);

            if (meal == null)
            {
                return NotFound();
            }

            await _service.DeleteMeal(meal);
            return NoContent();
        }
    }
}
