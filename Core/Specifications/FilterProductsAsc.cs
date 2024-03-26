namespace Core.Specifications;

public class FilterProductsAsc : Specifications<Product>
{
    public FilterProductsAsc(int? CategoryId, decimal? minprice = 0, decimal? maxprice = 20000)
   : base(p => CategoryId != null ? (p.CategoryId == CategoryId):(p.CategoryId>-1)&& minprice!=null?(p.Price >= minprice):(p.Price>=0)
     && maxprice!=null ? (p.Price <= maxprice):(p.Price<=20000))
    {
        AddOrderBy(p => p.Price);
    }
}
