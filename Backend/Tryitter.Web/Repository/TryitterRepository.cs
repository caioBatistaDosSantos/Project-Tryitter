using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using tryitter.Models;
using tryitter.Context;
using tryitter.Requesties;
using System.Threading;

namespace tryitter.Repository;

public class UserRepository
{
    protected readonly TryitterContext _context;
    public UserRepository(TryitterContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Get() {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetByPk(int id) {
        var user = await _context.Users.FirstAsync(u => u.Id == id);
        return user;
    }
};