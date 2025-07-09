using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
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
        try
        {
            _orangRepos.Create(orang);
            if (!await _unitOfWork.CompleteAsync())
            {
                return new ControllerResponse<Orang>("Terjadi Kesalahan ketika mau save orang");
            }
            return new ControllerResponse<Orang>(orang);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Could not save product.");
            return new ControllerResponse<Orang>($"Terjadi kesalahan Ketika Mau save {ex.Message}");
        }
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

    public async Task<ControllerResponse<Orang>> Update(Orang orang)
    {
        try
        {
            var DataExist = await _orangRepos.GetWithNik(orang.Nik);
            if (DataExist == null)
            {
                return new ControllerResponse<Orang>("Nik Orang tidak ditemukan");
            }
            _orangRepos.Update(orang);
            if (!await _unitOfWork.CompleteAsync())
            {
                return new ControllerResponse<Orang>("Terjadi Kesalahan ketika mau save orang");
            }
            return new ControllerResponse<Orang>(orang);
            //tanya soal update apakah perlu semua, termasuk akta"nya perlu ditambahkan
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Could not save product.");
            return new ControllerResponse<Orang>($"Terjadi kesalahan Ketika Mau save {ex.Message}");
        }
    }
}
