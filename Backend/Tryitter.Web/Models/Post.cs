using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models;
public class Post
{
    public int PostId { get; set; }
    public string? UrlImage { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; } = null!;
}