using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IKtpServices
{
    Task<QueryResults<Ktp>> GetAll();

    Task<QueryResults<Ktp>> GetKtpWithNik(SearchWithNIKQuery query);

    Task<ControllerResponse<Ktp>> Create(SaveKtpDTO dto);

    Task<ControllerResponse<Ktp>> Update(KtpDTO dto);
}
