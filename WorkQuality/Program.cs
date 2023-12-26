using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkQuality.Models; // Простір імен класа WorkQualityDbContext.
using Microsoft.AspNetCore.Identity;
using WorkQuality.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Рядок підключення з файла конфігурації.
string? connection = builder.Configuration.GetConnectionString("WorkQualityConnection");

// Додаю контекст WorkQualityDbContext в якості сервіса.
builder.Services.AddDbContext<WorkQualityDbContext>(options => options.UseSqlServer(connection));

// Рядок підключення для Core Identity з файла конфігурації.
string? identityConnection = builder.Configuration.GetConnectionString("IdentityConnection");

// Додаю контекст ApplicationDbContext в якості сервіса.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityConnection));
// Додаю з IdentitySample.Mvc (файл Startup.cs).
// https://github.com/dotnet/aspnetcore/tree/main/src/Identity/samples/IdentitySample.Mvc
builder.Services.AddMvc();
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = IdentityConstants.ApplicationScheme;
    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies(o => { });
// Add application services.
builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
builder.Services.AddTransient<ISmsSender, AuthMessageSender>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        WorkQualityDbContext context = services.GetRequiredService<WorkQualityDbContext>();
        context.Database.Migrate();

        ApplicationDbContext applicationIdentityDbContext = services.GetRequiredService<ApplicationDbContext>();
        applicationIdentityDbContext.Database.Migrate();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        string roleAdmin = "Administrator";
        string roleManagementSpecialist = "ManagementSpecialist";
        string adminEmail = "admin@example.com";
        string password = "Qwerty+1";
        if (await roleManager.FindByNameAsync(roleAdmin) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(roleAdmin));
        }
        if (await roleManager.FindByNameAsync(roleManagementSpecialist) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(roleManagementSpecialist));
        }
        if (await userManager.FindByNameAsync(adminEmail) == null)
        {
            ApplicationUser userAdmin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = false
            };
            IdentityResult result = await userManager.CreateAsync(userAdmin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(userAdmin, roleAdmin);
                await userManager.AddToRoleAsync(userAdmin, roleManagementSpecialist);
            }
        }
    }
    catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
        var logger = services.GetRequiredService<ILogger<Program>>();
        //logger.LogError(ex, "An error occurred while seeding the database.");
        logger.LogError(ex, ex.Message);
    }
}

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

// Підключення аутентифікації. 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
