using System;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class KtpRepos(DataContext context) : IKtpRepos
{
    private readonly DataContext _context = context;

    public async Task<bool> CreateKtp(Ktp ktp, string nik)
    {
        var cekOrang = await _context.Orang.Where(k => k.Nik == nik).FirstOrDefaultAsync();
        if (cekOrang == null)
        {
            return false;
        }

        ktp.Orang = cekOrang;
        await _context.AddAsync(ktp);
        return await Save();
    }

    public async Task<Ktp?> getKtpById(int id)
    {
        return await _context.Ktp.Where(k => k.Ktp_id == id).FirstOrDefaultAsync();
    }

    public async Task<Ktp?> getKtpByNik(string nik)
    {
        return await _context.Ktp.Where(k => k.Nik == nik).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Ktp>> GetKtps()
    {
        return await _context.Ktp.ToListAsync();
    }

    public async Task<bool> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
