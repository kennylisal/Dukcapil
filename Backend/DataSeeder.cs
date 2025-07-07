using System;
using Backend.Data;
using Backend.Helper;
using Backend.Models;

namespace Backend;

public class DataSeeder(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task SeedDatabase(int n)
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
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
