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
        CreateMap<AktaKelahiran, AktaKelahiranDTO>();
        CreateMap<Ktp, KtpDTO>();
        CreateMap<AktaPernikahan, AktaPernikahanDTO>();
        CreateMap<AnggotaKartuKeluarga, AnggotaKartuKeluargaDTO>();
        CreateMap<KartuKeluarga, KartuKeluargaDTO>();

        //DTO ke Objek
        CreateMap<OrangDTO, Orang>();
        CreateMap<AktaKelahiranDTO, AktaKelahiran>();
        CreateMap<KtpDTO, Ktp>();
        CreateMap<AktaPernikahanDTO, AktaPernikahan>();
        CreateMap<AnggotaKartuKeluargaDTO, AnggotaKartuKeluarga>();
        CreateMap<KartuKeluargaDTO, KartuKeluarga>();
    }
}
