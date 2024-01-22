// ***********************************************************************
// Assembly         : Test.RealEstate.Application.UnitTests.Feature.Property.Commands.CreateProperty
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyCommandHandlerTests.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.UnitTests.Feature.Property.Commands.CreateProperty
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Net;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    [TestFixture]
    public class CreatePropertyCommandHandlerTests
    {
        private CreatePropertyCommandHandler handler;
        private Mock<IPropertyRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<CreatePropertyCommandHandler>> loggerMock;
        private CreatePropertyCommand command;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IPropertyRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<CreatePropertyCommandHandler>>();
            handler = new CreatePropertyCommandHandler(repositoryMock.Object, mapperMock.Object, loggerMock.Object);

            command = new CreatePropertyCommand
            {
                Name = "Property_Test",
                Address = "Calle 100 33 23",
                CodeInternal ="test123",
                Year = 2023,
                Price = 10000,
                IdOwner = 1
            };
        }

        [Test]
        public async Task Handle_AddProperty_ReturnsSuccessResponse()
        {
            // Arrange
            var addPropertyEntity = new Property
            {
                IdProperty = 1,
                Name = command.Name,
                Address = command.Address,
                CodeInternal = command.CodeInternal,
                Year = command.Year,
                Price = command.Price,
                IdOwner = command.IdOwner,
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Property>()))
                .ReturnsAsync(addPropertyEntity); 

            mapperMock.Setup(mapper => mapper.Map<Property>(It.IsAny<CreatePropertyCommand>()))
                .Returns(addPropertyEntity);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.True);
            Assert.That(result.ResponseCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public async Task Handle_ErrorAddProperty_ReturnsBadRequest()
        {
            // Arrange
            mapperMock.Setup(mapper => mapper.Map<Property>(It.IsAny<CreatePropertyCommand>()))
                .Returns(new Property());

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyText.ErrorCreateProperty));
        }


    }
}
