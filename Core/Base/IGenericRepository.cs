namespace Core.Base;

    public interface IGenericRepository<T> where T : class
{
	Task<T> GetById(int id);
	Task<IEnumerable<T>> GetAll();
	Task Add(T entity);
	Task Update(T entity);
	void Delete(T entity);
	Task<List<T>>? GetWithSpecifications(Specifications<T>? specifications);
}
