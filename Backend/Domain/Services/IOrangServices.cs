using System;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IOrangServices
{
    Task<QueryResults<Orang>> GetAll(OrangQuery query);

    Task<Orang> GetOrang(string Nik);

    Task<ControllerResponse<Orang>> Create(Orang orang);

    Task<ControllerResponse<Orang>> Update(Orang orang);
}
