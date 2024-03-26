namespace Core.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Product, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
    }
}
