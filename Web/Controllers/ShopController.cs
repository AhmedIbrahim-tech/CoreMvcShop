using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		[ResponseCache(Duration = 3600)]
		public async Task<IActionResult> Index()
        {

            var products = await _unitOfWork.ProductRepository.GetAll();
            ViewData["Categories"] = await _unitOfWork.CategoryRepository.GetAll();

            return View(products);
        }

        [HttpGet]
		[ResponseCache(Duration = 3600)]
		public async Task<IActionResult> FilterProducts(int? CategoryId , decimal? MinPrice ,decimal? MaxPrice 
            ,bool SortAsc = true)
        {
            Specifications<Product> specifications;

            if (SortAsc == true)
                specifications = new FilterProductsAsc(CategoryId,MinPrice,MaxPrice);
            else
                specifications = new FilterProductsDesc(CategoryId, MinPrice, MaxPrice);

            var FilteredProducts = await _unitOfWork.ProductRepository.GetWithSpecifications(specifications);
            
            return PartialView("_filterProducts",FilteredProducts);
        }
    }
}
