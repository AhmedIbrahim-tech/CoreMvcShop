namespace Core.UnitOfWork;

    public interface IUnitOfWork:IDisposable
{
	IProductRepository ProductRepository { get; }
	public ICategoryRepository CategoryRepository { get; }
	public IFeedBackRepository FeedBackRepository { get; }
	public IShoppingCartRepository ShoppingCartRepository { get; }
	public IEmailSender EmailSender { get; }
	void Commit();
}
