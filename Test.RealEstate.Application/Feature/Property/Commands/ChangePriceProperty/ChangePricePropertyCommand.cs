
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class ChangePricePropertyCommand : IRequest<Response>
    {
        public int IdProperty { get; set; }
        public double Price { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
