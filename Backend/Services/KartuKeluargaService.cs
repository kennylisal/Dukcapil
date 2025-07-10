using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class KartuKeluargaService : IKartuKeluargaService
{
    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<KartuKeluargaService> _logger;

    private readonly IKartuKeluargaRepos _repos;

    public KartuKeluargaService(
        IOrangRepos orangRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<KartuKeluargaService> logger,
        IKartuKeluargaRepos repos
    )
    {
        _repos = repos;
        _logger = logger;
        _unitOfWork = unitOfWorks;
        _orangRepos = orangRepos;
    }

    public async Task<ControllerResponse<KartuKeluarga>> Craete(KartuKeluarga kartuKeluarga)
    {
        var kepalakeluarga = await _orangRepos.GetWithNik(kartuKeluarga.Nik_kepala_keluarga);
        if (kepalakeluarga == null)
        {
            return new ControllerResponse<KartuKeluarga>(
                "Nik kepala keluarga tidak valid / tidak ditemukan"
            );
            ;
        }
        // kartuKeluarga.Kepala_Keluarga = kepalakeluarga;
        var NoKKBaru = DataGenerator.GenerateNIK();
        kartuKeluarga.Nomor_KK = NoKKBaru;
        _repos.Create(kartuKeluarga);
        return await _unitOfWork.CompleteAsync<KartuKeluarga>(
            "Create",
            "Kartu_Keluarga",
            kartuKeluarga
        );
    }

    public async Task<QueryResults<KartuKeluarga>> GetAll(KartuKeluargaQuery query)
    {
        var res = await _repos.GetAll(query);
        return res;
    }

    public async Task<KartuKeluarga?> GetWithNoKK(string noKK)
    {
        var res = await _repos.GetWithNoKK(noKK);
        return res;
    }

    public async Task<ControllerResponse<KartuKeluarga>> Update(KartuKeluarga kartuKeluarga)
    {
        var check = await _repos.GetWithNoKK(kartuKeluarga.Nomor_KK);
        if (check == null)
        {
            return new ControllerResponse<KartuKeluarga>("Nomor Kartu Keluarga tidak valid");
        }

        _repos.Update(kartuKeluarga);
        return await _unitOfWork.CompleteAsync<KartuKeluarga>(
            "Update",
            "Kartu Keluarga",
            kartuKeluarga
        );
    }
}
