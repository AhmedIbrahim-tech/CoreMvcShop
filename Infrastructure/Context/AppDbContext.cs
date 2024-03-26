using Infrastructure.Models;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.
		//		UseSqlServer("Data Source=AHMEDEPRAHIM\\SQLEXPRESS;Initial Catalog=EShop-NETMvc;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		//}
		public DbSet<Product> products {  get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<ApplicationUser> Users {  get; set; }
		public DbSet<FeedBack> FeedBacks { get; set; }
	}
}
