using Microsoft.EntityFrameworkCore;
using tryitter.Models;
using tryitter.Context;
using tryitter.Requesties;
using System.Threading;

namespace tryitter.Repository;

public class StudentsRepository
{
    protected readonly ITryitterContext _context;
    public StudentsRepository(ITryitterContext context)
    {
        _context = context;
    }
}