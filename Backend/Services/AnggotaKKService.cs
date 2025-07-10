using System;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.DTO.Request;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class AnggotaKKService : IAnggotaKKServices
{
    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<KartuKeluargaService> _logger;

    private readonly IAnggotaKKRepos _repos;

    private readonly IKartuKeluargaRepos _kkRepos;

    public AnggotaKKService(
        IOrangRepos orangRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<KartuKeluargaService> logger,
        IAnggotaKKRepos repos,
        IKartuKeluargaRepos kartuKeluargaRepos
    )
    {
        _repos = repos;
        _logger = logger;
        _unitOfWork = unitOfWorks;
        _orangRepos = orangRepos;
        _kkRepos = kartuKeluargaRepos;
    }

    public async Task<ControllerResponse<AnggotaKartuKeluarga>> Create(AnggotaKartuKeluarga akk)
    {
        var check = await _orangRepos.GetWithNik(akk.Nik);
        if (check == null)
        {
            return new ControllerResponse<AnggotaKartuKeluarga>(
                "NIK tidak valid / tidak ditemukan"
            );
        }
        var kk = await _kkRepos.GetWithNoKK(akk.KartuKeluargaId);
        if (kk == null)
        {
            return new ControllerResponse<AnggotaKartuKeluarga>(
                "No Kartu Keluarga tidak valid / tidak ditemukan"
            );
        }
        _repos.Create(akk);
        return await _unitOfWork.CompleteAsync<AnggotaKartuKeluarga>(
            "Create",
            "Anggota_Kartu_Keluarga",
            akk
        );
    }

    public async Task<ControllerResponse<AnggotaKartuKeluarga>> Delete(AnggotaKartuKeluarga akk)
    {
        _repos.Delete(akk);
        return await _unitOfWork.CompleteAsync<AnggotaKartuKeluarga>(
            "Delete",
            "Anggota_Kartu_Keluarga",
            akk
        );
    }
}
