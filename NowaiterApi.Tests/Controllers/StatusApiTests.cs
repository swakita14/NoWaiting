using Microsoft.AspNetCore.Mvc;
using Moq;
using NowaiterApi.Controllers;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Models;
using System.Collections.Generic;
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
            // Act
            var result = _controller.List();

            // Assert 
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void List_ActionExecutes_ReturnsExactNumberOfRestaurant()
        {
            // Arrange 
            _restaurantRepositoryMock.Setup(repo => repo.GetAllRestaurants()).Returns(new List<Restaurant>()
            {
                new Restaurant(), new Restaurant()
            });

            // Act 
            var result = _controller.List();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var restaurants = Assert.IsType<List<Restaurant>>(actionResult.Value);
            Assert.Equal(2, restaurants.Count);
        }
    }
}
