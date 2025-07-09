using System;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Repositories;

public class AnggotaKKrepos(DataContext context) : BaseRepository(context), IAnggotaKKRepos
{
    public void Create(AnggotaKartuKeluarga ak)
    {
        _context.AnggotaKartuKeluarga.Add(ak);
    }

    public void Delete(AnggotaKartuKeluarga ak)
    {
        _context.AnggotaKartuKeluarga.Remove(ak);
    }

    public async Task<AnggotaKartuKeluarga?> GetAnggotaData(string Nik)
    {
        return await _context.AnggotaKartuKeluarga.FirstOrDefaultAsync(ak => ak.Nik == Nik);
    }
}
