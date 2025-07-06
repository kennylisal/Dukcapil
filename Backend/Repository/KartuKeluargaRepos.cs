using System;
using System.Diagnostics;
using Backend.Data;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class KartuKeluargaRepos(DataContext context) : IKartuKeluargaRepos
{
    private readonly DataContext _context = context;

    public async Task<bool> CreateKartuKeluarga(KartuKeluarga kk, string Nik_kepala_keluarga)
    {
        var kepala_keluarga =
            await _context.Orang.Where(o => o.Nik == Nik_kepala_keluarga).FirstOrDefaultAsync()
            ?? throw new Exception("Nik Kepala keluarga tidak ditemukan");
        kk.Nik_kepala_keluarga = kepala_keluarga.Nik;
        kk.Kepala_Keluarga = kepala_keluarga;
        await _context.KartuKeluarga.AddAsync(kk);
        return await Save();
    }

    public async Task<ICollection<KartuKeluarga>> CreateKartuKeluargaAutoBasic(int n)
    {
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

            List<KartuKeluarga> listKK = [];
            for (int i = 0; i < listAktaNikah.Count; i++)
            {
                var kkBaru = DataGenerator.CreateKartuKeluargaBasic(
                    listLaki[i],
                    listAktaNikah[i].Tanggal_penerbitan
                );
                listKK.Add(kkBaru);
            }
            await _context.KartuKeluarga.AddRangeAsync(listKK);
            if (!await Save())
            {
                throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            }

            List<AnggotaKartuKeluarga> listAnggotaKK = [];
            for (int i = 0; i < listKK.Count; i++)
            {
                var anggotaistri = DataGenerator.CreateAnggotaKeluargaBasic(
                    listPerempuan[i],
                    listKK[i],
                    "Istri"
                );
                var anggotaSuami = DataGenerator.CreateAnggotaKeluargaBasic(
                    listLaki[i],
                    listKK[i],
                    "Suami"
                );
                listAnggotaKK.Add(anggotaistri);
                listAnggotaKK.Add(anggotaSuami);
            }
            await _context.AnggotaKartuKeluarga.AddRangeAsync(listAnggotaKK);
            if (!await Save())
            {
                throw new Exception("Terjadi kesalahan pas auto Akta - Pernikahan massal");
            }
            //
            await transaction.CommitAsync();
            return listKK;
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            return null;
        }
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
