using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IKartuKeluargaService
{
    Task<QueryResults<KartuKeluarga>> GetAll(KartuKeluargaQuery query);

    Task<KartuKeluarga?> GetWithNoKK(string noKK);

    Task<ControllerResponse<KartuKeluarga>> Craete(KartuKeluarga kartuKeluarga);

    Task<ControllerResponse<KartuKeluarga>> Update(KartuKeluarga kartuKeluarga);
}
