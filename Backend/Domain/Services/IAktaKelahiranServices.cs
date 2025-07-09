using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IAktaKelahiranServices
{
    Task<QueryResults<AktaKelahiran>> GetAll();

    Task<AktaKelahiran> GetWithNik(SearchWithNIKQuery query);

    Task<ControllerResponse<AktaKelahiran>> Create(SaveAktaKelahiranDTO dto);

    Task<ControllerResponse<AktaKelahiran>> Update(AktaKelahiranDTO dto);
}
