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

    Task<ICollection<Orang>> GetOrangTanpaKtp();

    // Task<bool> CreteOrangWithSpesificGender(char g);

    Task<ICollection<Orang>> GetOrangsWithSpesificGender(char g);
    Task<Orang> CreateOrangDewasa(char g);

    Task<ICollection<Orang>> CreateManyOrangDewasa(int n, char kelamin);
}
