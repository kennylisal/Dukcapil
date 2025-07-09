using System;
using Backend.Domain.Models.Queries;
using Backend.Models;

namespace Backend.Domain.Repositories;

public interface IAnggotaKKRepos
{
    Task<AnggotaKartuKeluarga?> GetAnggotaData(string Nik);
    void Create(AnggotaKartuKeluarga ak);

    void Delete(AnggotaKartuKeluarga ak);
}
