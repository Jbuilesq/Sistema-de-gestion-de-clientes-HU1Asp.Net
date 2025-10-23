namespace management.Domain.Interfaces;

public interface IRepository<T>
{
    public Task<T> CreateAsync(T t);
    public Task<T> UpdateAsync(T t);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task DeleteAsync(int id);
}