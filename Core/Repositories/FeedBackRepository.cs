namespace Core.Repositories;

public class FeedBackRepository:GenericRepository<FeedBack>,IFeedBackRepository
{
    private readonly AppDbContext _appDbContext;
    public FeedBackRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
}
