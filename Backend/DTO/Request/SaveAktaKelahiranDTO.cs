using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Request;

public record class SaveAktaKelahiranDTO
{
    [Required]
    [MinLength(10)]
    [MaxLength(20)]
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
