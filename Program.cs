using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BackEnd;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigin", // 可以自定义策略名称
                b =>
                {
                    b.WithOrigins("http://localhost:5173") // 允许所有来源
                        .AllowAnyMethod() // 允许所有 HTTP 方法
                        .AllowAnyHeader() // 允许所有请求头;
                        .AllowCredentials();
                });
        });

        builder.Services.AddScoped<UserService>();
        
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";  // 登录页面的地址，根据实际情况修改
                options.AccessDeniedPath = "/account/accessdenied";
            });

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseCors("AllowAllOrigin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}