using WebAPI.Utilities;
using Application;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Persistence;
using Application.Services;
using Application.Interfaces.Auth;
using Application.Interfaces;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("NpgsqlConnection");
builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddDbContext<UsersDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<IUsersDbContext, UsersDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddScoped<UsersService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

//app.UseMiddleware<NotFoundMiddleware>();

//app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("/login", (LoginUserRequest request, UsersService usersService) =>
//{
//    var token = usersService.Login(request.Name, request.Email, request.Password);
//    return Results.Ok(token);
//});

//app.UseAuthorization();



app.Run();
