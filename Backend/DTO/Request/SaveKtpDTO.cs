using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Request;

public record class SaveKtpDTO
{
    [Required]
    public required string Nik { get; init; }

    [Required]
    public required string Alamat { get; init; }

    [Required]
    public required bool Sudah_Kawin { get; init; }

    [Required]
    public required DateOnly Berlaku_hingga { get; init; }

    [Required]
    public required bool Is_active { get; init; }

    [Required]
    public required string Kota_pembuatan { get; init; }

    [Required]
    public required DateOnly Tanggal_penerbitan { get; init; }
}
