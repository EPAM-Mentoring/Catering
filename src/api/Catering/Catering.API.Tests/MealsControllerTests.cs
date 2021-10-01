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
    public class MealsControllerTests
    {
        private readonly MealsController _mealsController;
        private readonly Mock<IMealService> _mealServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public MealsControllerTests()
        {
            _mealServiceMock = new Mock<IMealService>();
            _mapperMock = new Mock<IMapper>();
            _mealsController = new MealsController(_mealServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenExistMeals()
        {
            var meals = CreateMealList();
            var dtoExpected = MapModelToMealListDto(meals);

            _mealServiceMock.Setup(c => c.GetMeals()).ReturnsAsync(meals);
            _mapperMock.Setup(m => m.Map<IEnumerable<MealDto>>(It.IsAny<IEnumerable<Meal>>())).Returns(dtoExpected);

            var result = await _mealsController.GetMeals();
            Assert.IsType<ActionResult<IEnumerable<MealDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenDoesNotExistAnyMeal()
        {
            var meals = new List<Meal>();
            var dtoExpected = MapModelToMealListDto(meals);

            _mealServiceMock.Setup(c => c.GetMeals()).ReturnsAsync(meals);
            _mapperMock.Setup(m => m.Map<IEnumerable<MealDto>>(It.IsAny<List<Meal>>())).Returns(dtoExpected);

            var result = await _mealsController.GetMeals();
            Assert.IsType<ActionResult<IEnumerable<MealDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldCallGetAllFromService_OnlyOnce()
        {
            var meals = CreateMealList();
            var dtoExpected = MapModelToMealListDto(meals);

            _mealServiceMock.Setup(c => c.GetMeals()).ReturnsAsync(meals);
            _mapperMock.Setup(m => m.Map<IEnumerable<MealDto>>(It.IsAny<List<Meal>>())).Returns(dtoExpected);

            await _mealsController.GetMeals();

            _mealServiceMock.Verify(mock => mock.GetMeals(), Times.Once);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenMealExist()
        {
            var meal = CreateMeal();
            var dtoExpected = MapModelToMealDto(meal);

            _mealServiceMock.Setup(c => c.GetMeal(2)).ReturnsAsync(meal);
            _mapperMock.Setup(m => m.Map<MealDto>(It.IsAny<Meal>())).Returns(dtoExpected);

            var result = await _mealsController.GetMeal(2);

            Assert.IsType<ActionResult<MealDto>>(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromService_OnlyOnce()
        {
            var meal = CreateMeal();
            var dtoExpected = MapModelToMealDto(meal);

            _mealServiceMock.Setup(c => c.GetMeal(2)).ReturnsAsync(meal);
            _mapperMock.Setup(m => m.Map<MealDto>(It.IsAny<Meal>())).Returns(dtoExpected);

            await _mealsController.GetMeal(2);

            _mealServiceMock.Verify(mock => mock.GetMeal(2), Times.Once);
        }

        [Fact]
        public async void Add_ShouldReturnOk_WhenMealIsAdded()
        {
            var meal = CreateMeal();
            var mealCreateDto = new MealCreateDto() { MealName = meal.MealName };
            var mealDto = MapModelToMealDto(meal);
            var restaurantId = 1;

            _mapperMock.Setup(m => m.Map<Meal>(It.IsAny<MealCreateDto>())).Returns(meal);
            _mealServiceMock.Setup(c => c.AddMeal(restaurantId, meal));
            _mapperMock.Setup(m => m.Map<MealDto>(It.IsAny<Meal>())).Returns(mealDto);

            var result = await _mealsController.CreateMeal(restaurantId, mealCreateDto);

            Assert.IsType<ActionResult<MealDto>>(result);
        }

        [Fact]
        public async void Update_ShouldReturnOk_WhenMealIsUpdatedCorrectly()
        {
            var meal = CreateMeal();
            var mealUpdateDto = new MealUpdateDto() { MealName = meal.MealName, Description = "Jdndjs", PictureUrl = "dndn", Price = 23 };

            _mapperMock.Setup(m => m.Map<Meal>(It.IsAny<MealUpdateDto>())).Returns(meal);
            _mealServiceMock.Setup(c => c.GetMeal(meal.Id)).ReturnsAsync(meal);
            _mealServiceMock.Setup(c => c.UpdateMeal(meal));

            var result = await _mealsController.UpdateMeal(meal.Id, mealUpdateDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnOk_WhenMealIsRemoved()
        {
            var meal = CreateMeal();
            _mealServiceMock.Setup(c => c.GetMeal(meal.Id)).ReturnsAsync(meal);
            _mealServiceMock.Setup(c => c.DeleteMeal(meal));

            var result = await _mealsController.DeleteMeal(meal.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenMealDoesNotExist()
        {
            var meal = CreateMeal();
            _mealServiceMock.Setup(c => c.GetMeal(meal.Id)).ReturnsAsync((Meal)null);

            var result = await _mealsController.DeleteMeal(meal.Id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromService_OnlyOnce()
        {
            var meal = CreateMeal();
            _mealServiceMock.Setup(c => c.GetMeal(meal.Id)).ReturnsAsync(meal);
            _mealServiceMock.Setup(c => c.DeleteMeal(meal));

            await _mealsController.DeleteMeal(meal.Id);

            _mealServiceMock.Verify(mock => mock.DeleteMeal(meal), Times.Once);
        }

        private Meal CreateMeal()
        {
            return new Meal()
            {
                Id = 2,
                MealName = "Lavash",
                Description = "OqtepaLavash",
                Price = 23,
                PictureUrl = "abstdr",
                RestaurantId = 1,
                Restaurant = new Restaurant()
                {
                    Id = 1,
                    Name = "Oqtepa Lavsh",
                    PictureUrl = "abstd"
                }
            };
        }

        private MealDto MapModelToMealDto(Meal meal)
        {
            var mealDto = new MealDto()
            {
                Id = meal.Id,
                MealName = meal.MealName,
                Description = meal.Description,
                Price = meal.Price,
                PictureUrl = meal.PictureUrl,
                RestaurantId = meal.RestaurantId
            };
            return mealDto;
        }

        private List<Meal> CreateMealList()
        {
            return new List<Meal>()
            {
               new Meal()
               {
                   Id = 1,
                   MealName = "Lavash",
                   Description = "OqtepaLavash",
                   Price = 23,
                   PictureUrl = "abstdr",
                   RestaurantId = 1
               },
               new Meal()
               {
                   Id = 2,
                   MealName = "Lavash 1",
                   Description = "OqtepaLavash",
                   Price = 23,
                   PictureUrl = "abstdr",
                   RestaurantId = 1
               },
               new Meal()
               {
                   Id = 1,
                   MealName = "Lavash 3",
                   Description = "OqtepaLavash",
                   Price = 25,
                   PictureUrl = "abstdr",
                   RestaurantId = 1
               }
            };
        }

        private List<MealDto> MapModelToMealListDto(List<Meal> meals)
        {
            var listMeals = new List<MealDto>();

            foreach (var item in meals)
            {
                var meal = new MealDto()
                {
                    Id = item.Id,
                    MealName = item.MealName,
                    Description = item.Description,
                    Price = item.Price,
                    PictureUrl = item.PictureUrl,
                    RestaurantId = item.RestaurantId
                };
                listMeals.Add(meal);
            }
            return listMeals;
        }
    }
}
