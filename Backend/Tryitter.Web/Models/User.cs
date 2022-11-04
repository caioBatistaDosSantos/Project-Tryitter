using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models;
public class User
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email must be in a valid format"), 
    // Required()]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    [JsonIgnore]
    public int PostId { get; set; }
    public ICollection<Post>? Posts { get; set; }
}