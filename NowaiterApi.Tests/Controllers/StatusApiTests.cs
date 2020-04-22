using Microsoft.AspNetCore.Mvc;
using Moq;
using NowaiterApi.Controllers;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;
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

        [Fact]
        public void Search_ActionExecutes_ReturnsMatchingRestaurants()
        {
            // Arrange
            var searchString = "Burger";
            _restaurantRepositoryMock.Setup(repo => repo.GetRestaurantsByName(searchString)).Returns(new List<Restaurant>()
            {
                new Restaurant{ RestaurantId =1, Name = "Burger" , Phone = "123", Address1 ="456"}, 
                new Restaurant{ RestaurantId = 2, Name = "Burgerville", Phone = "123", Address1="456"}
            });

            _statusRepositoryMock.Setup(repo => repo.GetRestaurantStatusById(1)).Returns(new Status { StatusId = 1,  DriveThru = 0, InStore = 0});
            _statusRepositoryMock.Setup(repo => repo.GetRestaurantStatusById(2)).Returns(new Status { StatusId = 2, DriveThru = 0, InStore = 0 });

            //Act
            var result = _controller.Search(searchString);

            //Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var restaurants = Assert.IsType<List<RestaurantAvailabilityViewModel>>(actionResult.Value);
            Assert.Equal(2, restaurants.Count);
        }
    }
}
