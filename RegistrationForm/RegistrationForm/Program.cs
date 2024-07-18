using FluentValidation;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;
using RegistrationForm.PL.Validators;
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

var app = builder.Build();


//var ValidationService = app.Services.GetService<AbstractValidator<User>>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
