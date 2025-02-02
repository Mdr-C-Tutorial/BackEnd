using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Users;

public class LoginModel
{
    [Required] public required string UserName { get; set; }
    [Required] public required string Password { get; set; }
    public bool RememberMe { get; set; }
}