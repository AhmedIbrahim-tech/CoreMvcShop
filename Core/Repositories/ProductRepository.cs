namespace Core.Repositories;

    public class ProductRepository : GenericRepository<Product>,IProductRepository
{
	private readonly AppDbContext _appContext;
	public ProductRepository(AppDbContext appContext):base(appContext) 
	{
		_appContext = appContext;
	}

        public async Task<List<Product>>? GetPopularProducts()
	{
		return await _appContext.products.Where(p=>p.IsPopularNow==true).ToListAsync();
	}

    }
