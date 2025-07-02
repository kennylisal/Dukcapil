using System;
using Backend.Models;

namespace Backend.Interfaces;

public interface IOrangRepos
{
    Task<ICollection<Orang>> GetOrangs();

    Task<Orang> GetOrang(string nik);

    Task<ICollection<Orang>> GetOrangs(string name);

    Task<ICollection<Orang>> GetOrangsDiatasUmur(int umur);

    Task<bool> CreateOrang(Orang orang);

    Task<bool> Save();

    //

    Task<ICollection<Orang>> GetOrangTanpaAkta();
}
