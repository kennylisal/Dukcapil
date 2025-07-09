using System;
using Backend.Domain.Models.Queries;
using Backend.DTO;
using Backend.Models;

namespace Backend.Interfaces;

public interface IKartuKeluargaRepos
{
    Task<QueryResults<KartuKeluarga>> GetAll(KartuKeluargaQuery query);

    Task<KartuKeluarga?> GetWithNoKK(string NoKK);

    void Create(KartuKeluarga kk);

    void Update(KartuKeluarga kk);
}
