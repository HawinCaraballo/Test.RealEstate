
namespace Test.RealEstate.Application.UnitTests.Feature.Property.ChangePriceProperty
{
    using NUnit.Framework;
    using Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty;

    [TestFixture]
    public class ChangePricePropertyTests
    {
        private ChangePricePropertyCommand Command = new ChangePricePropertyCommand();

        [SetUp]
        public void Setup()
        {
            Command = new ChangePricePropertyCommand
            {
                Price = 200,
                IdProperty = 1
            };


        }

        [Test]
        public void Test()
        {

        }
    }
}
