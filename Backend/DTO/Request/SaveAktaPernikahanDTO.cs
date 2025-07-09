using System.ComponentModel.DataAnnotations;

namespace Backend.DTO;

public record class SaveAktaPernikahanDTO
{
    [Required]
    public required string Nik_suami { get; init; }

    [Required]
    public required string Nik_istri { get; init; }

    [Required]
    public required DateOnly Tanggal_pernikahan { get; init; }

    [Required]
    public required DateOnly Tanggal_penerbitan { get; init; }

    [Required]
    public required string Agama_pernikahan { get; init; }

    [Required]
    public required bool Is_active { get; init; }
}
