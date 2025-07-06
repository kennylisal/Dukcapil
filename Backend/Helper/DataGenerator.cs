using System;
using Backend.Models;
using Bogus;

namespace Backend.Helper;

public static class DataGenerator
{
    public enum CharKelamin
    {
        P,
        L,
    }

    public static Orang CreateOrangRandom()
    {
        var seed = new Faker<Orang>("id_ID")
            .RuleFor(o => o.Nik, f => f.Random.Replace("################"))
            .RuleFor(o => o.Nama, f => f.Person.FullName)
            .RuleFor(o => o.Tanggal_lahir, f => DateOnly.FromDateTime(f.Date.Past(60)))
            .RuleFor(o => o.Tempat_lahir, f => f.Address.City())
            .RuleFor(
                o => o.Agama,
                f => f.PickRandom("Katolik", "Kristen", "Islam", "Budha", "Hindu", "Konghucu")
            )
            .RuleFor(o => o.Kelamin, f => f.PickRandom('P', 'L'))
            .RuleFor(o => o.Kewarganegaraan, Kewarganegaraan.WNI);

        return seed.Generate();
    }

    public static Orang CreateOrangSiapKawin(char g)
    {
        CharKelamin kelamin = CharKelamin.P;
        if (g == 'L')
            kelamin = CharKelamin.L;
        var seed = new Faker<Orang>("id_ID")
            .RuleFor(o => o.Nik, f => f.Random.Replace("################"))
            .RuleFor(o => o.Nama, f => f.Person.FullName)
            .RuleFor(
                o => o.Tanggal_lahir,
                f =>
                    DateOnly.FromDateTime(
                        f.Date.Between(new DateTime(1960, 01, 01), new DateTime(2000, 01, 01))
                    )
            )
            .RuleFor(o => o.Tempat_lahir, f => f.Address.City())
            .RuleFor(
                o => o.Agama,
                f => f.PickRandom("Katolik", "Kristen", "Islam", "Budha", "Hindu", "Konghucu")
            )
            .RuleFor(o => o.Kelamin, f => f.PickRandom(kelamin.ToString()[0]))
            .RuleFor(o => o.Kewarganegaraan, Kewarganegaraan.WNI);

        return seed.Generate();
    }

    public static List<Orang> CreateManySiapKawin(char g, int jumlah)
    {
        CharKelamin kelamin = CharKelamin.P;
        if (g == 'L')
            kelamin = CharKelamin.L;
        var seed = new Faker<Orang>("id_ID")
            .RuleFor(o => o.Nik, f => f.Random.Replace("################"))
            .RuleFor(o => o.Nama, f => f.Person.FullName)
            .RuleFor(
                o => o.Tanggal_lahir,
                f =>
                    DateOnly.FromDateTime(
                        f.Date.Between(new DateTime(1960, 01, 01), new DateTime(2000, 01, 01))
                    )
            )
            .RuleFor(o => o.Tempat_lahir, f => f.Address.City())
            .RuleFor(
                o => o.Agama,
                f => f.PickRandom("Katolik", "Kristen", "Islam", "Budha", "Hindu", "Konghucu")
            )
            .RuleFor(o => o.Kelamin, f => f.PickRandom(kelamin.ToString()[0]))
            .RuleFor(o => o.Kewarganegaraan, Kewarganegaraan.WNI);

        return seed.Generate(jumlah);
    }

    public static AktaKelahiran CreateAktaKelahiranBasic(Orang orang)
    {
        var seed = new Faker<AktaKelahiran>("id_ID")
            .RuleFor(ak => ak.Nik, orang.Nik)
            .RuleFor(ak => ak.NikAyah, f => null)
            .RuleFor(ak => ak.NikIbu, f => null)
            .RuleFor(ak => ak.Ayah, f => null)
            .RuleFor(ak => ak.Ibu, f => null)
            .RuleFor(ak => ak.Tanggal_penerbitan, orang.Tanggal_lahir.AddDays(1))
            .RuleFor(ak => ak.Orang, orang);
        return seed.Generate();
    }

