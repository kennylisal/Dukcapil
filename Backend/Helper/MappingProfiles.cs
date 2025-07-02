using System;
using AutoMapper;
using Backend.DTO;
using Backend.Models;

namespace Backend.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //objek ke DTO
        CreateMap<Orang, OrangDTO>();

        //DTO ke Objek
        CreateMap<OrangDTO, Orang>();
    }
}
