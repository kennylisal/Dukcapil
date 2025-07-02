import type { Dayjs } from "dayjs";
import dayjs from "dayjs";

interface FormDataKtp {
  nama: string;
  kelamin: string;
  tempatLahir: string;
  tanggalLahir: Dayjs | null;
  alamat: string;
  agama: string;
  nomorKelahiran: string | null;
  kewarganegaraan: string;
  statusPerkawinan: string;
  kotaPembuatan: string;
  provinsiPembuatan: string;
}

interface RequestDataKtp {
  nama: string;
  kelamin: string;
  tempatLahir: string;
  tanggalLahir: string;
  alamat: string;
  agama: string;
  nomorKelahiran: string | null;
  kewarganegaraan: string;
  statusPerkawinan: string;
  kotaPembuatan: string;
  provinsiPembuatan: string;
}

interface RespondDataKTP {
  NIK: string;
  nama: string;
  kelamin: string;
  tempatLahir: string;
  tanggalLahir: string;
  alamat: string;
  agama: string;
  nomorKelahiran: string | null;
  kewarganegaraan: string;
  statusPerkawinan: string;
  kotaPembuatan: string;
  provinsiPembuatan: string;
}

function formToRequestData(ktp: FormDataKtp): RequestDataKtp {
  return {
    ...ktp,
    tanggalLahir: ktp.tanggalLahir
      ? ktp.tanggalLahir.format("YYYY-MM-DD")
      : dayjs("1999-04-18").format("YYYY-MM-DD"),
  };
}

export {
  type FormDataKtp,
  type RequestDataKtp,
  type RespondDataKTP,
  formToRequestData,
};
