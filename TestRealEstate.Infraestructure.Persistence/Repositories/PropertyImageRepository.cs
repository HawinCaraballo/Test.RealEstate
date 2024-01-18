namespace Test.RealEstate.Infraestructure.Persistence.Repositories
{
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;
    using Test.RealEstate.Infraestructure.Persistence.Context;
    public class PropertyImageRepository : RepositoryBase<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
