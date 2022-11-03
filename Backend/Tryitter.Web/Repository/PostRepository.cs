using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using tryitter.Models;
using tryitter.Context;
using tryitter.Requesties;
using System.Threading;

namespace tryitter.PostRepository;

public class PostRepository
{
    protected readonly TryitterContext _context;
    public PostRepository(TryitterContext context)
    {
        _context = context;
    }

    public async Task<List<Post>> Get() {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post> GetByPk(int id) {
        return await _context.Posts.FirstAsync(u => u.PostId == id);
    }

    public async Task<Post> Remove(int id) {
        var post = await GetByPk(id);
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return post;
    }
}