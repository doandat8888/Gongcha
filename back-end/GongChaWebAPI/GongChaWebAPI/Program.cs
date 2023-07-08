using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GongChaWebAPI.Data;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GongChaWebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GongChaWebAPIContext") ?? throw new InvalidOperationException("Connection string 'GongChaWebAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeSizeRepository, ProductTypeSizeRepository>();
builder.Services.AddSwaggerGen();

//*CORS

//< CORS >


builder.Services.AddCors(options => options.AddPolicy(name: "GongChaUICORS",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }
));

//</ CORS >

//==</ Builder >==

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//< CORS >

app.UseCors("GongChaUICORS");

//</ CORS >

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
