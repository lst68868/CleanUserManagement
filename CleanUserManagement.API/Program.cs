using Npgsql;
using CleanUserManagement.Application;
using CleanUserManagement.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Reflection;
using MediatR;
using CleanUserManagement.Application.Features.Users.Queries;
using CleanUserManagement.Application.Features.Users.Mutations.CreateUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddMediatR(typeof(GetAllUsersHandler).Assembly); // or any other class from that project
builder.Services.AddMediatR(typeof(GetAllUsersHandler).Assembly); // or any other class from that project
builder.Services.AddMediatR(typeof(CreateUserHandler).Assembly);
builder.Services.AddMediatR(typeof(GetUserByUsernameHandler).Assembly);
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<YourValidatorClass>());


builder.Services.AddScoped<IUserRepository, UserRepository>();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<DbConnection>(provider => new NpgsqlConnection(connectionString));

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
