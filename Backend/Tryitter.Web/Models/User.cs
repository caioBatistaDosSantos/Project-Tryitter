using System.ComponentModel.DataAnnotations;

namespace tryitter.Models;
public class User
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage="Required field")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters long")]
    public string Name { get; set; }
    [Required(ErrorMessage="Required field")]
    [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Email must be in a valid format")]
    public string Email { get; set; }
    [Required(ErrorMessage="Required field")]
    public int Password { get; set; }
    [Required(ErrorMessage="Required field")]
    [MinLength(3, ErrorMessage="Module must be at least 3 characters long")]
    public string Module { get; set; }
    [Required(ErrorMessage="Required field")]
    [MinLength(3, ErrorMessage="Status must be at least 3 characters long")]
    public string Status { get; set; }
    public ICollection<Post>? Posts { get; set; }

}