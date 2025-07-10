using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IAktaKelahiranServices
{
    Task<QueryResults<AktaKelahiran>> GetAll(RequestQuery query);

    Task<AktaKelahiran?> GetWithNik(string nik);

    Task<ControllerResponse<AktaKelahiran>> Create(AktaKelahiran akta);

    Task<ControllerResponse<AktaKelahiran>> Update(AktaKelahiran akta);
}
