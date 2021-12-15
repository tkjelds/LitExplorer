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

        /*[Fact]
        public async Task Create_creates_Node()
        {
            //Arrange
            var logger = new Mock<ILogger<NodeController>>();
            var toCreate = "Article4";

            var created = (Response.Created, 4);

            var repository = new Mock<INodeRepository>();
            repository.Setup(m => m.createNewNode(toCreate)).ReturnsAsync(created);

            var controller = new NodeController(logger.Object, repository.Object);
            //Act

            var result = await controller.Post(toCreate) as CreatedAtActionResult;
            //Assert
            Assert.Equal(created, result?.Value);
            Assert.Equal("Get", result?.ActionName);
            //Assert.Equal(KeyValuePair.Create("Id", (object?)1), result?.RouteValues?.Single());
        }*/


    }
}
