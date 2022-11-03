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
}