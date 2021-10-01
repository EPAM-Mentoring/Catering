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
    public class FoodShopsControllerTests
    {
        private readonly FoodShopsController _foodShopsController;
        private readonly Mock<IFoodShopService> _foodShopServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public FoodShopsControllerTests()
        {
            _foodShopServiceMock = new Mock<IFoodShopService>();
            _mapperMock = new Mock<IMapper>();
            _foodShopsController = new FoodShopsController(_foodShopServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenExistFoodShop()
        {
            var foodShops = CreateFoodShopList();
            var dtoExpected = MapModelToFoodShoptListDto(foodShops);

            _foodShopServiceMock.Setup(c => c.GetFoodShops()).ReturnsAsync(foodShops);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodShopDto>>(
                It.IsAny<List<FoodShop>>())).Returns(dtoExpected);

            var result = await _foodShopsController.GetFoodShops();
            Assert.IsType<ActionResult<IEnumerable<FoodShopDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenDoesNotExistAnyFoodShop()
        {
            var foodShops = new List<FoodShop>();
            var dtoExpected = MapModelToFoodShoptListDto(foodShops);

            _foodShopServiceMock.Setup(c => c.GetFoodShops()).ReturnsAsync(foodShops);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodShopDto>>(It.IsAny<List<FoodShop>>())).Returns(dtoExpected);

            var result = await _foodShopsController.GetFoodShops();

            Assert.IsType<ActionResult<IEnumerable<FoodShopDto>>>(result);
        }

        [Fact]
        public async void GetAll_ShouldCallGetAllFromService_OnlyOnce()
        {
            var foodShops = CreateFoodShopList();
            var dtoExpected = MapModelToFoodShoptListDto(foodShops);

            _foodShopServiceMock.Setup(c => c.GetFoodShops()).ReturnsAsync(foodShops);
            _mapperMock.Setup(m => m.Map<IEnumerable<FoodShopDto>>(It.IsAny<List<FoodShop>>())).Returns(dtoExpected);

            await _foodShopsController.GetFoodShops();

            _foodShopServiceMock.Verify(mock => mock.GetFoodShops(), Times.Once);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenFoodShopExist()
        {
            var foodShop = CreateFoodShop();
            var dtoExpected = MapModelToFoodShopDto(foodShop);

            _foodShopServiceMock.Setup(c => c.GetFoodShop(2)).ReturnsAsync(foodShop);
            _mapperMock.Setup(m => m.Map<FoodShopDto>(It.IsAny<FoodShop>())).Returns(dtoExpected);

            var result = await _foodShopsController.GetFoodShop(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenFoodShopDoesNotExist()
        {
            _foodShopServiceMock.Setup(c => c.GetFoodShop(2)).ReturnsAsync((FoodShop)null);

            var result = await _foodShopsController.GetFoodShop(2);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShouldCallGetByIdFromService_OnlyOnce()
        {
            var foodShop = CreateFoodShop();
            var dtoExpected = MapModelToFoodShopDto(foodShop);

            _foodShopServiceMock.Setup(c => c.GetFoodShop(2)).ReturnsAsync(foodShop);
            _mapperMock.Setup(m => m.Map<FoodShopDto>(It.IsAny<FoodShop>())).Returns(dtoExpected);

            await _foodShopsController.GetFoodShop(2);

            _foodShopServiceMock.Verify(mock => mock.GetFoodShop(2), Times.Once);
        }

        [Fact]
        public async void Add_ShouldReturnOk_WhenFoodShopIsAdded()
        {
            var foodShop = CreateFoodShop();
            var foodShopCreateDto = new FoodShopCreateDto() { Name = "FoodShop 4", PictureUrl = "hfjsd" };
            var foodShopDto = MapModelToFoodShopDto(foodShop);

            _mapperMock.Setup(m => m.Map<FoodShop>(It.IsAny<FoodShopCreateDto>())).Returns(foodShop);
            _foodShopServiceMock.Setup(c => c.AddFoodShop(foodShop));
            _mapperMock.Setup(m => m.Map<FoodShopDto>(It.IsAny<FoodShop>())).Returns(foodShopDto);

            var result = await _foodShopsController.CreateFoodShop(foodShopCreateDto);

            Assert.IsType<ActionResult<FoodShopDto>>(result);
        }

        [Fact]
        public async void Update_ShouldReturnOk_WhenFoodShopIsUpdatedCorrectly()
        {
            var foodShop = CreateFoodShop();
            var foodShopUpdateDto = new FoodShopUpdateDto() { Name = foodShop.Name, PictureUrl = "Test 2" };

            _mapperMock.Setup(m => m.Map<FoodShop>(It.IsAny<FoodShopUpdateDto>())).Returns(foodShop);
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync(foodShop);
            _foodShopServiceMock.Setup(c => c.UpdateFoodShop(foodShop));

            var result = await _foodShopsController.UpdateFoodShop(foodShop.Id, foodShopUpdateDto);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void Update_ShouldCallUpdateFromService_OnlyOnce()
        {
            var foodShop = CreateFoodShop();
            var foodShopUpdateDto = new FoodShopUpdateDto() { Name = foodShop.Name, PictureUrl = "Test 2" };

            _mapperMock.Setup(m => m.Map<FoodShop>(It.IsAny<FoodShopUpdateDto>())).Returns(foodShop);
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync(foodShop);
            _foodShopServiceMock.Setup(c => c.UpdateFoodShop(foodShop));

            await _foodShopsController.UpdateFoodShop(foodShop.Id, foodShopUpdateDto);

            _foodShopServiceMock.Verify(mock => mock.UpdateFoodShop(foodShop), Times.Once);
        }

        [Fact]
        public async void Remove_ShouldReturnOk_WhenFoodShopIsRemoved()
        {
            var foodShop = CreateFoodShop();
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync(foodShop);
            _foodShopServiceMock.Setup(c => c.DeleteFoodShop(foodShop));

            var result = await _foodShopsController.DeleteFoodShop(foodShop.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnNotFound_WhenFoodShopDoesNotExist()
        {
            var foodShop = CreateFoodShop();
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync((FoodShop)null);

            var result = await _foodShopsController.DeleteFoodShop(foodShop.Id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Remove_ShouldReturnBadRequest_WhenResultIsFalse()
        {
            var foodShop = CreateFoodShop();
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync(foodShop);
            _foodShopServiceMock.Setup(c => c.DeleteFoodShop(foodShop));

            var result = await _foodShopsController.DeleteFoodShop(foodShop.Id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Remove_ShouldCallRemoveFromService_OnlyOnce()
        {
            var foodShop = CreateFoodShop();
            _foodShopServiceMock.Setup(c => c.GetFoodShop(foodShop.Id)).ReturnsAsync(foodShop);
            _foodShopServiceMock.Setup(c => c.DeleteFoodShop(foodShop));

            await _foodShopsController.DeleteFoodShop(foodShop.Id);

            _foodShopServiceMock.Verify(mock => mock.DeleteFoodShop(foodShop), Times.Once);
        }

        private FoodShop CreateFoodShop()
        {
            return new FoodShop()
            {
                Id = 2,
                Name = "FoodShop 2",
                PictureUrl = "avdjsk"
            };
        }

        private FoodShopDto MapModelToFoodShopDto(FoodShop foodShop)
        {
            var foodShopResDto = new FoodShopDto()
            {
                Id = foodShop.Id,
                Name = foodShop.Name,
                PictureUrl = foodShop.PictureUrl
            };
            return foodShopResDto;
        }

        private List<FoodShop> CreateFoodShopList()
        {
            return new List<FoodShop>()
            {
                new FoodShop()
                {
                   Id = 1,
                   Name = "FoodShop 1",
                   PictureUrl = "bdbsb"
                },
                new FoodShop()
                {
                    Id = 2,
                    Name = "FoodShop 2",
                    PictureUrl = "shdbsna"
                },
                new FoodShop()
                {
                    Id = 3,
                    Name = "FoodShop 3",
                    PictureUrl = "ndnsjjs"
                }
            };
        }

        private List<FoodShopDto> MapModelToFoodShoptListDto(List<FoodShop> foodShops)
        {
            var listFoodShops = new List<FoodShopDto>();

            foreach (var item in foodShops)
            {
                var foodShop = new FoodShopDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PictureUrl = "dsjdh"
                };
                listFoodShops.Add(foodShop);
            }
            return listFoodShops;
        }

    }
}
