
namespace Test.RealEstate.Application.UnitTests.Feature.Property.Queries.GetAllProperties
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Net;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    [TestFixture]
    public class GetAllPropertiesQueryHandlerTests
    {
        private GetAllPropertiesQueryHandler handler;
        private Mock<IPropertyRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<GetAllPropertiesQueryHandler>> loggerMock;
        private GetAllPropertiesQuery query;
        private List<Property> propertyResult;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IPropertyRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<GetAllPropertiesQueryHandler>>();

            handler = new GetAllPropertiesQueryHandler(
                repositoryMock.Object,
                mapperMock.Object,
                loggerMock.Object
            );
            query = new GetAllPropertiesQuery(1, 10);

            propertyResult = new List<Property>
            {
                new() { IdProperty = 1, Name = "Property 1", Address = "Calle 123", CodeInternal = "test123", Year = 2023, Price = 23000, IdOwner = 1 },
                new() { IdProperty = 2, Name = "Property 2", Address = "Carrera 123", CodeInternal = "test456", Year = 2024, Price = 9000, IdOwner = 1 },
            }; ;
        }

        [Test]
        public async Task Handle_GetAllProperty_ReturnsSuccessResponse()
        {
            // Arrange
            repositoryMock.Setup(repo => repo.GetPagedReponseAsync(query.PageNumber, query.PageSize))
                .ReturnsAsync(propertyResult);

            mapperMock.Setup(mapper => mapper.Map<List<PropertyDto>>(It.IsAny<List<Property>>()))
                .Returns(propertyResult
                            .Select(p =>
                            new PropertyDto
                            {
                                IdProperty = 1,
                                Name = "Property 1",
                                Address = "Calle 123",
                                CodeInternal = "test123",
                                Year = 2023,
                                Price = 23000,
                                IdOwner = 1
                            }).ToList());

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.True);
            Assert.That(result.ResponseCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public async Task Handle_PropertyDoesNotExist_ReturnsBadRequest()
        {
            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.False);
            Assert.That(result.Message, Is.EqualTo(ConstantPropertyText.PropertyNoExists));
        }


    }
}
