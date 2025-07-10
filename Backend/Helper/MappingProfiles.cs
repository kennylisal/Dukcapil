using System;
using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services.Communication;
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
        CreateMap<KartuKeluarga, KartuKeluargaDTO>()
            .ForMember(
                dest => dest.AnggotaKartuKeluargas,
                opt => opt.MapFrom(src => src.AnggotaKartuKeluargas)
            );
        //request DTO to Model
        CreateMap<KartuKeluargaDTO, KartuKeluarga>()
            .ForMember(dest => dest.Kepala_Keluarga, opt => opt.Ignore())
            .ForMember(dest => dest.AnggotaKartuKeluargas, opt => opt.Ignore());

        CreateMap<SaveAktaKelahiranDTO, AktaKelahiran>()
            .ForMember(ak => ak.Ibu, opt => opt.Ignore())
            .ForMember(ak => ak.Ayah, opt => opt.Ignore())
            .ForMember(ak => ak.Orang, opt => opt.Ignore());

        CreateMap<SaveAktaPernikahanDTO, AktaPernikahanDTO>()
            .ForMember(ap => ap.Istri, opt => opt.Ignore())
            .ForMember(ap => ap.Suami, opt => opt.Ignore());

        CreateMap<SaveKtpDTO, Ktp>().ForMember(k => k.Orang, opt => opt.Ignore());
        CreateMap<SaveKartuKeluargaDTO, KartuKeluarga>()
            .ForMember(kk => kk.Kepala_Keluarga, opt => opt.Ignore());

        CreateMap<SaveAnggotaKKDTO, AnggotaKartuKeluarga>()
            .ForMember(akk => akk.Orang, opt => opt.Ignore());

        //request / response model to request DTO
        CreateMap<QueryResults<Ktp>, QueryResults<KtpDTO>>();
        CreateMap<QueryResults<Orang>, QueryResults<OrangDTO>>();
        CreateMap<QueryResults<AktaKelahiran>, QueryResults<AktaKelahiranDTO>>();
        CreateMap<Orang, Orang>().ForMember(dest => dest.Nik, opt => opt.Ignore());

        CreateMap<ControllerResponse<KartuKeluarga>, ControllerResponse<KartuKeluargaDTO>>();
        CreateMap<QueryResults<KartuKeluarga>, QueryResults<KartuKeluargaDTO>>();

        CreateMap<ControllerResponse<Orang>, ControllerResponse<OrangDTO>>();
        CreateMap<QueryResults<Orang>, QueryResults<OrangDTO>>();

        CreateMap<ControllerResponse<Ktp>, ControllerResponse<KtpDTO>>();
        CreateMap<QueryResults<Ktp>, QueryResults<KtpDTO>>();
        //DTO ke Objek
        CreateMap<OrangDTO, Orang>();

        CreateMap<SaveOrangDTO, Orang>().ForMember(o => o.Nik, opt => opt.Ignore());

        CreateMap<AktaKelahiranDTO, AktaKelahiran>()
            .ForMember(ak => ak.Ibu, opt => opt.Ignore())
            .ForMember(ak => ak.Ayah, opt => opt.Ignore())
            .ForMember(ak => ak.Orang, opt => opt.Ignore());
        CreateMap<KtpDTO, Ktp>().ForMember(k => k.Orang, o => o.Ignore());

        CreateMap<AktaPernikahanDTO, AktaPernikahan>()
            .ForMember(ap => ap.Istri, opt => opt.Ignore())
            .ForMember(ap => ap.Suami, opt => opt.Ignore());

        CreateMap<AnggotaKartuKeluargaDTO, AnggotaKartuKeluarga>()
            .ForMember(akk => akk.Orang, opt => opt.Ignore());
    }
}
