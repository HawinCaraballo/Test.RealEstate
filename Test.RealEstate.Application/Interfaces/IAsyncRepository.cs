
namespace Test.RealEstate.Application.Interfaces
{
    using Test.RealEstate.Domain.Common;
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);

        //UnitOfWork
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);

    }
}
