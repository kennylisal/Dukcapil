using System;

namespace Backend.DTO;

public class OrangDTO
{
    public required string Nik { get; set; }

    public required string Nama { get; set; }

    public required DateOnly Tanggal_lahir { get; set; }

    public required string Tempat_lahir { get; set; }

    public required string Agama { get; set; }

    public required char Kelamin { get; set; }
}
