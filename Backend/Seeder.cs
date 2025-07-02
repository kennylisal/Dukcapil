// using System;
// using Backend.Data;
// using Backend.Models;
// using Bogus;
// using CountryData.Bogus;
// using Microsoft.EntityFrameworkCore;

// namespace Backend;

// public static class Seeder
// {
//     public static async Task SeedData(DataContext context)
//     {
//         var faker = new Bogus.DataSets.Lorem(locale: "id_ID");
//         await context.Database.EnsureCreatedAsync();

//         if (
//             !await context.Orang.AnyAsync()
//             && !await context.KartuKeluarga.AnyAsync()
//             && !await context.AnggotaKartuKeluarga.AnyAsync()
//         )
//         {
//             var faker = new Faker("id_ID");

//             var orangData = new Faker<Orang>("id_ID")
//                 .RuleFor(o => o.Nik, f => f.Random.Replace("################"))
//                 .RuleFor(o => o.Nama, f => f.Person.FullName)
//                 .RuleFor(o => o.Tanggal_lahir, f => DateOnly.FromDateTime(f.Date.Past(60)))
//                 .RuleFor(o => o.Tempat_lahir, f => f.Address.City())
//                 .RuleFor(
//                     o => o.Agama,
//                     f => f.PickRandom("Islam", "Kristen", "Katolik", "Hindu", "Buddha", "Konghucu")
//                 )
//                 .RuleFor(o => o.Kelamin, f => f.PickRandom("M", "F"))
//                 .RuleFor(o => o.Kewarganegaraan, f => f.PickRandom("WNI", "WNA"))
//                 .Generate(10);

//             await context.Orang.AddRangeAsync(orangData);
//             await context.SaveChangesAsync();

//             var kartuKeluargaData = new List<KartuKeluarga>
//             {
//                 new KartuKeluarga { Id = 1, Nik_kepala_keluarga = orangData[0].Nik },
//             };

//             await context.KartuKeluarga.AddRangeAsync(kartuKeluargaData);
//             await context.SaveChangesAsync();

//             var anggotaData = orangData
//                 .Select(o =>
//                     new Faker<AnggotaKartuKeluarga>("id_ID")
//                         .RuleFor(a => a.KartuKeluargaId, 1)
//                         .RuleFor(a => a.Nik, o.Nik)
//                         .RuleFor(
//                             a => a.Pendidikan,
//                             f => f.PickRandom("SD", "SMP", "SMA", "S1", "S2", "S3")
//                         )
//                         .RuleFor(a => a.Jenis_pekerjaan, f => f.Name.JobType())
//                         .RuleFor(a => a.Masih_anak, f => f.Random.Bool())
//                         .RuleFor(a => a.Is_active, true)
//                         .RuleFor(
//                             a => a.Peran,
//                             f => f.PickRandom("Kepala Keluarga", "Istri", "Anak", "Orang Tua")
//                         )
//                         .Generate()
//                 )
//                 .ToList();

//             await context.AnggotaKartuKeluarga.AddRangeAsync(anggotaData);
//             await context.SaveChangesAsync();
//         }
//     }
// }
