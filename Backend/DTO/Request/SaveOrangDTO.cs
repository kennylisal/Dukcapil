using System;
using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.DTO.Request;

public class SaveOrangDTO
{
    [Required]
    public required string Nama { get; set; }

    [Required]
    public required DateOnly Tanggal_lahir { get; set; }

    [Required]
    public required string Tempat_lahir { get; set; }

    [Required]
    public required string Agama { get; set; }

    [Required]
    public required char Kelamin { get; set; }

    [Required]
    [EnumDataType(typeof(Kewarganegaraan))]
    public required Kewarganegaraan Kewarganegaraan { get; set; }
}
