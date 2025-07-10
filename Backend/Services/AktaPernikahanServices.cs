using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class AktaPernikahanServices : IAktaPernikahanServices
{
    private readonly IAktaPernikahanRepos _repos;

    private readonly IOrangRepos _orangRepos;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly ILogger<AktaKelahiranService> _logger;

    public AktaPernikahanServices(
        IAktaPernikahanRepos repos,
        IOrangRepos orangRepos,
        IUnitOfWorks unitOfWorks,
        ILogger<AktaKelahiranService> logger
    )
    {
        _repos = repos;
        _orangRepos = orangRepos;
        _unitOfWork = unitOfWorks;
        _logger = logger;
    }

    public async Task<ControllerResponse<AktaPernikahan>> Create(AktaPernikahan aktaPernikahan)
    {
        var suami = await _orangRepos.GetWithNik(aktaPernikahan.Nik_suami);
        if (suami == null)
        {
            return new ControllerResponse<AktaPernikahan>("Nik orang suami tidak ditemukan");
        }

        var istri = await _orangRepos.GetWithNik(aktaPernikahan.Nik_istri);
        if (istri == null)
        {
            return new ControllerResponse<AktaPernikahan>("Nik istri tidak ditemukan");
        }
        // aktaPernikahan.Istri = istri;
        // aktaPernikahan.Suami = suami;
        _repos.Create(aktaPernikahan);
        return await _unitOfWork.CompleteAsync("Create", "Akta_Pernikahan", aktaPernikahan);
    }

    public async Task<QueryResults<AktaPernikahan>> GetAll(RequestQuery query)
    {
        var res = await _repos.GetAll(query);
        return res;
    }

    public async Task<AktaPernikahan?> GetWithNik(string nik)
    {
        var res = await _repos.GetAktaWithOneOfNik(nik);
        return res;
    }

    public async Task<ControllerResponse<AktaPernikahan>> Update(AktaPernikahan aktaPernikahan)
    {
        var suami = await _orangRepos.GetWithNik(aktaPernikahan.Nik_suami);
        if (suami == null)
        {
            return new ControllerResponse<AktaPernikahan>("Nik orang suami tidak ditemukan");
        }

        var istri = await _orangRepos.GetWithNik(aktaPernikahan.Nik_istri);
        if (istri == null)
        {
            return new ControllerResponse<AktaPernikahan>("Nik istri tidak ditemukan");
        }
        // aktaPernikahan.Istri = istri;
        // aktaPernikahan.Suami = suami;
        _repos.Update(aktaPernikahan);

        return await _unitOfWork.CompleteAsync("Update", "Akta_pernikahan", aktaPernikahan);
    }
}
