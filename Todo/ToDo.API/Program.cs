using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.UserViewModel;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;
using ToDo.Infra.Context;
using ToDo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Mapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDto>().ReverseMap();
    cfg.CreateMap<UserDto, UpdateUserViewModel>().ReverseMap();
    //cfg.CreateMap<User, GetUserDTO>().ReverseMap();
    // cfg.CreateMap<User, UpdatedUserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
    //cfg.CreateMap<UpdateUserViewModel, UserDto>().ReverseMap();
    //cfg.CreateMap<UpdateUserViewModel, UpdatedUserDto>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

//builder.Services.AddSingleton(d => builder.Configuration);
//builder.Services.AddDbContext<dbCrudUsuarioContext>(options => options.UseMySql("server=localhost;port=3306;User Id=root;database=dbCrudUser;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Mapper

autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDto>().ReverseMap();
    //cfg.CreateMap<UserDto, UpdateUserViewModel>().ReverseMap();
    //cfg.CreateMap<User, GetUserDTO>().ReverseMap();
    // cfg.CreateMap<User, UpdatedUserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
    //cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
    //cfg.CreateMap<UpdateUserViewModel, UpdatedUserDTO>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

//builder.Services.AddSingleton(d => builder.Configuration);
//builder.Services.AddDbContext<dbCrudUsuarioContext>(options => options.UseMySql("server=localhost;port=3306;User Id=root;database=dbCrudUser;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});


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