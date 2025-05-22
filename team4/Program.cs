using Microsoft.EntityFrameworkCore;
using team4.DAL;
using Serilog;
using team4.Middleware;
using team4.BLL.Services;
using team4.BLL.Services.Product;
using team4.BLL.Services.Category;
using team4.DAL.Repositories.Product;
using team4.DAL.Repositories.Category;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() 
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour) // логування в файл що години
    .CreateLogger();


builder.Host.UseSerilog();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("team4")
    ));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


//Middlware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
