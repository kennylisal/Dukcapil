using System;
using Backend.Data;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class KartuKeluargaRepos(DataContext context) : IKartuKeluargaRepos
{
    private readonly DataContext _context = context;

    public Task<bool> CreateKartuKeluarga(KartuKeluarga kk, Orang kepalaKeluarga, Orang istri)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<KartuKeluarga>> CreateKartuKeluargaAutoBasic(int n)
    {
        //bikin orang berpasangan
        //bikin iterasi Kartu keluarga
        //bikin iterasi anggota -> cuman 1 lol
        List<Orang> listLaki = [];
        List<AktaKelahiran> aktaKelahirans = [];
        List<Ktp> ktps = [];
        DataGenerator dg = new();
        for (int i = 0; i < n; i++)
        {
            Orang orang = dg.CreateOrangSiapKawin('L');
            AktaKelahiran aktaKelahiran = dg.CreateAktaKelahiranBasic(orang);
            Ktp ktp = dg.CreateKtpBasic(orang);

            listLaki.Add(orang);
            aktaKelahirans.Add(aktaKelahiran);
            ktps.Add(ktp);
        }
        await _context.Orang.AddRangeAsync(listLaki);
        await _context.AktaKelahiran.AddRangeAsync(aktaKelahirans);
        await _context.Ktp.AddRangeAsync(ktps);

        List<Orang> listPerempuan = [];
        for (int i = 0; i < n; i++)
        {
            Orang orang = dg.CreateOrangSiapKawin('L');
            AktaKelahiran aktaKelahiran = dg.CreateAktaKelahiranBasic(orang);
            Ktp ktp = dg.CreateKtpBasic(orang);

            listPerempuan.Add(orang);
            aktaKelahirans.Add(aktaKelahiran);
            ktps.Add(ktp);
        }
        await _context.Orang.AddRangeAsync(listLaki);
        await _context.AktaKelahiran.AddRangeAsync(aktaKelahirans);
        await _context.Ktp.AddRangeAsync(ktps);

        List<AktaPernikahan> listAktaNikah = [];
        for (int i = 0; i < listLaki.Count; i++)
        {
            var aktaNikah = dg.CreateAktaPernikahanBasic(listLaki[i], listPerempuan[i]);
            listAktaNikah.Add(aktaNikah);
        }

        await _context.AktaPernikahans.AddRangeAsync(listAktaNikah);

        List<KartuKeluarga> listKK = [];
        for (int i = 0; i < listAktaNikah.Count; i++)
        {
            var kkBaru = dg.CreateKartuKeluargaBasic(
                listLaki[i],
                listAktaNikah[i].Tanggal_penerbitan
            );
            listKK.Add(kkBaru);
        }
        List<AnggotaKartuKeluarga> listAnggotaKK = [];
        for (int i = 0; i < listKK.Count; i++)
        {
            var anggota = dg.CreateAnggotaKeluargaBasic(listPerempuan[i], listKK[i], "Istri");
            listAnggotaKK.Add(anggota);
        }
        await _context.KartuKeluarga.AddRangeAsync(listKK);
        await _context.AnggotaKartuKeluarga.AddRangeAsync(listAnggotaKK);
        if (!await Save())
        {
            throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
        }
        return listKK;
    }

    public async Task<ICollection<KartuKeluarga>> GetAllKK()
    {
        return await _context.KartuKeluarga.ToListAsync();
    }

    public async Task<KartuKeluarga?> GetKartuKeluarga(string Nomor_KK)
    {
        return await _context
            .KartuKeluarga.Where(kk => kk.Nomor_KK == Nomor_KK)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
