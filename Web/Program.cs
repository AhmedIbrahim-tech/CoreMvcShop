using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

#region Connection Database

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

#endregion

#region Dependency Injection

builder.Services.AddCoreDependencies(builder.Configuration).AddServiceRegisteration(builder.Configuration);

#endregion

#region Data Seed

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Seed roles
    await SeedRoles(roleManager);

    // Seed users with roles
    await SeedUsers(userManager, roleManager);
}

async Task SeedRoles(RoleManager<IdentityRole> roleManager)
{
    // Check if roles exist, if not, create them
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }
}

async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Check if the admin user exists, if not, create it
    var adminUser = await userManager.FindByNameAsync("admin");

    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = "admin",
            FirstName = "admin",
            LastName = "admin",
            EmailAddress = "admin@example.com",
            // Add other properties as needed
        };

        await userManager.CreateAsync(adminUser, "Admin@123"); // Replace with a secure password

        // Assign the "Admin" role to the admin user
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
