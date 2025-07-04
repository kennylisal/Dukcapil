using System;
using Backend.Data;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AktaPernikahanRepos(DataContext context) : IAktaPernikahanRepos
{
    private readonly DataContext _context = context;

    public async Task<bool> CreateAktaPernikahan(
        string Nik_suami,
        string Nik_istri,
        AktaPernikahan aktaPernikahan
    )
    {
        var suami = await _context.Orang.Where(o => o.Nik == Nik_suami).FirstOrDefaultAsync();
        if (suami == null || suami.Ktp == null)
        {
            return false;
        }
        var istri = await _context.Orang.Where(o => o.Nik == Nik_istri).FirstOrDefaultAsync();
        if (istri == null || istri.Ktp == null)
        {
            return false;
        }
        aktaPernikahan.Istri = istri;
        aktaPernikahan.Suami = suami;
        await _context.AktaPernikahans.AddAsync(aktaPernikahan);

        return await Save();
    }

    public async Task<AktaPernikahan?> GetAktaWithId(int id)
    {
        return await _context
            .AktaPernikahans.Where(ak => ak.Id_akta_pernikahan == id)
            .FirstOrDefaultAsync();
    }

    public async Task<AktaPernikahan?> GetAktaWithOneOfNik(string Nik)
    {
        return await _context
            .AktaPernikahans.Where(ak => ak.Nik_istri == Nik || ak.Nik_suami == Nik)
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<AktaPernikahan>> getAllAktaPernikahan()
    {
        return await _context.AktaPernikahans.ToListAsync();
    }

    public async Task<bool> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<ICollection<AktaPernikahan>> CreateManyAktaPernikahan(
        List<Orang> listCowok,
        List<Orang> listCewek
    )
    {
        List<AktaPernikahan> listOfAkta = [];
        DataGenerator dg = new();
        for (int i = 0; i < listCowok.Count; i++)
        {
            var akta = dg.CreateAktaPernikahanBasic(listCowok[i], listCewek[i]);
            listOfAkta.Add(akta);
        }

        await _context.AddRangeAsync(listOfAkta);
        if (!await Save())
        {
            throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
        }
        return listOfAkta;
    }
}
