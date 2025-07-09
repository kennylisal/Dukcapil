using System;
using Backend.Domain.Models.Queries;
using Backend.Models;

namespace Backend.Interfaces;

public interface IAktaKelahiranRepos
{
    Task<QueryResults<AktaKelahiran>> GetAll(RequestQuery query);

    Task<AktaKelahiran?> GetAktaByNik(string Nik);

    void Create(AktaKelahiran aktaKelahiran);

    void Update(AktaKelahiran akta);
}
