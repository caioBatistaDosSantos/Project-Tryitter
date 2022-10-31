namespace tryitter.Requesties;
using tryitter.Models;

public class UserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Password { get; set; }
    public string Module { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public ICollection<Post>? Posts { get; set; }

}