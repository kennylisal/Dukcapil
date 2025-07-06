using System;
using Backend.DTO;
using Backend.Models;

namespace Backend.Interfaces;

public interface IKartuKeluargaRepos
{
    Task<ICollection<KartuKeluarga>> GetAllKK();

    Task<KartuKeluarga?> GetKartuKeluarga(string Nomor_KK);

    Task<bool> CreateKartuKeluarga(KartuKeluarga kk, string Nik_kepala_keluarga);

    Task<ICollection<KartuKeluarga>> CreateKartuKeluargaAutoBasic(int n);
}
