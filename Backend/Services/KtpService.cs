using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class KtpService : IKtpServices
{
    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<KtpService> _logger;

    private readonly IKtpRepos _repos;

    public KtpService(
        IOrangRepos orangRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<KtpService> logger,
        IKtpRepos ktpRepos
    )
    {
        _repos = ktpRepos;
        _orangRepos = orangRepos;
        _unitOfWork = unitOfWorks;
        _logger = logger;
    }

    public async Task<ControllerResponse<Ktp>> Create(Ktp ktp, string Nik)
    {
        var orang = await _orangRepos.GetWithNik(Nik);
        if (orang == null)
        {
            _logger.LogInformation($"Orang dengan Nik {Nik} tidak ditemukan");
            return new ControllerResponse<Ktp>("Nik Orang tidakditemukan");
        }
        ktp.Nik = Nik;
        ktp.Orang = orang;

        _repos.Create(ktp);
        if (!await _unitOfWork.CompleteAsync())
        {
            _logger.LogWarning("Gagal Ketikamau Save Ktp");
            return new ControllerResponse<Ktp>("Gagal Ketika mau save");
        }
        return new ControllerResponse<Ktp>(ktp);
    }

    public Task<QueryResults<Ktp>> GetAll(KtpQuery query)
    {
        var result = _repos.GetAll(query);
        return result;
    }

    public async Task<Ktp?> GetKtpWithNik(string nik)
    {
        var res = await _repos.GetKtpWithNik(nik);
        return res;
    }

    public async Task<ControllerResponse<Ktp>> Update(Ktp ktp)
    {
        var check = await _repos.GetKtpWithNik(ktp.Nik);
        if (check == null)
        {
            _logger.LogInformation($"Ktp dengan Nik {ktp.Nik} tidak ditemukan");
            return new ControllerResponse<Ktp>("Ktp tidakditemukan");
        }
        _repos.Update(ktp);
        return await _unitOfWork.CompleteAsync<Ktp>("Update", "KTP", ktp);
    }
}
