using Catering.BLL.Interfaces;
using Catering.BLL.Services;
using Catering.DAL;
using Catering.DAL.Entities.Restaurnt;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catering.BLL.Tests
{
    public class RestaurantServiceTests
    {
        private readonly Mock<IRepository<Restaurant>> _restaurantRepositoryMock;
        private readonly IRestaurantService _restaurantService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public RestaurantServiceTests()
        {
            _restaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _restaurantService = new RestaurantService(_unitOfWorkMock.Object, _restaurantRepositoryMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnAListOfMeal_WhenRestaurantsExist()
        {
            var restaurants = CreateRestaurantList();

            _restaurantRepositoryMock.Setup(c => c.GetListAsync()).ReturnsAsync(restaurants);

            var result = await _restaurantService.GetRestaurants();
            Assert.NotNull(result);
            Assert.IsType<List<Restaurant>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnNull_WhenRestaurantsDoNotExist()
        {
            _restaurantRepositoryMock.Setup(c => c.GetListAsync())
                .ReturnsAsync((List<Restaurant>)null);

            var result = await _restaurantService.GetRestaurants();

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldReturnRestaurant_WhenRestaurantExist()
        {
            var restaurant = CreateRestaurant();

            _restaurantRepositoryMock.Setup(c => c.GetAsync(restaurant.Id))
                .ReturnsAsync(restaurant);

            var result = await _restaurantService.GetRestaurant(restaurant.Id);

            Assert.NotNull(result);
            Assert.IsType<Restaurant>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenRestaurantDoesNotExist()
        {
            _restaurantRepositoryMock.Setup(c => c.GetAsync(1))
                .ReturnsAsync((Restaurant)null);

            var result = await _restaurantService.GetRestaurant(1);

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromRepository_OnlyOnce()
        {
            _restaurantRepositoryMock.Setup(c =>
                c.GetAsync(1)).ReturnsAsync((Restaurant)null);

            await _restaurantService.GetRestaurant(1);

            _restaurantRepositoryMock.Verify(mock => mock.GetAsync(1), Times.Once);
        }

        [Fact]
        public void Add_ShouldAddRestaurant_WhenRestaurantIdDoesExist()
        {
            var restaurant = CreateRestaurant();
            _restaurantRepositoryMock.Setup(c => c.Add(restaurant));

            var result = _restaurantService.AddRestaurant(restaurant);

            Assert.NotNull(result);
        }

        [Fact]
        public void Update_ShouldUpdateRestaurant_WhenDoesExist()
        {
            var restaurant = CreateRestaurant();

            _restaurantRepositoryMock.Setup(c => c.Update(restaurant));

            var result = _restaurantService.UpdateRestaurant(restaurant);

            Assert.NotNull(result);
        }

        [Fact]
        public void Remove_ShouldRemoveRestaurant_WhenRestaurantExists()
        {
            var restaurant = CreateRestaurant();

            _restaurantRepositoryMock.Setup(c => c.GetAsync(restaurant.Id)).ReturnsAsync(restaurant);

            var result = _restaurantService.DeleteRestaurant(restaurant);

            Assert.NotNull(result);
        }

        private Restaurant CreateRestaurant()
        {
            return new Restaurant()
            {
                Id = 1,
                Name = "Restaurant",
                PictureUrl = "avdjsk"
            };
        }

        private List<Restaurant> CreateRestaurantList()
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
    }
}
