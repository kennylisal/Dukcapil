using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IAktaPernikahanServices
{
    Task<QueryResults<AktaPernikahan>> GetAll();

    Task<AktaPernikahan> GetWithNik(SearchWithNIKQuery query);

    Task<ControllerResponse<AktaPernikahan>> Create(SaveAktaPernikahanDTO dto);

    Task<ControllerResponse<AktaPernikahan>> Update(UpdateAktaPernikahanDTO dto);
}
