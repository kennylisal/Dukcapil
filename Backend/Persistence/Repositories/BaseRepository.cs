using System;
using Backend.Data;

namespace Backend.Persistence.Repositories;

public abstract class BaseRepository
{
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }
}
