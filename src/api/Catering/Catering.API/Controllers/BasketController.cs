using AutoMapper;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _service;
        private readonly IMapper _mapper;

        public BasketController(IBasketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(int id)
        {
            var basketEntity = await _service.GetBasketAsync(id);
            if(basketEntity == null)
            {
                return NotFound();
            }

            return Ok(basketEntity);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody]CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            if(customerBasket == null)
            {
                return BadRequest();
            }

            var custBasket = await _service.UpdateBasketAsync(customerBasket);
            return Ok(custBasket);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(int id)
        {
            var basket = await _service.GetBasketAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            await _service.DeleteBasketAsync(basket);
            return NoContent();
        }
    }
}
