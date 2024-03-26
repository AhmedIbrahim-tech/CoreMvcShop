namespace Core.Interfaces;

    public interface ICategoryRepository:IGenericRepository<Category>
{
	Category GetCategoryWithProducts(int id);
}
