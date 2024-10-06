using Microsoft.EntityFrameworkCore;
using data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var conection = builder.Configuration;

builder.Services.AddDbContext<User_Controller>(options => options.UseNpgsql(conection.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
