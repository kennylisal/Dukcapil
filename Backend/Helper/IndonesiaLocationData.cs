using System.Collections.Generic;

public class Provinsi
{
    public string nama { get; set; }
    public string[] Kota { get; set; }

    public Provinsi(string nama, string[] listKota)
    {
        this.nama = nama;
        this.Kota = listKota;
    }
}

public static class IndonesiaLocationData
{
    public static List<Provinsi> GetProvinces()
    {
        return new List<Provinsi>
        {
            new Provinsi(
                "Aceh",
                new[]
                {
                    "Banda Aceh",
                    "Lhokseumawe",
                    "Langsa",
                    "Sabang",
                    "Meulaboh",
                    "Bireuen",
                    "Takengon",
                    "Sigli",
                }
            ),
            new Provinsi(
                "Sumatera Utara",
                new[]
                {
                    "Medan",
                    "Pematangsiantar",
                    "Binjai",
                    "Tebing Tinggi",
                    "Tanjungbalai",
                    "Sibolga",
                    "Deli Serdang",
                    "Karo",
                    "Asahan",
                }
            ),
            new Provinsi(
                "Jawa Barat",
                new[]
                {
                    "Bandung",
                    "Bogor",
                    "Bekasi",
                    "Depok",
                    "Sukabumi",
                    "Cimahi",
                    "Tasikmalaya",
                    "Cirebon",
                    "Garut",
                    "Purwakarta",
                }
            ),
            new Provinsi(
                "Jawa Tengah",
                new[]
                {
                    "Semarang",
                    "Surakarta",
                    "Tegal",
                    "Pekalongan",
                    "Magelang",
                    "Salatiga",
                    "Purwokerto",
                    "Kudus",
                    "Demak",
                    "Pati",
                }
            ),
            new Provinsi(
                "Jawa Timur",
                new[]
                {
                    "Surabaya",
                    "Malang",
                    "Kediri",
                    "Blitar",
                    "Mojokerto",
                    "Probolinggo",
                    "Pasuruan",
                    "Banyuwangi",
                    "Jember",
                    "Sidoarjo",
                }
            ),
            new Provinsi(
                "Banten",
                new[]
                {
                    "Serang",
                    "Tangerang",
                    "Cilegon",
                    "South Tangerang",
                    "Pandeglang",
                    "Lebak",
                    "Rangkasbitung",
                }
            ),
            new Provinsi(
                "Bali",
                new[]
                {
                    "Denpasar",
                    "Singaraja",
                    "Tabanan",
                    "Gianyar",
                    "Badung",
                    "Bangli",
                    "Klungkung",
                    "Karangasem",
                }
            ),
            new Provinsi(
                "Sulawesi Selatan",
                new[]
                {
                    "Makassar",
                    "Parepare",
                    "Palopo",
                    "Gowa",
                    "Bone",
                    "Maros",
                    "Jeneponto",
                    "Takalar",
                }
            ),
            new Provinsi(
                "Kalimantan Timur",
                new[]
                {
                    "Samarinda",
                    "Balikpapan",
                    "Bontang",
                    "Tarakan",
                    "Kutai Kartanegara",
                    "Penajam Paser Utara",
                    "Berau",
                }
            ),
            new Provinsi(
                "Papua",
                new[]
                {
                    "Jayapura",
                    "Merauke",
                    "Sorong",
                    "Manokwari",
                    "Biak",
                    "Timika",
                    "Nabire",
                    "Wamena",
                }
            ),
        };
    }
}
