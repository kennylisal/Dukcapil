using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IKtpServices
{
    Task<QueryResults<Ktp>> GetAll(KtpQuery query);

    Task<Ktp?> GetKtpWithNik(string nik);

    Task<ControllerResponse<Ktp>> Create(Ktp ktp, string Nik);

    Task<ControllerResponse<Ktp>> Update(Ktp ktp);
}
