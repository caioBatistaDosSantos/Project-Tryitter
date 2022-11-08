using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using tryitter.Models;
using tryitter.Context;
using tryitter.Requesties;
using System.Threading;
using TryitterAuth;
using Tryitter.Requesties;
using tryitter.Auth;

namespace tryitter.UserRepository;

public class UserRepository
{
    protected readonly TryitterContext _context;
    public UserRepository(TryitterContext context)
    {
        _context = context;
    }

    public async Task<AuthToken> Login(UserLogin request) {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if(user == null || user.Password != request.Password) 
            throw new DbUpdateException("User not found!");

        var token = new TokenGenerator().Generate(user);
        return new AuthToken { Token = token };
    }
    public async Task<List<User>> Get() {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByPk(int id) {
        return await _context.Users.FirstAsync(u => u.Id == id);
    }

    public async Task<User> Remove(int id) {
        var user = await GetByPk(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(int id, User request) {
        var user = await _context.Users.FirstAsync(u => u.Id == id);

        if(user == null) 
            throw new ArgumentException("Não encontrei!");
        
        user.Email = request.Email;
        user.Name = request.Name;
        user.Status = request.Status;
        user.Module = request.Module;
        user.Password = request.Password;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Create(User request) {
        _context.Users.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }
};