using be_watchStore.DATA;
using Microsoft.EntityFrameworkCore;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WatchShopContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("myData")));
builder.Services.AddCors(option => option.AddPolicy("permission",o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("permission");

app.MapControllers();

app.Run();
