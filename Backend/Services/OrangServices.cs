using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.DTO.Request;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class OrangService : IOrangServices
{
    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<OrangService> _logger;

    public OrangService(
        IOrangRepos orangRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<OrangService> logger
    )
    {
        _orangRepos = orangRepos;
        _unitOfWork = unitOfWorks;
        _logger = logger;
    }

    public async Task<ControllerResponse<Orang>> Create(Orang orang)
    {
        string NikBaru = DataGenerator.GenerateNIK();
        orang.Nik = NikBaru;
        _orangRepos.Create(orang);
        if (!await _unitOfWork.CompleteAsync())
        {
            return new ControllerResponse<Orang>("Terjadi Kesalahan ketika mau save orang");
        }
        return new ControllerResponse<Orang>(orang);
    }

    public async Task<QueryResults<Orang>> GetAll(OrangQuery query)
    {
        var result = await _orangRepos.GetAll(query);
        return result;
    }

    public async Task<Orang?> GetOrang(string Nik)
    {
        var result = await _orangRepos.GetWithNik(Nik);
        return result;
    }

    public async Task<ControllerResponse<Orang>> Update(string nik, Orang orang)
    {
        orang.Nik = nik;
        var DataExist = await _orangRepos.GetWithNik(nik);
        if (DataExist == null)
        {
            _logger.LogInformation("Nik orang tidak valid / tidak ditemukan");
            // _logger.LogError(ex, "Could not save product.");
            return new ControllerResponse<Orang>("Nik Orang tidak ditemukan");
        }

        _orangRepos.Update(orang);
        if (!await _unitOfWork.CompleteAsync())
        {
            return new ControllerResponse<Orang>("Terjadi Kesalahan ketika mau save orang");
        }
        return new ControllerResponse<Orang>(orang);
    }
}
