using System;
using Backend.Models;

namespace Backend.Interfaces;

public interface IKartuKeluargaRepos
{
    Task<ICollection<KartuKeluarga>> GetAllKK();

    Task<KartuKeluarga?> GetKartuKeluarga(string Nomor_KK);

    Task<bool> CreateKartuKeluarga(KartuKeluarga kk, Orang kepalaKeluarga, Orang istri);

    Task<ICollection<KartuKeluarga>> CreateKartuKeluargaAutoBasic(int n);
}
