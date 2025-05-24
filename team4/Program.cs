using Microsoft.EntityFrameworkCore;
using team4.DAL;
using Serilog;
using team4.Middleware;
using team4.BLL.Services;
using team4.DAL.Repositories.Product;
using AutoMapper;
using team4.BLL.Mapping;
using Microsoft.Extensions.FileProviders;
using team4.BLL.Services.ProductService;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour) // ëîãóâàííÿ â ôàéë ùî ãîäèíè
            .CreateLogger();

        //AutoMapper
        builder.Services.AddAutoMapper(typeof(CategoryProfile).Assembly);

        builder.Host.UseSerilog();

        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<ImageService>();


        builder.Services.AddControllers();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
      
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly("team4")
            ));



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


        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "UploadedImages")),
            RequestPath = "/uploads"
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}