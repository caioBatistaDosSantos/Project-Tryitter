using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context;

public interface ITryitterContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}