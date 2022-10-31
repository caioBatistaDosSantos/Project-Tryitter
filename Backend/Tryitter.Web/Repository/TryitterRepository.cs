using Microsoft.EntityFrameworkCore;
using tryitter.Models;
using tryitter.Context;
using tryitter.Requesties;
using System.Threading;

namespace tryitter.Repository;

public class TryitterRepository
{
    protected readonly TryitterContext _context;
    public TryitterRepository(TryitterContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Get() {
        var result = await _context.Users.ToListAsync();
        return result;
    }
}