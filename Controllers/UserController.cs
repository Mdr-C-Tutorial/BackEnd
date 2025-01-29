using BackEnd.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;


[ApiController]
public class UserController: ControllerBase
{

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        return Unauthorized(new { message = "Username or password is incorrect" });
    }

    [HttpGet]
    [Route("/login")]
    public string Test()
    {
        return "Hello World!";
    }
}