using System;
using Backend.Domain.Models.Queries;
using Backend.Models;

namespace Backend.Interfaces;

public interface IKtpRepos
{
    Task<QueryResults<Ktp>> GetAll(KtpQuery query);

    Task<Ktp?> GetKtpWithNik(string nik);

    void Create(Ktp ktp);

    void Update(Ktp ktp);
}
