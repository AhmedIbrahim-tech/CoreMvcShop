namespace Core.Specifications;

public class MinMaxPriceSpecifications :Specifications<Product>
{
    public MinMaxPriceSpecifications(int minPrice , int maxPrice) 
        :base(p=>p.Price<=maxPrice && p.Price>=minPrice)
    {

    }
}
