namespace Core.ViewModels;

public class ShopViewModel
{
    public int CategoryId {  get; set; }
    public decimal MinPrice {  get; set; }
    public decimal MaxPrice { get; set; }
    
    public bool sorted {  get; set; }

}
