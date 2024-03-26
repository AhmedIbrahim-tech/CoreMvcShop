namespace Web.Controllers;

public class ContactController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ContactController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> SaveFeedBack(FeedBack feedBack)
    {
       await _unitOfWork.FeedBackRepository.Add(feedBack);
        _unitOfWork.Commit();
        return RedirectToAction("Index");
    }
}
