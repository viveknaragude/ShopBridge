using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ShopBridge.Controllers;
using ShopBridge.Dal.Interfaces;
using ShopBridge.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge.Test.Controllers
{
    [TestClass]
    public class ItemsControllerTests
    {
        private ItemsController _target;
        private IItemRepository _itemRepository;
        private ILogger<ItemsController> _fakeLogger;
        private IMapper _mapper;
        private Dal.Entities.Item _item;
        private Item _newItem;


        [TestInitialize]
        public void TestInitialize()
        {
            _itemRepository = Substitute.For<IItemRepository>();
            _fakeLogger = Substitute.For<ILogger<ItemsController>>();
            var httpContext = new DefaultHttpContext();
            _mapper = MapperInitialize();
            _target = new ItemsController(_fakeLogger, _mapper, _itemRepository);
            _target.ControllerContext = new ControllerContext() { HttpContext = httpContext };

            _item = MockItemObject();
            _newItem = ItemInput();

        }
        public IMapper MapperInitialize()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Dal.Entities.Item, Item>();
                opts.CreateMap<Item, Dal.Entities.Item>();
            });
            return config.CreateMapper();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task Get_Item_With_Valid_Name_Should_Return_SingleItem()
        {
            // Arrange
            var name = "user1";
            _itemRepository.GetItemAsync(name).Returns(Task.FromResult(_item));

            // Act
            var result = await _target.GetAsync(name);

            // Assert
            var response = result.Result as ObjectResult;
            var item = response.Value as Item;
            item.Name.Should().BeEquivalentTo(name);
            item.Description.Should().BeEquivalentTo(name);

        }

        [TestMethod, TestCategory("Unit")]
        public async Task Get_Item_Should_Return_NotFound_When_Provided_Name_Not_Present_In_Db()
        {
            // Arrange
            _itemRepository.GetItemAsync(Arg.Any<string>()).Returns(Task.FromResult<Dal.Entities.Item>(null));

            // Act
            var result = await _target.GetAsync("user1");

            // Assert
            var response = result.Result as NotFoundResult;
            response.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        }

        [TestMethod, TestCategory("Unit")]
        public async Task Get_AllUser_Should_Return_Paginated_Result()
        {
            // Arrange
            _itemRepository.GetAllItemAsync(null).Returns(Task.FromResult(new List<Dal.Entities.Item> { _item }));

            //Act
            var result = await _target.GetAllAsync(null);

            // Assert
            var response = result as ObjectResult;
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var items = response.Value as PaginatedList<Item>;
            items.Page.Should().Be(1);
            items.PageSize.Should().Be(50);
            items.TotalCount.Should().Be(1);
            items.TotalPages.Should().Be(1);
            items.Items.Count.Should().Be(1);
        }

        private Dal.Entities.Item MockItemObject() => new Dal.Entities.Item
        {
            Id = 1,
            Description = "User1",
            Name = "User1",
            Price = 20,
            Quantity = 100
        };
        private Item ItemInput() => new Item
        {
            Description = "User1",
            Name = "User1",
            Price = 20,
            Quantity = 100

        };
    }
}
