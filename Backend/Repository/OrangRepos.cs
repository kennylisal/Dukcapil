using System.Threading.Tasks;
using Backend.Data;
using Backend.Helper;
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
        // Console.WriteLine($"Adding Orang: Nik={orang.Nik}, Nama={orang.Nama}");
        await _context.AddAsync(orang);
        return await Save();
    }

    //Dibawah ini fungsi yg dipakai oleh controller diluar OrangController

    public async Task<ICollection<Orang>> GetOrangTanpaAkta()
    {
        return await _context.Orang.Where(o => o.AktaKelahiran == null).ToListAsync();
    }

    public async Task<ICollection<Orang>> GetOrangTanpaKtp()
    {
        return await _context.Orang.Where(o => o.Ktp == null).ToListAsync();
    }

    public async Task<ICollection<Orang>> GetOrangsWithSpesificGender(char g)
    {
        return await _context.Orang.Where(o => o.Kelamin == g).ToListAsync();
    }

    //ini yang bikin Orang + akta_kelahiran + Ktp
    public async Task<Orang> CreateOrangDewasa(char g)
    {
        Orang orang = DataGenerator.CreateOrangSiapKawin(g);
        AktaKelahiran aktaKelahiran = DataGenerator.CreateAktaKelahiranBasic(orang);
        Ktp ktp = DataGenerator.CreateKtpBasic(orang);
        await _context.Orang.AddAsync(orang);
        await _context.AktaKelahiran.AddAsync(aktaKelahiran);
        await _context.Ktp.AddAsync(ktp);

        if (!await Save())
        {
            throw new Exception("Terjadi kesalahan ketika bikin dummy orang dewasa");
        }
        return orang;
    }

    public async Task<ICollection<Orang>> CreateManyOrangDewasa(int n, char kelamin)
    {
        List<Orang> orangs = [];
        List<AktaKelahiran> aktaKelahirans = [];
        List<Ktp> ktps = [];
        for (int i = 0; i < n; i++)
        {
            Orang orang = DataGenerator.CreateOrangSiapKawin(kelamin);
            AktaKelahiran aktaKelahiran = DataGenerator.CreateAktaKelahiranBasic(orang);
            Ktp ktp = DataGenerator.CreateKtpBasic(orang);

            orangs.Add(orang);
            aktaKelahirans.Add(aktaKelahiran);
            ktps.Add(ktp);
        }
        await _context.Orang.AddRangeAsync(orangs);
        await _context.AktaKelahiran.AddRangeAsync(aktaKelahirans);
        await _context.Ktp.AddRangeAsync(ktps);
        if (!await Save())
        {
            throw new Exception("Terjadi kesalahan ketika bikin dummy orang dewasa");
        }
        return orangs;
    }
}
