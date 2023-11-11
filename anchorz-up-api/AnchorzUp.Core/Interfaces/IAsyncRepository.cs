using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorzUp.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : class, IEntity
    {
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> AddRangeAsync(IReadOnlyList<T> entities, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> LastOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
