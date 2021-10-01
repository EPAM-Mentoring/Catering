using AutoMapper;
using Catering.API.Controllers;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Basket;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catering.API.Tests
{
    public class BasketControllerTests
    {
        private readonly BasketController _basketController;
        private readonly Mock<IBasketService> _basketServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public BasketControllerTests()
        {
            _basketServiceMock = new Mock<IBasketService>();
            _mapperMock = new Mock<IMapper>();
            _basketController = new BasketController(_basketServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenCustomerBasketExist()
        {
            var customerBasket = CreateBasket();
            var dtoExpected = MapModelToCustomerBasketDto(customerBasket);

            _basketServiceMock.Setup(c => c.GetBasketAsync(customerBasket.Id)).ReturnsAsync(customerBasket);
            _mapperMock.Setup(m => m.Map<CustomerBasketDto>(It.IsAny<CustomerBasket>())).Returns(dtoExpected);

            var result = await _basketController.GetBasket(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenCustomerBasketDoesNotExist()
        {
            _basketServiceMock.Setup(c => c.GetBasketAsync(2)).ReturnsAsync((CustomerBasket)null);

            var result = await _basketController.GetBasket(2);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromService_OnlyOnce()
        {
            var customerBasket = CreateBasket();
            var dtoExpected = MapModelToCustomerBasketDto(customerBasket);

            _basketServiceMock.Setup(c => c.GetBasketAsync(2)).ReturnsAsync(customerBasket);
            _mapperMock.Setup(m => m.Map<CustomerBasketDto>(It.IsAny<CustomerBasket>())).Returns(dtoExpected);

            await _basketController.GetBasket(2);

            _basketServiceMock.Verify(mock => mock.GetBasketAsync(2), Times.Once);
        }

        [Fact]
        public async void Update_ShouldReturnOk_WhenCustomerBasketIsUpdatedCorrectly()
        {
            var basket = CreateBasket();
            var basketEditDto = new CustomerBasketDto() { Id = 2 };

            _mapperMock.Setup(m => m.Map<CustomerBasket>(It.IsAny<CustomerBasketDto>())).Returns(basket);
            _basketServiceMock.Setup(c => c.GetBasketAsync(basket.Id)).ReturnsAsync(basket);
            _basketServiceMock.Setup(c => c.UpdateBasketAsync(basket)).ReturnsAsync(basket);

            var result = await _basketController.UpdateBasket(basketEditDto);

            Assert.IsType<ActionResult<CustomerBasket>>(result);
        }

        [Fact]
        public async void Update_ShouldCallUpdateFromService_OnlyOnce()
        {
            var basket = CreateBasket();
            var basketDto = new CustomerBasketDto() { Id = basket.Id};

            _mapperMock.Setup(m => m.Map<CustomerBasket>(It.IsAny<CustomerBasketDto>())).Returns(basket);
            _basketServiceMock.Setup(c => c.GetBasketAsync(1)).ReturnsAsync(basket);
            _basketServiceMock.Setup(c => c.UpdateBasketAsync(basket)).ReturnsAsync(basket);

            await _basketController.UpdateBasket(basketDto);

            _basketServiceMock.Verify(mock => mock.UpdateBasketAsync(basket), Times.Once);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenBasketIsRemoved()
        {
            var basket = CreateBasket();
            _basketServiceMock.Setup(c => c.GetBasketAsync(basket.Id)).ReturnsAsync(basket);
            _basketServiceMock.Setup(c => c.DeleteBasketAsync(basket));

            var result = await _basketController.DeleteBasket(basket.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenBasketDoesNotExist()
        {
            var basket = CreateBasket();
            _basketServiceMock.Setup(c => c.GetBasketAsync(basket.Id)).ReturnsAsync((CustomerBasket)null);

            var result = await _basketController.DeleteBasket(basket.Id);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async void Remove_ShouldReturnBadRequest_WhenResultIsFalse()
        {
            var basket = CreateBasket();
            _basketServiceMock.Setup(c => c.GetBasketAsync(basket.Id)).ReturnsAsync(basket);
            _basketServiceMock.Setup(c => c.DeleteBasketAsync(basket));

            var result = await _basketController.DeleteBasket(basket.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromService_OnlyOnce()
        {
            var basket = CreateBasket();
            _basketServiceMock.Setup(c => c.GetBasketAsync(basket.Id)).ReturnsAsync(basket);
            _basketServiceMock.Setup(c => c.DeleteBasketAsync(basket));

            await _basketController.DeleteBasket(basket.Id);

            _basketServiceMock.Verify(mock => mock.DeleteBasketAsync(basket), Times.Once);
        }

        private CustomerBasket CreateBasket()
        {
            return new CustomerBasket()
            {
                Id = 2,
                ShippingPrice = 12
            };
        }

        private CustomerBasketDto MapModelToCustomerBasketDto(CustomerBasket basket)
        {
            var customerBasketDto = new CustomerBasketDto()
            {
                Id = basket.Id
            };
            return customerBasketDto;
        }

        private List<CustomerBasket> CreateCustomerBasketList()
        {
            return new List<CustomerBasket>()
            {
                new CustomerBasket()
                {
                   Id = 1,
                   ShippingPrice = 13
                },
                new CustomerBasket()
                {
                    Id = 2,
                    ShippingPrice = 14
                },
                new CustomerBasket()
                {
                    Id = 3,
                    ShippingPrice = 15
                }
            };
        }

        private List<CustomerBasketDto> MapModelToCustomerBasketListDto(List<CustomerBasket> baskets)
        {
            var listCsutomerBaskets = new List<CustomerBasketDto>();

            foreach (var item in baskets)
            {
                var customerBasket= new CustomerBasketDto()
                {
                    Id = item.Id
                };
                listCsutomerBaskets.Add(customerBasket);
            }
            return listCsutomerBaskets;
        }
    }
}
