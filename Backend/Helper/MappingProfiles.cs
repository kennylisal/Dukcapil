using System;
using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.DTO;
using Backend.DTO.Request;
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

        //request DTO to Model
        CreateMap<KartuKeluarga, KartuKeluargaDTO>()
            // .ForMember(dest => dest., opt => opt.MapFrom(src => src.Kepala_Keluarga)) // Map Orang to OrangDTO
            .ForMember(
                dest => dest.AnggotaKartuKeluargaDTOs,
                opt => opt.MapFrom(src => src.AnggotaKartuKeluargas)
            );
        // CreateMap<KartuKeluargaDTO, KartuKeluarga>()
        //     .ForMember(dest => dest.Kepala_Keluarga, opt => opt.Ignore())
        //     .ForMember(dest => dest.AnggotaKartuKeluargas, opt => opt.Ignore());

        CreateMap<KartuKeluargaDTO, KartuKeluarga>();

        CreateMap<SaveAktaKelahiranDTO, AktaKelahiran>();

        CreateMap<QueryResults<Orang>, QueryResults<OrangDTO>>();
        CreateMap<Orang, Orang>().ForMember(dest => dest.Nik, opt => opt.Ignore());
        //DTO ke Objek
        CreateMap<OrangDTO, Orang>();
        CreateMap<SaveOrangDTO, Orang>().ForMember(o => o.Nik, opt => opt.Ignore());
        CreateMap<AktaKelahiranDTO, AktaKelahiran>();
        CreateMap<KtpDTO, Ktp>();
        CreateMap<AktaPernikahanDTO, AktaPernikahan>();
        CreateMap<AnggotaKartuKeluargaDTO, AnggotaKartuKeluarga>();
        CreateMap<KartuKeluargaDTO, KartuKeluarga>();
    }
}
