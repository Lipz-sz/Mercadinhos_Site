using Microsoft.EntityFrameworkCore;
using MarketplaceAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseSqlite("Data Source=dataBase.db;Foreign Keys=True"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Access for /swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

