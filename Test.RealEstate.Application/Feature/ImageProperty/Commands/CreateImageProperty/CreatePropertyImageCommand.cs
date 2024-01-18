namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class CreatePropertyImageCommand : IRequest<Response>
    {
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = new byte[0];
        public string FileName { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
