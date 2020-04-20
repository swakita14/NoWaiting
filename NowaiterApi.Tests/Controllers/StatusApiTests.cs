using Microsoft.AspNetCore.Mvc;
using Moq;
using NowaiterApi.Controllers;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using Xunit;

namespace NowaiterApi.Tests.Controllers
{    public class StatusApiTests
    {
        // Adding mock repository class and controller 
        private readonly Mock<IRestaurantRepository> _restaurantRepositoryMock;
        private readonly Mock<IStatusRepository> _statusRepositoryMock;
        private readonly StatusApi _controller;

        public StatusApiTests()
        {
            _restaurantRepositoryMock = new Mock<IRestaurantRepository>();
            _statusRepositoryMock = new Mock<IStatusRepository>();

            // Passing in mock object to controller
            _controller = new StatusApi(_restaurantRepositoryMock.Object, _statusRepositoryMock.Object);
        }

        [Fact]
        public void List_ActionExecutes_ReturnsActionResult()
        {
            // Calling List api method 
            var result = _controller.List();

            // Assert 
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
