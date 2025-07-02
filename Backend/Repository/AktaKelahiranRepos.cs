using System;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AktaKelahiranRepos(DataContext context) : IAktaKelahiranRepos
{
    private readonly DataContext _context = context;

    public async Task<bool> CreateAkta(AktaKelahiran aktaKelahiran, string? nikIbu, string? nikAyah)
    {
        var entityAyah = await _context.Orang.Where(o => o.Nik == nikAyah).FirstOrDefaultAsync();
        var entityIbu = await _context.Orang.Where(o => o.Nik == nikIbu).FirstOrDefaultAsync();
        var entityOrang = await _context
            .Orang.Where(o => o.Nik == aktaKelahiran.Nik)
            .FirstOrDefaultAsync();

        if (entityOrang == null)
        {
            Console.WriteLine("NIK tidak sesuai || tidak ada di database");
            return false;
        }
        aktaKelahiran.NikAyah = nikAyah;
        aktaKelahiran.NikIbu = nikIbu;
        aktaKelahiran.Orang = entityOrang;
        aktaKelahiran.Ayah = entityAyah;
        aktaKelahiran.Ibu = entityIbu;
        await _context.AddAsync(aktaKelahiran);
        return await Save();
    }

    public async Task<AktaKelahiran?> GetAktaById(int id)
    {
        return await _context
            .AktaKelahiran.Where(a => a.AktaKelahiran_id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<AktaKelahiran?> GetAktaByNik(string nik)
    {
        return await _context.AktaKelahiran.Where(a => a.Nik == nik).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AktaKelahiran>> GetAktas()
    {
        return await _context.AktaKelahiran.ToListAsync();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}

// using var transaction = await _context.Database.BeginTransactionAsync();
// try
// {
//     await _context.AktaKelahiran.AddAsync(aktaKelahiran);
//     await Save();
//     await transaction.CommitAsync();
//     return true;
// }
// catch
// {
//     await transaction.RollbackAsync();
//     return false;
// }
