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
        CreateMap<AktaPernikahan, AktaPernikahanDTO>()
            .ForMember(dest => dest.Istri, opt => opt.MapFrom(src => src.Istri))
            .ForMember(dest => dest.Suami, opt => opt.MapFrom(src => src.Suami));
        CreateMap<AnggotaKartuKeluarga, AnggotaKartuKeluargaDTO>();
        CreateMap<KartuKeluarga, KartuKeluargaDTO>()
            // .ForMember(dest => dest., opt => opt.MapFrom(src => src.Kepala_Keluarga)) // Map Orang to OrangDTO
            .ForMember(
                dest => dest.AnggotaKartuKeluargaDTOs,
                opt => opt.MapFrom(src => src.AnggotaKartuKeluargas)
            );
        //DTO ke Objek
        CreateMap<OrangDTO, Orang>();
        CreateMap<AktaKelahiranDTO, AktaKelahiran>();
        CreateMap<KtpDTO, Ktp>();
        CreateMap<AktaPernikahanDTO, AktaPernikahan>();
        CreateMap<AnggotaKartuKeluargaDTO, AnggotaKartuKeluarga>();
        CreateMap<KartuKeluargaDTO, KartuKeluarga>();
    }
}
