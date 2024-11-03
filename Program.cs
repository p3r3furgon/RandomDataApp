using B1ask1.DataAccess;
using B1Task1.DataAccess.Repositories;
using B1Task1.Interfaces.Repositories;
using B1Task1.Interfaces.Services;
using B1Task1.Services;
using B1Task1.Middleware;
using B1TestTask1.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddScoped<IRandomDataRepository, RandomDataRepository>();
builder.Services.AddScoped<IRandomDataFilesGenerationService, RandomDataFilesGenerationService>();
builder.Services.AddScoped<IRandomDataParsingService, RandomDataParsingService>();

builder.Services.AddDbContext<RandomDataDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(RandomDataDbContext)));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.UseStaticFiles();
app.Run();
