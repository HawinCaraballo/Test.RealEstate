
namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class CreateOwnerCommand : IRequest<Response>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly? Birthday { get; set; }
    }
}
