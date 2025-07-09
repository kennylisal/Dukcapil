using System;
using Backend.Data;
using Backend.Domain.Repositories;

namespace Backend.Persistence.Repositories;

public class UnitOfWorks(DataContext context) : BaseRepository(context), IUnitOfWorks
{
    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
