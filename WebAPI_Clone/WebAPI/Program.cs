using Library.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebAPI.Business;
using WebAPI.Business.Infrastructure;
using WebAPI.Core.Infrastructute;
using WebAPI.DataContext;
using WebAPI.Middlewares;

var myAllowOrigins = "_myAllowOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddDbContext<LearningDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LearningContext"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers()
.AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDirectoryBrowser();
builder.Services.AddTransient<IResponsitory, Respository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "app v1"));
}

app.UseCors(myAllowOrigins);
app.UseStaticFiles();

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "Images"));
var requestPath = "/Images";

// Enable displaying browser links.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});


app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<SimpleMiddleware>();
app.Run();

