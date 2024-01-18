namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;

    public class CreatePropertyCommand : IRequest<Response>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }



    }
}
