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
    [Route("api/foodShops")]
    public class FoodShopsController : ControllerBase
    {
        private readonly IFoodShopService _service;
        private readonly IMapper _mapper;

        public FoodShopsController(IFoodShopService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodShopDto>>> GetFoodShops()
        {
            var shopsFromRepo = await _service.GetFoodShops();

            return Ok(_mapper.Map<IEnumerable<FoodShopDto>>(shopsFromRepo));
        }

        [HttpGet("{shopId}", Name = "GetFoodShop")]
        public async Task<IActionResult> GetFoodShop(int shopId)
        {
            var shopFromRepo = await _service.GetFoodShop(shopId);

            if(shopFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FoodShopDto>(shopFromRepo));
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<ActionResult<FoodShopDto>> CreateFoodShop(FoodShopCreateDto createDto)
        {
            var shopEntity = _mapper.Map<FoodShop>(createDto);
            await _service.AddFoodShop(shopEntity);
            
            var toReturn = _mapper.Map<FoodShopDto>(shopEntity);
            return CreatedAtRoute("GetFoodShop", new { shopId = toReturn.Id }, toReturn);
        }

        [HttpDelete("{shopId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteFoodShop(int shopId)
        {
            var shopFromRepo = await _service.GetFoodShop(shopId);
           
            if(shopFromRepo == null)
            {
                return NotFound();
            }

            await _service.DeleteFoodShop(shopFromRepo);

            return NoContent();
        }

    }
}
