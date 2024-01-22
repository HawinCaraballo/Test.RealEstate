// ***********************************************************************
// Assembly         : Test.RealEstate.Application.UnitTests.Feature.ImageProperty.Commands.CreateImageProperty
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyImageCommandHandlerTests.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.UnitTests.Feature.ImageProperty.Commands.CreateImageProperty
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Net;
    using Test.RealEstate.Application.Constant.Feature.PropertyImage;
    using Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    [TestFixture]
    public class CreatePropertyImageCommandHandlerTests
    {
        private CreatePropertyImageCommandHandler handler;
        private Mock<IPropertyImageRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<CreatePropertyImageCommandHandler>> loggerMock;
        private CreatePropertyImageCommand command;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IPropertyImageRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<CreatePropertyImageCommandHandler>>();

            handler = new CreatePropertyImageCommandHandler(
                mapperMock.Object,
                repositoryMock.Object,
                loggerMock.Object
            );

            command = new CreatePropertyImageCommand
            {
                File = [1, 2, 3, 4],
                Enabled = true,
                FileName = "Test",
                IdProperty = 1
            };
        }


        [Test]
        public async Task Handle_RepositoryAddsPropertyImage_ReturnsSuccessResponse()
        {
            // Arrange
            var propertyImageEntity = new PropertyImage
            {
                IdProperty = command.IdProperty,
                Enabled = true,
                File = command.File,
                IdPropertyImage = 1,
                FileName = command.FileName
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<PropertyImage>()))
                .ReturnsAsync(propertyImageEntity); 

            mapperMock.Setup(mapper => mapper.Map<PropertyImage>(It.IsAny<PropertyImage>()))
                .Returns(new PropertyImage
                {
                    IdProperty = command.IdProperty,
                    Enabled = true,
                    File = command.File,
                    IdPropertyImage = 1,
                    FileName = command.FileName
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.True);
            Assert.That(result.ResponseCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public async Task Handle_ErrorAddPropertyImage_ReturnsBadRequest()
        {

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyImageText.ErrorCreatePropertyImage));
        }

    }
}
