using System;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Interfaces;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class KtpRepos(DataContext context) : BaseRepository(context), IKtpRepos
{
    public void Create(Ktp ktp)
    {
        _context.Add(ktp);
    }

    public async Task<QueryResults<Ktp>> GetAll(KtpQuery query)
    {
        IQueryable<Ktp> queryable = _context.Ktp.AsNoTracking();

        if (query.Kota != null)
        {
            queryable = queryable.Where(k => k.Kota_pembuatan == query.Kota);
        }
        if (query.SudahKawin.HasValue)
        {
            queryable = queryable.Where(k => k.Sudah_Kawin == query.SudahKawin);
        }
        int totalCount = await queryable.CountAsync();

        List<Ktp> result = await queryable
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage)
            .ToListAsync();

        return new QueryResults<Ktp> { Items = result, TotalItems = totalCount };
    }

    public async Task<Ktp?> GetKtpWithNik(string nik)
    {
        return await _context.Ktp.FirstOrDefaultAsync(k => k.Nik == nik);
    }

    public void Update(Ktp ktp)
    {
        _context.Update(ktp);
    }

    // private readonly DataContext _context = context;

    // public async Task<bool> CreateKtp(Ktp ktp, string nik)
    // {
    //     var cekOrang = await _context.Orang.Where(k => k.Nik == nik).FirstOrDefaultAsync();
    //     if (cekOrang == null)
    //     {
    //         return false;
    //     }

    //     ktp.Orang = cekOrang;
    //     await _context.AddAsync(ktp);
    //     return await Save();
    // }

    // public async Task<Ktp?> getKtpById(int id)
    // {
    //     return await _context.Ktp.Where(k => k.Ktp_id == id).FirstOrDefaultAsync();
    // }

    // public async Task<Ktp?> GetKtpWithNik(string nik)
    // {
    //     return await _context.Ktp.Where(k => k.Nik == nik).FirstOrDefaultAsync();
    // }

    // public async Task<ICollection<Ktp>> GetAll()
    // {
    //     return await _context.Ktp.ToListAsync();
    // }

    // public async Task<bool> Save()
    // {
    //     var res = await _context.SaveChangesAsync();
    //     return res > 0;
    // }
}
