namespace Core.Repositories;

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository

    {
	private readonly AppDbContext _appDbContext;
	public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
	{
		_appDbContext = appDbContext;
	}
        public Category GetCategoryWithProducts(int id)
	{
		return _appDbContext.Categories.Include(c => c.Products).FirstOrDefault(e => e.Id == id);
	}

    }
