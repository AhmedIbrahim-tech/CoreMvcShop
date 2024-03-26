namespace Core.Interfaces
{
    public interface IShoppingCartRepository:IGenericRepository<ShoppingCart>
	{
         Task AddToCart(string UserId, int id);
         void Add(string userid);
         Task DeleteFromCart(string UserId,int ProductId);
         Task<ShoppingCart> GetByIdIncludedOrderList(string userId);
    }
}
