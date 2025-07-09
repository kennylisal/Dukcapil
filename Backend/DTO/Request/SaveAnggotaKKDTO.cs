using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Request;

public class SaveAnggotaKKDTO
{
    [Required]
    public string KartuKeluargaId { get; set; }

    [Required]
    public required string Nik { get; set; }

    [Required]
    public required string Pendidikan { get; set; }

    [Required]
    public required string Jenis_pekerjaan { get; set; }

    [Required]
    public required bool Masih_anak { get; set; }

    [Required]
    public required bool Is_active { get; set; }

    [Required]
    public required string Peran { get; set; }
}
