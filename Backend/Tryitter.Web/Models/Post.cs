using System.ComponentModel.DataAnnotations;

namespace tryitter.Models;
public class Post
{
    [Key]
    public int Id { get; set; }
    public string? UrlImage { get; set; }
    public string? Content { get; set; }
    // public int UserId { get; set; }
    public User UserId { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

}