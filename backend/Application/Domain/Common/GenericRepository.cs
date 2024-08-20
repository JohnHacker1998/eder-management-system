namespace Eder.Domain.Common
{
    public interface GenericRepository<T> where T:class
    {
        public Task<List<T>> Get();
        public Task<T> GetById(Guid id);
        public Task<T> Add(T item);
        public Task<T> Update(T item, Guid id);
        public Task Delete(Guid id);
    }
}
