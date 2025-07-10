using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IAktaPernikahanServices
{
    Task<QueryResults<AktaPernikahan>> GetAll(RequestQuery query);

    Task<AktaPernikahan?> GetWithNik(string nik);

    Task<ControllerResponse<AktaPernikahan>> Create(AktaPernikahan aktaPernikahan);

    Task<ControllerResponse<AktaPernikahan>> Update(AktaPernikahan aktaPernikahan);
}
