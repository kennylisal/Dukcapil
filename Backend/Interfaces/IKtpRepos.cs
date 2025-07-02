using System;
using Backend.Models;

namespace Backend.Interfaces;

public interface IKtpRepos
{
    Task<ICollection<Ktp>> GetKtps();

    Task<Ktp?> getKtpByNik(string nik);

    Task<Ktp?> getKtpById(int id);

    Task<bool> Save();

    Task<bool> CreateKtp(Ktp ktp, string nik);
}
