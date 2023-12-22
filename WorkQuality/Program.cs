using Microsoft.EntityFrameworkCore;
using WorkQuality.Models; // Простір імен класа WorkQualityDbContext.

var builder = WebApplication.CreateBuilder(args);

// Додано мною. Рядок підключення з файла конфігурації.
string? connection = builder.Configuration.GetConnectionString("WorkQualityConnection");

// Додаю контекст WorkQualityDbContext в якості сервіса.
builder.Services.AddDbContext<WorkQualityDbContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- Початок дописаного мною (Begin added by me). ---
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        WorkQualityDbContext context = services.GetRequiredService<WorkQualityDbContext>();
        context.Database.Migrate();
    }
    catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
        var logger = services.GetRequiredService<ILogger<Program>>();
        //logger.LogError(ex, "An error occurred while seeding the database.");
        logger.LogError(ex, ex.Message);
    }
}
// --- Кінець дописаного мною (End added by me).    ---

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
