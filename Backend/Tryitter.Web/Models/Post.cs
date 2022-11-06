using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models;
public class Post
{
    [Key, JsonIgnore]
    public int? PostId { get; set; }
    public string UrlImage { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; } = null!;
}