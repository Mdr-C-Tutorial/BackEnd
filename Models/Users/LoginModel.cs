using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Users;

public class LoginModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}