using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Request;

public class UpdateKartuKeluargaDTO
{
    [Required]
    public required string Nomor_KK { get; set; }

    [Required]
    public required string Alamat { get; set; }

    [Required]
    public required string Provinsi { get; set; }

    [Required]
    public required string Kota { get; set; }

    [Required]
    public required string Kode_pos { get; set; }

    [Required]
    public required DateOnly Tanggal_penerbitan { get; set; }

    [Required]
    public required bool Is_active { get; set; }

    [Required]
    public required string Nik_kepala_keluarga { get; set; }
}
