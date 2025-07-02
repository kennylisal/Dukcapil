using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public enum Kewarganegaraan
{
    WNI,WNA
}

public class Orang
{
    // required gunanya supaya pastikan tidak boleh null 
    //soalnya string tidak boleh null awalnya
    [Key]
    public required string Nik { get; set; }

    public required string Nama { get; set; }

    public required DateOnly Tanggal_lahir { get; set; }

    public required string Tempat_lahir { get; set; }

    public required string Agama { get; set; }

    public required char Kelamin { get; set; }

    [EnumDataType(typeof(Kewarganegaraan))]
    public required Kewarganegaraan Kewarganegaraan { get; set; }

    public Ktp? Ktp { get; set; }

    public AktaKelahiran? AktaKelahiran { get; set; }

    public AnggotaKartuKeluarga? AnggotaKartuKeluarga { get; set; }
    
    public KartuKeluarga? KartuKeluargaSeabagaiKepala { get; set; }
}
