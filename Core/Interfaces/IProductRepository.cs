namespace Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
	{
        Task<List<Product>>? GetPopularProducts();

    }
}
