using System;
using Backend.Data;
using Backend.Domain.Repositories;
using Backend.Domain.Services.Communication;

namespace Backend.Persistence.Repositories;

public class UnitOfWorks(DataContext context, ILogger logger)
    : BaseRepository(context),
        IUnitOfWorks
{
    private readonly ILogger _logger = logger;

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<ControllerResponse<T>> CompleteAsync<T>(
        string operasi,
        string namaTabel,
        T obj
    )
    {
        if (!await CompleteAsync())
        {
            string pesan = $"Terjadi Kesalahan ketika {operasi} pada {namaTabel}";
            logger.LogWarning(pesan);
            return new ControllerResponse<T>(pesan);
        }
        else
        {
            return new ControllerResponse<T>(obj);
        }
    }
}
