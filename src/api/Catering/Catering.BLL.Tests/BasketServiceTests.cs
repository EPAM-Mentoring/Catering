using Catering.BLL.Interfaces;
using Catering.BLL.Services;
using Catering.DAL;
using Catering.DAL.Entities.Basket;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catering.BLL.Tests
{
    public class BasketServiceTests
    {
        private readonly Mock<IRepository<CustomerBasket>> _basketRepositoryMock;
        private readonly IBasketService _basketService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public BasketServiceTests()
        {
            _basketRepositoryMock = new Mock<IRepository<CustomerBasket>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _basketService = new BasketService(_unitOfWorkMock.Object, _basketRepositoryMock.Object);
        }

        [Fact]
        public async void GetById_ShouldReturnBook_WhenCustomerBasketExist()
        {
            var customerBasket = CreateCustomerBasket();

            _basketRepositoryMock.Setup(c => c.GetAsync(customerBasket.Id))
                .ReturnsAsync(customerBasket);

            var result = await _basketService.GetBasketAsync(customerBasket.Id);

            Assert.NotNull(result);
            Assert.IsType<CustomerBasket>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenBasketDoesNotExist()
        {
            _basketRepositoryMock.Setup(c => c.GetAsync(1))
                .ReturnsAsync((CustomerBasket)null);

            var result = await _basketService.GetBasketAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromRepository_OnlyOnce()
        {
            _basketRepositoryMock.Setup(c => c.GetAsync(1))
                .ReturnsAsync(new CustomerBasket());

            await _basketService.GetBasketAsync(1);

            _basketRepositoryMock.Verify(mock => mock.GetAsync(1), Times.Once);
        }

        [Fact]
        public void Update_ShouldUpdateBasket_DoesNotExist()
        {
            var basket = CreateCustomerBasket();

            _basketRepositoryMock.Setup(c => c.Update(basket));

            var result = _basketService.UpdateBasketAsync(basket);

            Assert.NotNull(result);
        }

        [Fact]
        public async void Update_ShouldCallAddFromRepository_OnlyOnce()
        {
            var basket = CreateCustomerBasket();

            _basketRepositoryMock.Setup(c => c.Update(basket));

            await _basketService.UpdateBasketAsync(basket);

            _basketRepositoryMock.Verify(mock => mock.Update(basket), Times.Once);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromRepository_OnlyOnce()
        {
            var basket = CreateCustomerBasket();

            await _basketService.DeleteBasketAsync(basket);

            _basketRepositoryMock.Verify(mock => mock.Delete(basket), Times.Once);
        }

        [Fact]
        public void Remove_ShouldRemoveBasket_WhenExists()
        {
            var basket = CreateCustomerBasket();

            _basketRepositoryMock.Setup(c => c.GetAsync(basket.Id)).ReturnsAsync(basket);

            var result = _basketService.DeleteBasketAsync(basket);

            Assert.NotNull(result);
        }


        private CustomerBasket CreateCustomerBasket()
        {
            return new CustomerBasket()
            {
                Id = 1,
                DeliveryMethodId = 1,
                ShippingPrice = 10
            };
        }

        private List<CustomerBasket> CreateCustomerBasketList()
        {
            return new List<CustomerBasket>()
            {
                new CustomerBasket()
                {
                    Id = 1,
                    DeliveryMethodId = 2,
                    ShippingPrice = 12
                },
                new CustomerBasket()
                {
                    Id = 2,
                    DeliveryMethodId = 1,
                    ShippingPrice = 13
                },
                new CustomerBasket()
                {
                    Id = 3,
                    DeliveryMethodId = 3,
                    ShippingPrice = 15
                }
            };
        }

    }
}
