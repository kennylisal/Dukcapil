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
        // var aktaPernikahan = await _dbContext.AktaPernikahans
        //     .Include(ap => ap.Suami) // Eagerly load Suami
        //     .Include(ap => ap.Istri) // Eagerly load Istri
        //     .FirstOrDefaultAsync(ap => ap.Id_akta_pernikahan == id);
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
        return await _context
            .AktaPernikahans.Include(ap => ap.Istri)
            .Include(ap => ap.Suami)
            .ToListAsync();
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
        // DataGenerator dg = new();
        for (int i = 0; i < listCowok.Count; i++)
        {
            var akta = DataGenerator.CreateAktaPernikahanBasic(listCowok[i], listCewek[i]);
            listOfAkta.Add(akta);
        }

        await _context.AddRangeAsync(listOfAkta);
        if (!await Save())
        {
            throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
        }
        return listOfAkta;
    }

    public async Task<ICollection<AktaPernikahan>?> CraeteAktaPernikahanAuto()
    {
        int n = 10;
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            List<Orang> listLaki = [];
            List<AktaKelahiran> aktaKelahirans = [];
            List<Ktp> ktps = [];
            for (int i = 0; i < n; i++)
            {
                Orang orang = DataGenerator.CreateOrangSiapKawin('L');
                AktaKelahiran aktaKelahiran = DataGenerator.CreateAktaKelahiranBasic(orang);
                Ktp ktp = DataGenerator.CreateKtpBasic(orang);

                listLaki.Add(orang);
                aktaKelahirans.Add(aktaKelahiran);
                ktps.Add(ktp);
            }
            await _context.Orang.AddRangeAsync(listLaki);

            List<Orang> listPerempuan = [];
            for (int i = 0; i < n; i++)
            {
                Orang orang = DataGenerator.CreateOrangSiapKawin('P');
                AktaKelahiran aktaKelahiran = DataGenerator.CreateAktaKelahiranBasic(orang);
                Ktp ktp = DataGenerator.CreateKtpBasic(orang);

                listPerempuan.Add(orang);
                aktaKelahirans.Add(aktaKelahiran);
                ktps.Add(ktp);
            }
            await _context.Orang.AddRangeAsync(listPerempuan);
            if (!await Save())
            {
                throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            }

            await _context.AktaKelahiran.AddRangeAsync(aktaKelahirans);
            await _context.Ktp.AddRangeAsync(ktps);
            if (!await Save())
            {
                throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            }

            List<AktaPernikahan> listAktaNikah = [];
            for (int i = 0; i < listLaki.Count; i++)
            {
                var aktaNikah = DataGenerator.CreateAktaPernikahanBasic(
                    listLaki[i],
                    listPerempuan[i]
                );
                listAktaNikah.Add(aktaNikah);
            }

            await _context.AktaPernikahans.AddRangeAsync(listAktaNikah);

            if (!await Save())
            {
                throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            }

            // List<KartuKeluarga> listKK = [];
            // for (int i = 0; i < listAktaNikah.Count; i++)
            // {
            //     var kkBaru = DataGenerator.CreateKartuKeluargaBasic(
            //         listLaki[i],
            //         listAktaNikah[i].Tanggal_penerbitan
            //     );
            //     listKK.Add(kkBaru);
            // }
            // await _context.KartuKeluarga.AddRangeAsync(listKK);
            // if (!await Save())
            // {
            //     throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            // }

            // List<AnggotaKartuKeluarga> listAnggotaKK = [];
            // for (int i = 0; i < listKK.Count; i++)
            // {
            //     var anggota = DataGenerator.CreateAnggotaKeluargaBasic(
            //         listPerempuan[i],
            //         listKK[i],
            //         "Istri"
            //     );
            //     listAnggotaKK.Add(anggota);
            // }
            // await _context.AnggotaKartuKeluarga.AddRangeAsync(listAnggotaKK);
            // if (!await Save())
            // {
            //     throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            // }
            // //
            await transaction.CommitAsync();
            return listAktaNikah;
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            return null;
        }
    }
}
