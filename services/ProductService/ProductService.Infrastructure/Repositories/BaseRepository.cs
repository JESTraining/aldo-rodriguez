using ProductService.Domain.Repositories;

namespace ProductService.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
{
    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(new List<T>());
    }

    public virtual async Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> Create(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
