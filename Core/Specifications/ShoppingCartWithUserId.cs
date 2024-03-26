namespace Core.Specifications;

public class ShoppingCartWithUserId:Specifications<ShoppingCart>
{
    public ShoppingCartWithUserId(string UserId):base(e=>e.UserId==UserId) 
    {
        AddInclude(e => e.OrderList);
    }
}
