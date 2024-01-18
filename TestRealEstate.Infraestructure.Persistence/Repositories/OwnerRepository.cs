namespace Test.RealEstate.Infraestructure.Persistence.Repositories
{
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;
    using Test.RealEstate.Infraestructure.Persistence.Context;
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
