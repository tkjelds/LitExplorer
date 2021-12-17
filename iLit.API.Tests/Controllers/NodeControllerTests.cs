using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using iLit.API.Controllers;
using iLit.Core;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace iLit.API.Tests.Controllers
{
    public class NodeControllerTests
    {

        [Fact]
        public async Task Get_All_returns_Nodes_from_repo()
        {
            // Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var expected = Array.Empty<NodeDTO>();
            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.getAllNodes()).ReturnsAsync(expected);
            var controller = new NodeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Get_given_ID_Returns_Node_from_repo()
        {
            // Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var expected = new NodeDTO(4, "Article4");
            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.getNode(4)).ReturnsAsync(expected);
            var controller = new NodeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get(4);

            // Assert
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public async Task Get_given_Non_Existing_ID_Returns_NotFound()
        {
            // Arrange
            var logger = new Mock<ILogger<NodeController>>();
            //var expected = new NodeDTO(5, "Article4");
            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.getNode(57)).ReturnsAsync(default(NodeDTO));
            var controller = new NodeController(logger.Object, repository.Object);

            // Act
            var actual = await controller.Get(57);

            // Assert
            Assert.IsType<NotFoundResult>(actual.Result);
        }

        [Fact]
        public async Task Create_creates_NodeDTO()
        {
            //Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var toCreate = new NodeCreateDTO { title = "Article4" };

            var created = new NodeDTO(4, "Article4");

            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.createNewNode(toCreate)).ReturnsAsync(created);

            var controller = new NodeController(logger.Object, repository.Object);
            //Act

            var result = await controller.Post(toCreate) as CreatedAtActionResult;
            //Assert
            Assert.Equal(created, result?.Value);
            Assert.Equal("Get", result?.ActionName);
        }

        [Fact]
        public async Task Create_Existing_Node_Gives_BadRequest()
        {
            //Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var toCreate = new NodeCreateDTO { title = "Article1" };

            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.createNewNode(toCreate)).ReturnsAsync((NodeDTO)null);

            var controller = new NodeController(logger.Object, repository.Object);
            //Act

            var result = await controller.Post(toCreate);
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_given_Id_returns_NoContent()
        {
            // Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var repository = new Mock<INodeRepository>();

            repository.Setup(m => m.deleteNode(1)).ReturnsAsync(Response.Deleted);
            var controller = new NodeController(logger.Object, repository.Object);

            // Act
            var response = await controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_given_non_existing_Id_returns_NotFound()
        {
            // Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var repository = new Mock<INodeRepository>();

            repository.Setup(m => m.deleteNode(57)).ReturnsAsync(Response.NotFound);
            var controller = new NodeController(logger.Object, repository.Object);

            // Act
            var response = await controller.Delete(57);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }

    }
}
