namespace Test.RealEstate.Application.UnitTests.Feature.Property.Commands.ChangePriceProperty
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Net;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    [TestFixture]
    public class ChangePricePropertyCommandHandlerTests
    {
        private ChangePricePropertyCommandHandler handler;
        private Mock<IPropertyRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<ChangePricePropertyCommandHandler>> loggerMock;
        private ChangePricePropertyCommand command;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IPropertyRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<ChangePricePropertyCommandHandler>>();
            handler = new ChangePricePropertyCommandHandler(repositoryMock.Object, mapperMock.Object, loggerMock.Object);

            command = new ChangePricePropertyCommand
            {
                IdProperty = 1,
                Price = 100
            };
        }

        [Test]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var existingProperty = new Property
            {
                IdProperty = command.IdProperty,
                Price = command.Price,
            };

            repositoryMock.Setup(repo => repo.GetByIdAsync(command.IdProperty))
                .ReturnsAsync(existingProperty);

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Property>()))
                .ReturnsAsync(existingProperty);

            mapperMock.Setup(mapper => mapper.Map<PropertyDto>(It.IsAny<Property>()))
                .Returns(new PropertyDto() { IdProperty = command.IdProperty, Name = "testName", Address = "tesAdd", IdOwner = 1, Price = command.Price });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.True);
            Assert.That(result.ResponseCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public async Task Handle_NonExistentProperty_ReturnsBadRequest()
        {
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyText.PropertyNoExists));
        }

        [Test]
        public async Task Handle_ErrorUpdateProperty_ReturnsBadRequest()
        {
            // Arrange
            var existingProperty = new Property
            {
                IdProperty = command.IdProperty,
                Price = command.Price,
            };

            repositoryMock.Setup(repo => repo.GetByIdAsync(command.IdProperty))
                .ReturnsAsync(existingProperty);
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyText.ErrorUpdatePropertyPrice));
        }

    }
}
