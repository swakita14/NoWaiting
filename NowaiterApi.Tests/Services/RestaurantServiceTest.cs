using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Service;
using Xunit;

namespace NowaiterApi.Tests.Services
{
    public class RestaurantServiceTest
    {
        private readonly Mock<IRestaurantRepository> _restaurantRepositoryMock;

        private readonly IRestaurantService _sut;
        public RestaurantServiceTest()
        {
            _restaurantRepositoryMock = new Mock<IRestaurantRepository>();

            _sut = new RestaurantService(_restaurantRepositoryMock.Object);
        }

        [Fact]
        public void RestaurantExist_NoMatchingRestaurant_ReturnsFalse()
        {
            // Arrange
            string searchCriteria = "Burger";

            List<Restaurant> searchList = new List<Restaurant>
            {
                new Restaurant {RestaurantId = 1, Name = "Burger King"},
                new Restaurant {RestaurantId = 2, Name = "BurgerVille"}
            };

            _restaurantRepositoryMock.Setup(repo => repo.GetRestaurantsListByName(searchCriteria)).Returns(searchList.FindAll(x => x.Name.Contains(searchCriteria)));

            // Act
            var searchResult = _sut.RestaurantExist(searchCriteria);

            // Assert
            Assert.True(searchResult);
        }

        [Fact]
        public void RestaurantExist_MatchingRestaurant_ReturnsTrue()
        {
            // Arrange
            string searchCriteria = "Pizza";

            List<Restaurant> searchList = new List<Restaurant>
            {
                new Restaurant {RestaurantId = 1, Name = "Burger King"},
                new Restaurant {RestaurantId = 2, Name = "BurgerVille"}
            };

            _restaurantRepositoryMock.Setup(repo => repo.GetRestaurantsListByName(searchCriteria)).Returns(searchList.FindAll(x => x.Name.Contains(searchCriteria)));

            // Act
            var searchResult = _sut.RestaurantExist(searchCriteria);

            // Assert
            Assert.False(searchResult);
        }
    }
}
