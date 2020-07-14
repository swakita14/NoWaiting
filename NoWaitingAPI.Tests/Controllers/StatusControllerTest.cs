using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Service;
using Xunit;

namespace NowaiterApi.Tests.Services
{
    public class StatusControllerTest
    {
        private readonly Mock<IStatusRepository> _statusRepositoryMock;

        private readonly IAvailabilityService _sut;
        public StatusControllerTest()
        {
            _statusRepositoryMock = new Mock<IStatusRepository>();

            _sut = new AvailabilityService(_statusRepositoryMock.Object);
        }

        [Fact]
        public void IsEmptyDriveThru_IsEmpty_ReturnsTrue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 0, InStore = 0
            };

            // Act 
            var isEmpty = _sut.IsEmptyDriveThru(currentStatus);

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmptyDriveThru_IsNotEmpty_ReturnsFalse()
        {
             // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 1, InStore = 0
            };

            // Act 
            var isEmpty = _sut.IsEmptyDriveThru(currentStatus);

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void IsEmptyInStore_IsEmpty_ReturnsTrue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 0, InStore = 0
            };

            // Act 
            var isEmpty = _sut.IsEmptyInStore(currentStatus);

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmptyInStore_IsNotEmpty_ReturnsFalse()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 0, InStore = 1
            };

            // Act 
            var isEmpty = _sut.IsEmptyInStore(currentStatus);

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void AddDriveThru_NewDriveThru_ReturnsNewAddedValue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 1, InStore = 0
            };

            // Act 
            _sut.AddDriveThru(currentStatus);

            // Assert
            Assert.Equal(2, currentStatus.DriveThru);

        }

        [Fact]
        public void AddInStore_NewInStore_ReturnsNewAddedValue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 0, InStore = 1
            };

            // Act 
            _sut.AddInStore(currentStatus);

            // Assert
            Assert.Equal(2, currentStatus.InStore);
        }

        [Fact]
        public void LeftDriveThru_LeftDriveThru_ReturnsNewAddedValue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 3, InStore = 0
            };

            // Act 
            _sut.LeftDriveThru(currentStatus);

            // Assert
            Assert.Equal(2, currentStatus.DriveThru);
        }

        [Fact]
        public void LeftInStore_LeftInStore_ReturnsNewAddedValue()
        {
            // Arrange
            Status currentStatus = new Status()
            {
                StatusId = 1, RestaurantId = 1, DriveThru = 0, InStore = 3
            };

            // Act 
            _sut.LeftInStore(currentStatus);

            // Assert
            Assert.Equal(2, currentStatus.InStore);
        }

    }
}
