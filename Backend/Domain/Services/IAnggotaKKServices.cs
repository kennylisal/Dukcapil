using System;
using Backend.Domain.Services.Communication;
using Backend.DTO.Request;
using Backend.Models;

namespace Backend.Domain.Services;

public interface IAnggotaKKServices
{
    Task<ControllerResponse<AnggotaKartuKeluarga>> Create(SaveAnggotaKKDTO dto);

    Task<ControllerResponse<AnggotaKartuKeluarga>> Delete(DeleteRequestWithIdDTO dto);
}
