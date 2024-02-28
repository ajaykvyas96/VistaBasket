using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VistaBasket.Catalog.Data;
using VistaBasket.Catalog.WebAPI.Extensions;
using VistaBasket.Catalog.WebAPI.Helpers;
using VistaBasket.Catalog.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CatalogDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("VistaBasket.Catalog"));
});
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddSwaggerGen();
builder.AddAppAuthetication();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7205")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerDocumentation();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<CurrentUserMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
