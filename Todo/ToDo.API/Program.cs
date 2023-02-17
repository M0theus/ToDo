using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDo.API.Token;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.AssigmentViewModel;
using ToDo.API.ViewModels.AssignmentListViewModel;
using ToDo.API.ViewModels.Token;
using ToDo.API.ViewModels.UserViewModel;
using ToDo.Application.Configuration;
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
    //user
    cfg.CreateMap<User, UserDto>().ReverseMap();
    cfg.CreateMap<UserDto, UpdateUserViewModel>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();

    //assignment
    cfg.CreateMap<Assignment, AssignmentDto>().ReverseMap();
    cfg.CreateMap<AssignmentDto, UpdateAssignmentViewModel>().ReverseMap();
    cfg.CreateMap<CreateAssignmentViewModel, AssignmentDto>().ReverseMap();
    
    //assignmentList
    cfg.CreateMap<AssignmentList, AssignmentListDto>().ReverseMap();
    cfg.CreateMap<AssignmentListDto, UpdateListViewModel>().ReverseMap();
    cfg.CreateMap<CreateAssignmentListViewModel, AssignmentListDto>().ReverseMap();
    
    //login
    cfg.CreateMap<LoginUserDto, LoginViewModel>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

//user
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//assignment
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

//assignmentList
builder.Services.AddScoped<IAssignmentListService, AssignmentListService>();
builder.Services.AddScoped<IAssignmentListRepository, AssignmentListRepository>();

//token
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

#endregion


#region Jwt

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }) 
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();