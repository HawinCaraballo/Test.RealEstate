// ***********************************************************************
// Assembly         : Test.RealEstate.Application.UnitTests.Feature.Property.Commands.UpdateProperty
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="UpdatePropertyCommandHandlerTests.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.UnitTests.Feature.Property.Commands.UpdateProperty
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Net;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    [TestFixture]
    public class UpdatePropertyCommandHandlerTests
    {
        private UpdatePropertyCommandHandler handler;
        private Mock<IPropertyRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<UpdatePropertyCommandHandler>> loggerMock;
        private UpdatePropertyCommand command;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IPropertyRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<UpdatePropertyCommandHandler>>();
            handler = new UpdatePropertyCommandHandler(repositoryMock.Object, mapperMock.Object, loggerMock.Object);

            command = new UpdatePropertyCommand
            {
                IdProperty = 1,
                Name = "Property_Test",
                Address = "Calle 100 33 23",
                CodeInternal = "test123",
                Year = 2023,
                Price = 10000,
                IdOwner = 1
            };
        }

        [Test]
        public async Task Handle_UpdateProperty_ReturnsSuccessResponse()
        {
            // Arrange
            var existingProperty = new Property
            {
                IdProperty = 1,
                Name = "Old Property_Test",
                Address = "Carrera 2 44-11",
                CodeInternal = "code123",
                Year = 2024,
                Price = 20000,
                IdOwner = 1
            };

            repositoryMock.Setup(repo => repo.GetByIdAsync(command.IdProperty))
                .ReturnsAsync(existingProperty);

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Property>()))
                .ReturnsAsync(existingProperty); 

            mapperMock.Setup(mapper => mapper.Map<PropertyDto>(It.IsAny<Property>()))
                .Returns(new PropertyDto {
                    IdProperty = 1,
                    Name = command.Name,
                    Address = command.Address,
                    CodeInternal = command.CodeInternal,
                    Year = command.Year,
                    Price = command.Price,
                    IdOwner = command.IdOwner
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.True);
            Assert.That(result.ResponseCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public async Task Handle_PropertyDoesNotExist_ReturnsBadRequest()
        {
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyText.PropertyNoExists));
        }
    }
}
