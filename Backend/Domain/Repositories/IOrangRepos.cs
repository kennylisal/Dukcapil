using System;
using Backend.Domain.Models.Queries;
using Backend.Models;

namespace Backend.Interfaces;

public interface IOrangRepos
{
    Task<QueryResults<Orang>> GetAll(OrangQuery query);

    Task<Orang?> GetWithNik(string Nik);

    void Create(Orang orang);

    void Update(Orang orang);
}
