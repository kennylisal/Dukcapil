using System;
using Backend.Data;
using Backend.Domain.Repositories;
using Backend.Domain.Services.Communication;

namespace Backend.Persistence.Repositories;

public class UnitOfWorks(DataContext context, ILogger<UnitOfWorks> logger)
    : BaseRepository(context),
        IUnitOfWorks
{
    private readonly ILogger<UnitOfWorks> _logger = logger;

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
            _logger.LogWarning(pesan);
            return new ControllerResponse<T>(pesan);
        }
        else
        {
            return new ControllerResponse<T>(obj);
        }
    }

    public async Task<ControllerResponse<T>> CompleteTransactionAsync<T>(
        string operasi,
        string namaTabel,
        Func<Task<T>> operation
    )
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            T result = await operation();
            var saving = await CompleteAsync();
            if (saving)
            {
                await transaction.CommitAsync();
                return new ControllerResponse<T>(result);
            }
            else
            {
                string pesan = $"Terjadi Kesalahan ketika {operasi} pada {namaTabel}";
                _logger.LogWarning(pesan);
                return new ControllerResponse<T>(pesan);
            }
        }
        catch (System.Exception ex)
        {
            await transaction.RollbackAsync();
            string pesan =
                $"Terjadi Kesalahan ketika {operasi} pada {namaTabel} || error : {ex.Message}";
            _logger.LogError(ex, pesan);
            return new ControllerResponse<T>(pesan);
        }
    }
}
