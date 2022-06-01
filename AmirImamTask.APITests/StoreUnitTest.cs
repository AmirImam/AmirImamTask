using AmirImamTask.API.Controllers;
using AmirImamTask.BusinessServices;
using AmirImamTask.Entities;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace AmirImamTask.APITests
{
    public class StoreUnitTest
    {
        
        [Fact]
        public async void GetAllStoresShouldReturnsCollectionOfStores()
        {

            // Arrange
            var mockRepo = new Mock<IStoreService>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Store>());
            var controller = new StoreController(mockRepo.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert

            Assert.NotEqual(result, null);
        }
    }
}