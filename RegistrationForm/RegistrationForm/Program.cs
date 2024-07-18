using Microsoft.EntityFrameworkCore;
using RegistrationForm.BLL.Services;
using RegistrationForm.PL.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var services = builder.Services;//Nope



builder.Services.AddControllers();

builder.Services.AddDbContext<UserContext>(opt =>////////// Не сработало
    opt.UseInMemoryDatabase("UserList"));/////////////////

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<IUserService>(options =>
    //options.UseSqlite(connection));

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
