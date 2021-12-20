using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using iLit.API.Controllers;
using iLit.Core;
using Xunit;
using System.Threading.Tasks;
using System;

namespace iLit.API.Tests.Controllers
{
    public class EdgeControllerTests
    {
        [Fact]
        public async Task Get_All_returns_Edges_from_repo()
        {
            // Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var expected = Array.Empty<EdgeDTO>();
            var repository = new Mock<IEdgeRepository>();
            repository.Setup(m => m.getAllEdges()).ReturnsAsync(expected);
            var controller = new EdgeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Get_given_ID_Returns_Edge_from_repo()
        {
            // Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var expected = new EdgeDTO(1, 1, 2);
            var repository = new Mock<IEdgeRepository>();
            repository.Setup(m => m.getEdge(1)).ReturnsAsync(expected);
            var controller = new EdgeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get(1);

            // Assert
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public async Task Get_given_Non_Existing_ID_Returns_NotFound()
        {
            // Arrange
            var logger = new Mock<ILogger<EdgeController>>();

            var repository = new Mock<IEdgeRepository>();
            repository.Setup(m => m.getEdge(57)).ReturnsAsync(default(EdgeDTO));
            var controller = new EdgeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get(57);

            // Assert
            Assert.IsType<NotFoundResult>(actual.Result);
        }

        [Fact]
        public async Task Create_creates_EdgeDTO()
        {
            //Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var toCreate = new EdgeCreateDTO {nodeFromID = 3, nodeToID = 4};

            var created = new EdgeDTO(3, 3, 4);

            var repository = new Mock<IEdgeRepository>();
            repository.Setup(m => m.createNewEdge(toCreate)).ReturnsAsync(created);

            var controller = new EdgeController(logger.Object, repository.Object);
            //Act

            var result = await controller.Post(toCreate) as CreatedAtActionResult;
            //Assert
            Assert.Equal(created, result?.Value);
            Assert.Equal("Get", result?.ActionName);
        }

        [Fact]
        public async Task Create_Existing_Edge_Gives_BadRequest()
        {
            //Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var toCreate = new EdgeCreateDTO { nodeFromID = 1, nodeToID = 2 };

            var repository = new Mock<IEdgeRepository>();
            repository.Setup(m => m.createNewEdge(toCreate)).ReturnsAsync((EdgeDTO)null);

            var controller = new EdgeController(logger.Object, repository.Object);
            //Act

            var result = await controller.Post(toCreate);
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_given_Id_returns_NoContent()
        {
            // Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var repository = new Mock<IEdgeRepository>();

            repository.Setup(m => m.deleteEdge(1)).ReturnsAsync(Response.Deleted);
            var controller = new EdgeController(logger.Object, repository.Object);

            // Act
            var response = await controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_given_non_existing_Id_returns_NotFound()
        {
            // Arrange
            var logger = new Mock<ILogger<EdgeController>>();
            var repository = new Mock<IEdgeRepository>();

            repository.Setup(m => m.deleteEdge(57)).ReturnsAsync(Response.NotFound);
            var controller = new EdgeController(logger.Object, repository.Object);

            // Act
            var response = await controller.Delete(57);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }
    }
}
