using System.ComponentModel.DataAnnotations;

namespace tryitter.Models;
public class Post
{
    public int PostId { get; set; }
    public string? UrlImage { get; set; }
    public string? Content { get; set; }
    // public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

}