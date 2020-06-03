using Microsoft.AspNetCore.Mvc;
using Moq;
using NowaiterApi.Controllers;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;
using System.Collections.Generic;
using NowaiterApi.Interfaces.Service;
using Xunit;

namespace NowaiterApi.Tests.Controllers
{    public class SearchControllerTest
    {
        // Adding mock repository class and controller 
        private readonly Mock<IRestaurantRepository> _restaurantRepositoryMock;
        private readonly Mock<IStatusRepository> _statusRepositoryMock;
        private readonly Mock<IRestaurantService> _restaurantServiceMock;
        private readonly SearchController _sut;

        public SearchControllerTest()
        {
            _restaurantRepositoryMock = new Mock<IRestaurantRepository>();
            _statusRepositoryMock = new Mock<IStatusRepository>();
            _restaurantServiceMock = new Mock<IRestaurantService>();

            // Passing in mock object to controller
            _sut = new SearchController(_restaurantServiceMock.Object, _restaurantRepositoryMock.Object, _statusRepositoryMock.Object);
        }

        [Fact]
        public void List_ActionExecutes_ReturnsActionResult()
        {
            // Act
            var result = _sut.List();

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
            var result = _sut.List();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var restaurants = Assert.IsType<List<Restaurant>>(actionResult.Value);
            Assert.Equal(2, restaurants.Count);
        }

    }
}
