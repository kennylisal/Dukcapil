using System;
using Backend.Models;

namespace Backend.Interfaces;

public interface IAktaKelahiranRepos
{
    Task<ICollection<AktaKelahiran>> GetAktas();

    Task<AktaKelahiran?> GetAktaById(int id);

    Task<AktaKelahiran?> GetAktaByNik(string nik);

    Task<bool> CreateAkta(AktaKelahiran aktaKelahiran, string nikIbu, string nikAyah);

    Task<bool> Save();
}
