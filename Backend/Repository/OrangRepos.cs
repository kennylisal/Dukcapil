using System.Threading.Tasks;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class OrangRepos : IOrangRepos
{
    private readonly DataContext _context;

    public OrangRepos(DataContext context)
    {
        _context = context;
    }

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
        //Change tracker
        //tracker nya itu pengarruh ke add, update, modify
        //connected vs diconnect state
        // EntityState.Added
        if (_context == null)
        {
            Console.WriteLine("DataContext is null in CreateOrang");
            return false;
        }
        if (orang == null)
        {
            Console.WriteLine("Orang parameter is null in CreateOrang");
            return false;
        }
        Console.WriteLine($"Adding Orang: Nik={orang.Nik}, Nama={orang.Nama}");
        await _context.AddAsync(orang);
        return await Save();
    }
}
