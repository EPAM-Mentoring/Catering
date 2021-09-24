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
    public class MealServiceTests
    {
        private readonly Mock<IRepository<Meal>> _mealRepositoryMock;
        private readonly IMealService _mealService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public MealServiceTests()
        {
            _mealRepositoryMock = new Mock<IRepository<Meal>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mealService = new MealService(_unitOfWorkMock.Object, _mealRepositoryMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnAListOfMeal_WhenMealsExist()
        {
            var meals = CreateMealList();

            _mealRepositoryMock.Setup(c => c.GetListAsync()).ReturnsAsync(meals);

            var result = await _mealService.GetMeals();
            Assert.NotNull(result);
            Assert.IsType<List<Meal>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnNull_WhenMealsDoNotExist()
        {
            _mealRepositoryMock.Setup(c => c.GetListAsync())
                .ReturnsAsync((List<Meal>)null);

            var result = await _mealService.GetMeals();

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldReturnMeal_WhenMealExist()
        {
            var meal = CreateMeal();

            _mealRepositoryMock.Setup(c => c.GetAsync(meal.Id))
                .ReturnsAsync(meal);

            var result = await _mealService.GetMeal(meal.Id);

            Assert.NotNull(result);
            Assert.IsType<Meal>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenMealDoesNotExist()
        {
            _mealRepositoryMock.Setup(c => c.GetAsync(1))
                .ReturnsAsync((Meal)null);

            var result = await _mealService.GetMeal(1);

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromRepository_OnlyOnce()
        {
            _mealRepositoryMock.Setup(c =>
                c.GetAsync(1)).ReturnsAsync((Meal)null);

            await _mealService.GetMeal(1);

            _mealRepositoryMock.Verify(mock => mock.GetAsync(1), Times.Once);
        }

        [Fact]
        public void Add_ShouldAddMeal_WhenRestaurantIdDoesExist()
        {
            var restaurantId = 1;
            var meal = CreateMeal();
            _mealRepositoryMock.Setup(c => c.Add(meal));

            var result = _mealService.AddMeal(restaurantId, meal);

            Assert.NotNull(result);
        }

        [Fact]
        public void Update_ShouldUpdateFMeal_WhenDoesExist()
        {
            var meal= CreateMeal();

            _mealRepositoryMock.Setup(c => c.Update(meal));

            var result = _mealService.UpdateMeal(meal);

            Assert.NotNull(result);
        }

        [Fact]
        public void Remove_ShouldRemoveMeal_WhenMealExists()
        {
            var meal = CreateMeal();

            _mealRepositoryMock.Setup(c => c.GetAsync(meal.Id)).ReturnsAsync(meal);

            var result = _mealService.DeleteMeal(meal);

            Assert.NotNull(result);
        }

        private Meal CreateMeal()
        {
            return new Meal()
            {
                Id = 1,
                MealName = "Meal",
                Description = "OqtepaLavash",
                Price = 23,
                PictureUrl = "abstdr",
                RestaurantId = 1
            };
        }

        private List<Meal> CreateMealList()
        {
            return new List<Meal>()
            {
               new Meal()
               {
                   Id = 1,
                   MealName = "Meal 1",
                   Description = "OqtepaLavash 1",
                   Price = 23,
                   PictureUrl = "abstdr",
                   RestaurantId = 1
               },
               new Meal()
               {
                   Id = 2,
                   MealName = "Meal 2",
                   Description = "OqtepaLavash 2",
                   Price = 28,
                   PictureUrl = "abstdfhd",
                   RestaurantId = 1
               },
               new Meal()
               {
                   Id = 3,
                   MealName = "Meal 3",
                   Description = "OqtepaLavash 3",
                   Price = 30,
                   PictureUrl = "abstdrjshfh",
                   RestaurantId = 2
               }
            };
        }
    }
}
