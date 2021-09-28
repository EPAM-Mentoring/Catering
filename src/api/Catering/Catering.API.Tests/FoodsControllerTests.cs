using AutoMapper;
using Catering.API.Controllers;
using Catering.API.Dtos;
using Catering.BLL.Interfaces;
using Catering.DAL.Entities.FoodShops;
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
    public class FoodsControllerTests
    {
        private readonly FoodsController _foodsController;
        private readonly Mock<IFoodService> _foodServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public FoodsControllerTests()
        {
            _foodServiceMock = new Mock<IFoodService>();
            _mapperMock = new Mock<IMapper>();
            _foodsController = new FoodsController(_foodServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenExistFoods()
        {
            var foods = CreateFoodList();
            var dtoExpected = MapModelToFoodListDto(foods);

            _foodServiceMock.Setup(c => c.GetFoods()).ReturnsAsync(foods);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodDto>>(It.IsAny<List<Food>>())).Returns(dtoExpected);

            var result = await _foodsController.GetFoods();
            Assert.IsType<ActionResult<IEnumerable<FoodDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenDoesNotExistAnyFood()
        {
            var foods = new List<Food>();
            var dtoExpected = MapModelToFoodListDto(foods);

            _foodServiceMock.Setup(c => c.GetFoods()).ReturnsAsync(foods);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodDto>>(It.IsAny<List<Food>>())).Returns(dtoExpected);

            var result = await _foodsController.GetFoods();
            Assert.IsType<ActionResult<IEnumerable<FoodDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldCallGetAllFromService_OnlyOnce()
        {
            var foods = CreateFoodList();
            var dtoExpected = MapModelToFoodListDto(foods);

            _foodServiceMock.Setup(c => c.GetFoods()).ReturnsAsync(foods);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodDto>>(It.IsAny<List<Food>>())).Returns(dtoExpected);

            await _foodsController.GetFoods();

            _foodServiceMock.Verify(mock => mock.GetFoods(), Times.Once);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenFoodExist()
        {
            var food = CreateFood();
            var dtoExpected = MapModelToFoodDto(food);

            _foodServiceMock.Setup(c => c.GetFood(2)).ReturnsAsync(food);
            _mapperMock.Setup(m => m.Map<FoodDto>(It.IsAny<Food>())).Returns(dtoExpected);

            var result = await _foodsController.GetFood(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenFoodDoesNotExist()
        {
            _foodServiceMock.Setup(c => c.GetFood(2)).ReturnsAsync((Food)null);

            var result = await _foodsController.GetFood(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromService_OnlyOnce()
        {
            var food = CreateFood();
            var dtoExpected = MapModelToFoodDto(food);

            _foodServiceMock.Setup(c => c.GetFood(2)).ReturnsAsync(food);
            _mapperMock.Setup(m => m.Map<FoodDto>(It.IsAny<Food>())).Returns(dtoExpected);

            await _foodsController.GetFood(2);

            _foodServiceMock.Verify(mock => mock.GetFood(2), Times.Once);
        }

        [Fact]
        public async void Add_ShouldReturnOk_WhenFoodIsAdded()
        {
            var food = CreateFood();
            var foodCreateDto = new FoodCreateDto() { FoodName = food.FoodName };
            var foodDto = MapModelToFoodDto(food);
            var shopId = 1;

            _mapperMock.Setup(m => m.Map<Food>(It.IsAny<FoodCreateDto>())).Returns(food);
            _foodServiceMock.Setup(c => c.AddFood(shopId, food));
            _mapperMock.Setup(m => m.Map<FoodDto>(It.IsAny<Food>())).Returns(foodDto);

            var result = await _foodsController.CreateFood(shopId, foodCreateDto);

            Assert.IsType<ActionResult<FoodDto>>(result);
        }

        [Fact]
        public async void Update_ShouldReturnOk_WhenFoodIsUpdatedCorrectly()
        {
            var food = CreateFood();
            var foodUpdateDto = new FoodUpdateDto() { FoodName = food.FoodName, Description = "Jdndjs", PictureUrl = "dndn", Price = 23 };

            _mapperMock.Setup(m => m.Map<Food>(It.IsAny<FoodUpdateDto>())).Returns(food);
            _foodServiceMock.Setup(c => c.GetFood(food.Id)).ReturnsAsync(food);
            _foodServiceMock.Setup(c => c.UpdateFood(food));

            var result = await _foodsController.UpdateFood(food.Id, foodUpdateDto);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnOk_WhenFoodIsRemoved()
        {
            var food = CreateFood();
            _foodServiceMock.Setup(c => c.GetFood(food.Id)).ReturnsAsync(food);
            _foodServiceMock.Setup(c => c.DeleteFood(food));

            var result = await _foodsController.DeleteFood(food.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenFoodDoesNotExist()
        {
            var food = CreateFood();
            _foodServiceMock.Setup(c => c.GetFood(food.Id)).ReturnsAsync((Food)null);
            var result = await _foodsController.DeleteFood(food.Id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromService_OnlyOnce()
        {
            var food = CreateFood();
            _foodServiceMock.Setup(c => c.GetFood(food.Id)).ReturnsAsync(food);
            _foodServiceMock.Setup(c => c.DeleteFood(food));

            await _foodsController.DeleteFood(food.Id);

            _foodServiceMock.Verify(mock => mock.DeleteFood(food), Times.Once);
        }

        private Food CreateFood()
        {
            return new Food()
            {
                Id = 2,
                FoodName = "Lavash",
                Description = "OqtepaLavash",
                Price = 23,
                PictureUrl = "abstdr",
                FoodShopId = 1,
                FoodShop = new FoodShop()
                {
                    Id = 1,
                    Name = "Oqtepa Lavsh",
                    PictureUrl = "abstd"
                }
            };
        }

        private FoodDto MapModelToFoodDto(Food food)
        {
            var foodDto = new FoodDto()
            {
                Id = food.Id,
                FoodName = food.FoodName,
                Description = food.Description,
                Price = food.Price,
                PictureUrl = food.PictureUrl,
                FoodShopId = food.FoodShopId
            };
            return foodDto;
        }

        private List<Food> CreateFoodList()
        {
            return new List<Food>()
            {
               new Food()
               {
                   Id = 1,
                   FoodName = "Lavash",
                   Description = "OqtepaLavash",
                   Price = 23,
                   PictureUrl = "abstdr",
                   FoodShopId = 1
               },
               new Food()
               {
                   Id = 1,
                   FoodName = "Lavash",
                   Description = "OqtepaLavash 1",
                   Price = 28,
                   PictureUrl = "abstdr 1",
                   FoodShopId = 2
               },
               new Food()
               {
                   Id = 1,
                   FoodName = "Lavash",
                   Description = "OqtepaLavash 3",
                   Price = 30,
                   PictureUrl = "abstdr",
                   FoodShopId = 1
               }
            };
        }

        private List<FoodDto> MapModelToFoodListDto(List<Food> foods)
        {
            var listFoods = new List<FoodDto>();

            foreach(var item in foods)
            {
                var food = new FoodDto()
                {
                    Id = item.Id,
                    FoodName = item.FoodName,
                    Description = item.Description,
                    Price = item.Price,
                    PictureUrl = item.PictureUrl,
                    FoodShopId = item.FoodShopId
                };
                listFoods.Add(food);
            }
            return listFoods;
        }
    }
}
