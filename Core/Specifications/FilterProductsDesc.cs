namespace Core.Specifications;

public class FilterProductsDesc :Specifications<Product>
{
    public FilterProductsDesc(int? CategoryId , decimal? minprice , decimal? maxprice)
    :base(p=>p.CategoryId==CategoryId && p.Price>=minprice && p.Price<=maxprice) 
    {
        AddOrderByDesc(p => p.Price);
    }
}
