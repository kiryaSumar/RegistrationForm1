using FluentValidation;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;
using RegistrationForm.PL.Validators;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();///////////глянуть
//builder.Services.AddTransient<AbstractValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
//спросить почему не работало:
//builder.Services.AddScoped<AbstractValidator<User>, UserValidator>();

//Getting connection string from Configuration file
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));



var app = builder.Build();





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
