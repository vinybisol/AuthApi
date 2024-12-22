namespace Domain.Models;
public sealed class LoginModel(string email, string password) : Entity
{
    public string Email { get; } = email;
    public string Password { get; } = password;
}
