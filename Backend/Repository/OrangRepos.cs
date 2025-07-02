using System.Threading.Tasks;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class OrangRepos(DataContext context) : IOrangRepos
{
    private readonly DataContext _context = context;

    public Task<Orang> GetOrang(string nik)
    {
        return _context.Orang.Where(o => o.Nik == nik).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Orang>> GetOrangs()
    {
        return await _context.Orang.ToListAsync();
    }

    public async Task<ICollection<Orang>> GetOrangs(string name)
    {
        return await _context.Orang.Where(o => o.Nama.Contains(name)).ToListAsync();
    }

    public async Task<ICollection<Orang>> GetOrangsDiatasUmur(int umur)
    {
        return await _context
            .Orang.Where(o => (DateTime.Now.Year - o.Tanggal_lahir.Year) >= umur)
            .ToListAsync();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        //dia kembalikan berapa banyak yg ter-save sepertinya
        return saved > 0;
    }

    public async Task<bool> CreateOrang(Orang orang)
    {
        Console.WriteLine($"Adding Orang: Nik={orang.Nik}, Nama={orang.Nama}");
        await _context.AddAsync(orang);
        return await Save();
    }

    //Dibawah ini fungsi yg dipakai oleh controller diluar OrangController

    public async Task<ICollection<Orang>> GetOrangTanpaAkta()
    {
        return await _context.Orang.Where(o => o.AktaKelahiran == null).ToListAsync();
    }
}
