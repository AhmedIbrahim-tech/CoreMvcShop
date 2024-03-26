using Core.AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Core;

public static class ModuleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IFeedBackRepository, FeedBackRepository>();
        services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
        services.AddTransient<IEmailSender, EmailSenderRepository>();

        //Configuration of AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));


        return services;
    }
}
