using System;
using Backend.Models;

namespace Backend.Interfaces;

public interface IAktaPernikahanRepos
{
    Task<ICollection<AktaPernikahan>> getAllAktaPernikahan();

    Task<bool> CreateAktaPernikahan(
        string Nik_suami,
        string Nik_istri,
        AktaPernikahan aktaPernikahan
    );

    Task<AktaPernikahan?> GetAktaWithId(int id);

    Task<AktaPernikahan?> GetAktaWithOneOfNik(string Nik);

    Task<bool> Save();
    Task<ICollection<AktaPernikahan>> CreateManyAktaPernikahan(
        List<Orang> listCowok,
        List<Orang> listCewek
    );
}
