using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO;

public class AktaKelahiranDTO
{
    [Required]
    public int AktaKelahiran_id { get; set; }

    [Required]
    public required string Nik { get; set; }

    [Required]
    public string? NikIbu { get; set; }

    [Required]
    public string? NikAyah { get; set; }

    [Required]
    public required bool Is_active { get; set; }

    [Required]
    public required DateOnly Tanggal_penerbitan { get; set; }
}
