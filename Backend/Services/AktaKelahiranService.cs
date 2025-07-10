using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class AktaKelahiranService : IAktaKelahiranServices
{
    private readonly IAktaKelahiranRepos _repos;

    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<AktaKelahiranService> _logger;

    public AktaKelahiranService(
        IAktaKelahiranRepos aktaKelahiranRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<AktaKelahiranService> logger,
        IOrangRepos orangRepos
    )
    {
        _repos = aktaKelahiranRepos;
        _unitOfWork = unitOfWorks;
        _logger = logger;
        _orangRepos = orangRepos;
    }

    public async Task<ControllerResponse<AktaKelahiran>> Create(AktaKelahiran dto)
    {
        var orang = await _orangRepos.GetWithNik(dto.Nik);
        if (orang == null)
        {
            return new ControllerResponse<AktaKelahiran>("Nik orang tidak valid");
        }
        // dto.Orang = orang;

        if (dto.NikAyah != null)
        {
            var ayah = await _orangRepos.GetWithNik(dto.NikAyah);
            // dto.Ayah = ayah;
        }
        if (dto.NikIbu != null)
        {
            var ibu = await _orangRepos.GetWithNik(dto.NikIbu);
            // dto.Ibu = ibu;
        }
        _repos.Create(dto);
        return await _unitOfWork.CompleteAsync("Create", "Akta_Kelahiran", dto);
    }

    public async Task<QueryResults<AktaKelahiran>> GetAll(RequestQuery query)
    {
        var result = await _repos.GetAll(query);
        return result;
    }

    public async Task<AktaKelahiran?> GetWithNik(string Nik)
    {
        var result = await _repos.GetAktaByNik(Nik);
        return result;
    }

    public async Task<ControllerResponse<AktaKelahiran>> Update(AktaKelahiran dto)
    {
        var orang = await _orangRepos.GetWithNik(dto.Nik);
        if (orang == null)
        {
            return new ControllerResponse<AktaKelahiran>("Nik orang tidak valid");
        }
        // dto.Orang = orang;

        if (dto.NikAyah != null)
        {
            var ayah = await _orangRepos.GetWithNik(dto.NikAyah);
            // dto.Ayah = ayah;
        }
        if (dto.NikIbu != null)
        {
            var ibu = await _orangRepos.GetWithNik(dto.NikIbu);
            // dto.Ibu = ibu;
        }
        _repos.Update(dto);
        if (!await _unitOfWork.CompleteAsync())
        {
            _logger.LogError("Gagal Ketika mau update");
            return new ControllerResponse<AktaKelahiran>(
                "Terjadi Kesalahan ketika mau update Akta Kelahiran"
            );
        }
        return new ControllerResponse<AktaKelahiran>(dto);
    }
}
