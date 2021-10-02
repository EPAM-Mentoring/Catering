using AutoMapper;
using Catering.API.Controllers;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.Restaurnt;
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
    public class RestaurantsControllerTests
    {
        private readonly RestaurantsController _restaurantsController;
        private readonly Mock<IRestaurantService> _restaurantServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public RestaurantsControllerTests()
        {
            _restaurantServiceMock = new Mock<IRestaurantService>();
            _mapperMock = new Mock<IMapper>();
            _restaurantsController = new RestaurantsController(_restaurantServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenExistRestaurant()
        {
            var restaurants = CreateRestauarntList();
            var dtoExpected = MapModelToRestaurantListDto(restaurants);

            _restaurantServiceMock.Setup(c => c.GetRestaurants()).ReturnsAsync(restaurants);
            _mapperMock.Setup(m => m.Map<IEnumerable<RestaurantDto>>(
                It.IsAny<List<Restaurant>>())).Returns(dtoExpected);

            var result = await _restaurantsController.GetRestaurants();

            Assert.IsType<ActionResult<IEnumerable<RestaurantDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenDoesNotExistAnyRestaurant()
        {
            var restaurants = new List<Restaurant>();
            var dtoExpected = MapModelToRestaurantListDto(restaurants);

            _restaurantServiceMock.Setup(c => c.GetRestaurants()).ReturnsAsync(restaurants);
            _mapperMock.Setup(m => m.Map<IEnumerable<RestaurantDto>>(It.IsAny<List<Restaurant>>())).Returns(dtoExpected);

            var result = await _restaurantsController.GetRestaurants();

            Assert.IsType<ActionResult<IEnumerable<RestaurantDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldCallGetAllFromService_OnlyOnce()
        {
            var restaurants = CreateRestauarntList();
            var dtoExpected = MapModelToRestaurantListDto(restaurants);

            _restaurantServiceMock.Setup(c => c.GetRestaurants()).ReturnsAsync(restaurants);
            _mapperMock.Setup(m => m.Map<IEnumerable<RestaurantDto>>(It.IsAny<List<Restaurant>>())).Returns(dtoExpected);

            await _restaurantsController.GetRestaurants();

            _restaurantServiceMock.Verify(mock => mock.GetRestaurants(), Times.Once);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenRestaurantExist()
        {
            var restaurant = CreateRestaurant();
            var dtoExpected = MapModelToRestaurantDto(restaurant);

            _restaurantServiceMock.Setup(c => c.GetRestaurant(2)).ReturnsAsync(restaurant);
            _mapperMock.Setup(m => m.Map<RestaurantDto>(It.IsAny<Restaurant>())).Returns(dtoExpected);

            var result = await _restaurantsController.GetRestaurant(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenRestaurantDoesNotExist()
        {
            _restaurantServiceMock.Setup(c => c.GetRestaurant(2)).ReturnsAsync((Restaurant)null);

            var result = await _restaurantsController.GetRestaurant(2);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromService_OnlyOnce()
        {
            var restaurant = CreateRestaurant();
            var dtoExpected = MapModelToRestaurantDto(restaurant);

            _restaurantServiceMock.Setup(c => c.GetRestaurant(2)).ReturnsAsync(restaurant);
            _mapperMock.Setup(m => m.Map<RestaurantDto>(It.IsAny<Restaurant>())).Returns(dtoExpected);

            await _restaurantsController.GetRestaurant(2);

            _restaurantServiceMock.Verify(mock => mock.GetRestaurant(2), Times.Once);
        }

        [Fact]
        public async void Add_ShouldReturnOk_WhenRestaurantIsAdded()
        {
            var restaurant = CreateRestaurant();
            var restaurantCreateDto = new RestaurantCreateDto() { Name = "Restaurant 4", PictureUrl = "hfjsd" };
            var restaurantDto = MapModelToRestaurantDto(restaurant);

            _mapperMock.Setup(m => m.Map<Restaurant>(It.IsAny<RestaurantCreateDto>())).Returns(restaurant);
            _restaurantServiceMock.Setup(c => c.AddRestaurant(restaurant));
            _mapperMock.Setup(m => m.Map<RestaurantDto>(It.IsAny<Restaurant>())).Returns(restaurantDto);

            var result = await _restaurantsController.CreateRestaurant(restaurantCreateDto);

            Assert.IsType<ActionResult<RestaurantDto>>(result);
        }

        [Fact]
        public async void Update_ShouldReturnOk_WhenRestaurantIsUpdatedCorrectly()
        {
            var restaurant = CreateRestaurant();
            var restaurantUpdateDto = new RestaurantUpdateDto() { Name = restaurant.Name, PictureUrl ="Test 2" };

            _mapperMock.Setup(m => m.Map<Restaurant>(It.IsAny<RestaurantUpdateDto>())).Returns(restaurant);
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync(restaurant);
            _restaurantServiceMock.Setup(c => c.UpdateRestaurant(restaurant));

            var result = await _restaurantsController.UpdateRestaurant(restaurant.Id, restaurantUpdateDto);

            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async void Update_ShouldCallUpdateFromService_OnlyOnce()
        {
            var restaurant = CreateRestaurant();
            var restaurantUpdateDto = new RestaurantUpdateDto() { Name = restaurant.Name, PictureUrl = "Test 2" };

            _mapperMock.Setup(m => m.Map<Restaurant>(It.IsAny<RestaurantUpdateDto>())).Returns(restaurant);
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync(restaurant);
            _restaurantServiceMock.Setup(c => c.UpdateRestaurant(restaurant));

            await _restaurantsController.UpdateRestaurant(restaurant.Id, restaurantUpdateDto);

            _restaurantServiceMock.Verify(mock => mock.UpdateRestaurant(restaurant), Times.Once);
        }

        [Fact]
        public async void Remove_ShouldReturnOk_WhenRestaurantIsRemoved()
        {
            var restaurant = CreateRestaurant();
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync(restaurant);
            _restaurantServiceMock.Setup(c => c.DeleteRestaurant(restaurant));

            var result = await _restaurantsController.DeleteRestaurant(restaurant.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenRestaurantDoesNotExist()
        {
            var restaurant = CreateRestaurant();
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync((Restaurant)null);

            var result = await _restaurantsController.DeleteRestaurant(restaurant.Id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnBadRequest_WhenResultIsFalse()
        {
            var restaurant = CreateRestaurant();
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync(restaurant);
            _restaurantServiceMock.Setup(c => c.DeleteRestaurant(restaurant));

            var result = await _restaurantsController.DeleteRestaurant(restaurant.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromService_OnlyOnce()
        {
            var restaurant = CreateRestaurant();
            _restaurantServiceMock.Setup(c => c.GetRestaurant(restaurant.Id)).ReturnsAsync(restaurant);
            _restaurantServiceMock.Setup(c => c.DeleteRestaurant(restaurant));

            await _restaurantsController.DeleteRestaurant(restaurant.Id);

            _restaurantServiceMock.Verify(mock => mock.DeleteRestaurant(restaurant), Times.Once);
        }

        private Restaurant CreateRestaurant()
        {
            return new Restaurant()
            {
                Id = 2,
                Name = "Restaurant 2",
                PictureUrl = "avdjsk"
            };
        }

        private RestaurantDto MapModelToRestaurantDto(Restaurant restaurant)
        {
            var restaurantResDto = new RestaurantDto()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                PictureUrl = restaurant.PictureUrl
            };
            return restaurantResDto;
        }

        private List<Restaurant> CreateRestauarntList()
        {
            return new List<Restaurant>()
            {
                new Restaurant()
                {
                   Id = 1,
                   Name = "Restaurant 1",
                   PictureUrl = "bdbsb"
                },
                new Restaurant()
                {
                    Id = 2,
                    Name = "Restaurant 2",
                    PictureUrl = "shdbsna"
                },
                new Restaurant()
                {
                    Id = 3,
                    Name = "Restaurant 3",
                    PictureUrl = "ndnsjjs"
                }
            };
        }

        private List<RestaurantDto> MapModelToRestaurantListDto(List<Restaurant> restaurants)
        {
            var listRestaurants = new List<RestaurantDto>();

            foreach (var item in restaurants)
            {
                var restaurant = new RestaurantDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PictureUrl = "dsjdh"
                };
                listRestaurants.Add(restaurant);
            }
            return listRestaurants;
        }
    }
}