    public static Ktp CreateKtpBasic(Orang orangPilihan)
    {
        var seed = new Faker<Ktp>("id_ID")
            .RuleFor(k => k.Nik, orangPilihan.Nik)
            .RuleFor(k => k.Orang, orangPilihan)
            .RuleFor(k => k.Alamat, f => f.Address.StreetAddress())
            .RuleFor(k => k.Sudah_Kawin, false)
            .RuleFor(k => k.Berlaku_hingga, DateOnly.FromDateTime(DateTime.Now.AddYears(100)))
            .RuleFor(k => k.Kota_pembuatan, f => f.Address.City())
            .RuleFor(k => k.Tanggal_penerbitan, DateOnly.FromDateTime(DateTime.Now));

        return seed.Generate();
    }

    public static AktaPernikahan CreateAktaPernikahanBasic(Orang suami, Orang istri)
    {
        var tanggalPilihan =
            suami.Tanggal_lahir > istri.Tanggal_lahir ? istri.Tanggal_lahir : suami.Tanggal_lahir;
        var tanggalPernikahan = tanggalPilihan.AddYears(new Random().Next(1, 11));
        var seed = new Faker<AktaPernikahan>("id_ID")
            .RuleFor(a => a.Suami, suami)
            .RuleFor(a => a.Istri, istri)
            .RuleFor(a => a.Nik_istri, istri.Nik)
            .RuleFor(a => a.Nik_suami, suami.Nik)
            .RuleFor(a => a.Agama_pernikahan, suami.Agama)
            .RuleFor(a => a.Lokasi_penerbitan, f => f.Address.City())
            .RuleFor(a => a.Tanggal_pernikahan, tanggalPernikahan)
            .RuleFor(a => a.Tanggal_penerbitan, tanggalPernikahan.AddDays(1));
        return seed.Generate();
    }

    public static KartuKeluarga CreateKartuKeluargaBasic(Orang kepala, DateOnly TglPernikahan)
    {
        var prov = new Faker().PickRandom(IndonesiaLocationData.GetProvinces());
        var seed = new Faker<KartuKeluarga>("id_ID")
            .RuleFor(k => k.Alamat, f => f.Address.FullAddress())
            .RuleFor(k => k.Kepala_Keluarga, kepala)
            .RuleFor(k => k.Nomor_KK, f => f.Random.Replace("################"))
            .RuleFor(k => k.Is_active, true)
            .RuleFor(k => k.Kode_pos, f => f.Address.ZipCode())
            .RuleFor(k => k.Provinsi, prov.nama)
            .RuleFor(k => k.Kota, f => f.PickRandom(prov.Kota))
            .RuleFor(k => k.AnggotaKartuKeluargas, [])
            .RuleFor(k => k.Nik_kepala_keluarga, kepala.Nik)
            .RuleFor(k => k.Tanggal_penerbitan, TglPernikahan.AddDays(1));
        return seed.Generate();
    }

    public static AnggotaKartuKeluarga CreateAnggotaKeluargaBasic(
        Orang orang,
        KartuKeluarga kk,
        string peran
    )
    {
        var seed = new Faker<AnggotaKartuKeluarga>("id_ID")
            .RuleFor(a => a.Orang, orang)
            .RuleFor(a => a.KartuKeluarga, kk)
            .RuleFor(a => a.KartuKeluargaId, kk.Nomor_KK)
            .RuleFor(a => a.Nik, orang.Nik)
            .RuleFor(a => a.Pendidikan, f => f.PickRandom("SMA", "SMP", "S1", "S2", "S3"))
            .RuleFor(
                a => a.Jenis_pekerjaan,
                f =>
                    f.PickRandom(
                        "Wiraswasta",
                        "PNS",
                        "Diplomat",
                        "Guru",
                        "Pegawai Swasta",
                        "Pengusaha Swasta",
                        "Creator Internet"
                    )
            )
            .RuleFor(a => a.Masih_anak, false)
            .RuleFor(a => a.Is_active, true)
            .RuleFor(a => a.Peran, peran);
        return seed.Generate();
    }
}
