
namespace Test.RealEstate.Application.Mappings
{
    using AutoMapper;
    using Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty;
    using Test.RealEstate.Application.Feature.ImageProperty.Dtos;
    using Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner;
    using Test.RealEstate.Application.Feature.Owner.Dtos;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePropertyCommand, Property>();
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyImage, PropertyImageDto>();
            CreateMap<CreatePropertyImageCommand, PropertyImage> ();
            CreateMap<CreateOwnerCommand, Owner> ();
            CreateMap<Owner, OwnerDto> ();

        }
    }
}
