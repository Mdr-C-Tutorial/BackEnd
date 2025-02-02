using System.Security.Claims;
using BackEnd.Models.Users;
using BackEnd.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;


[ApiController]
public class UserController: ControllerBase
{

    private readonly UserService _userService; // 使用 readonly 修饰

    // 使用构造函数注入 UserService
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (_userService.validateUser(model.UserName, model.Password))
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, model.UserName),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            Console.WriteLine($"User {model.UserName} logged in");
            return Ok(new { message = "Login successful" });
        }
        return Unauthorized(new { message = "Username or password is incorrect" });
    }

    [HttpGet]
    [Route("/login")]
    public async Task<IActionResult> Login()
    {
        var userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
        Console.WriteLine($"User {userName} valid");
        if (userName == null)
        {
            return Unauthorized(new { message = "未登录" });
        }
        return Ok(new { userName = "admin"});
    }
}