using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IKartuKeluargaService
{
    Task<QueryResults<KartuKeluarga>> GetAll();

    Task<KartuKeluarga> GetWithNoKK(KartuKeluargaNoQuery query);

    Task<ControllerResponse<KartuKeluarga>> Craete(SaveKartuKeluargaDTO dto);

    Task<ControllerResponse<KartuKeluarga>> Update(UpdateKartuKeluargaDTO dto);
}
