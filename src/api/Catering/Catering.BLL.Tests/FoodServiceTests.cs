using Catering.BLL.Interfaces;
using Catering.BLL.Services;
using Catering.DAL;
using Catering.DAL.Entities.FoodShops;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catering.BLL.Tests
{
    public class FoodServiceTests
    {
        private readonly Mock<IRepository<Food>> _foodRepositoryMock;
        private readonly IFoodService _foodService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public FoodServiceTests()
        {
            _foodRepositoryMock = new Mock<IRepository<Food>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _foodService = new FoodService(_unitOfWorkMock.Object, _foodRepositoryMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnAListOfFood_WhenFoodsExist()
        {
            var foods = CreateFoodList();

            _foodRepositoryMock.Setup(c => c.GetListAsync()).ReturnsAsync(foods);

            var result = await _foodService.GetFoods();
            Assert.NotNull(result);
            Assert.IsType<List<Food>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnNull_WhenFoodsDoNotExist()
        {
            _foodRepositoryMock.Setup(c => c.GetListAsync())
                .ReturnsAsync((List<Food>)null);

            var result = await _foodService.GetFoods();

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldReturnFood_WhenFoodExist()
        {
            var food = CreateFood();

            _foodRepositoryMock.Setup(c => c.GetAsync(food.Id))
                .ReturnsAsync(food);

            var result = await _foodService.GetFood(food.Id);

            Assert.NotNull(result);
            Assert.IsType<Food>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenFoodDoesNotExist()
        {
            _foodRepositoryMock.Setup(c => c.GetAsync(1))
                .ReturnsAsync((Food)null);

            var result = await _foodService.GetFood(1);

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromRepository_OnlyOnce()
        {
            _foodRepositoryMock.Setup(c =>
                c.GetAsync(1)).ReturnsAsync((Food)null);

            await _foodService.GetFood(1);

            _foodRepositoryMock.Verify(mock => mock.GetAsync(1), Times.Once);
        }

        [Fact]
        public void Add_ShouldAddFood_WhenShopIdDoesExist()
        {
            var shopId = 1;

            var food = CreateFood();
            _foodRepositoryMock.Setup(c => c.Add(food));

            var result = _foodService.AddFood(shopId, food);

            Assert.NotNull(result);
        }

        [Fact]
        public  void Update_ShouldUpdateFood_WhenDoesNotExist()
        {
            var food = CreateFood();

            _foodRepositoryMock.Setup(c => c.Update(food));

            var result = _foodService.UpdateFood(food);

            Assert.NotNull(result);
        }

        [Fact]
        public void Remove_ShouldRemoveFood_WhenFoodExists()
        {
            var food = CreateFood();

            _foodRepositoryMock.Setup(c => c.GetAsync(food.Id)).ReturnsAsync(food);

            var result =  _foodService.DeleteFood(food);

            Assert.NotNull(result);
        }

        private Food CreateFood()
        {
            return new Food()
            {
                Id = 1,
                FoodName = "Food",
                Description = "OqtepaLavash",
                Price = 23,
                PictureUrl = "abstdr",
                FoodShopId = 1
            };
        }

        private List<Food> CreateFoodList()
        {
            return new List<Food>()
            {
               new Food()
               {
                   Id = 1,
                   FoodName = "Food 1",
                   Description = "OqtepaLavash 1",
                   Price = 23,
                   PictureUrl = "abstdr",
                   FoodShopId = 1
               },
               new Food()
               {
                   Id = 2,
                   FoodName = "Food 2",
                   Description = "OqtepaLavash 2",
                   Price = 28,
                   PictureUrl = "abstdfhd",
                   FoodShopId = 1
               },
               new Food()
               {
                   Id = 3,
                   FoodName = "Food 3",
                   Description = "OqtepaLavash 3",
                   Price = 30,
                   PictureUrl = "abstdrjshfh",
                   FoodShopId = 2
               }
            };
        }

    };
}
