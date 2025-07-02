import { fakerID_ID as faker } from "@faker-js/faker";
import dayjs from "dayjs";
import type { FormDataKtp, RespondDataKTP } from "../interface";

const indonesianCities = [
  "Jakarta",
  "Makassar",
  "Surabaya",
  "Bandung",
  "Medan",
  "Yogyakarta",
  "Denpasar",
  "Semarang",
  "Manado",
  "Cianjur",
  "Bulukumba",
  "Sinjai",
  "Aceh",
  "Palu",
  "Sorong",
  "Batam",
  "Banten",
  "Sabang",
  "Merauke",
  "Sidoarjo",
  "Malang",
  "Palopo",
  "Toraja",
  "Gowa",
];

const agamaResmi = [
  "Katolik",
  "Kristen",
  "Islam",
  "Budha",
  "Hindu",
  "Konghucu",
];

const statusPerkawinan = ["Sudah Kawin", "Belum Kawin", "Cerai"];

function generateKTPData(
  kotaPembuatan: string,
  provinsiPembuatan: string
): FormDataKtp {
  const kelamin =
    faker.helpers.rangeToNumber({ min: 0, max: 1 }) === 0 ? "male" : "female";
  const person: FormDataKtp = {
    provinsiPembuatan: provinsiPembuatan,
    kotaPembuatan: kotaPembuatan,
    nama: faker.person.fullName({ sex: kelamin }),
    kelamin: kelamin === "male" ? "Laki-laki" : "Perempuan",
    tempatLahir:
      indonesianCities[
        faker.helpers.rangeToNumber({
          min: 0,
          max: indonesianCities.length,
        })
      ],
    tanggalLahir: dayjs(
      faker.date
        .betweens({
          from: "1950-01-01",
          to: "2006-12-30",
          count: 1,
        })[0]
        .toISOString()
    ),
    alamat: `JL. ${faker.location.street()} No.${faker.helpers.rangeToNumber({
      min: 1,
      max: 100,
    })}`,
    agama:
      agamaResmi[
        faker.helpers.rangeToNumber({ min: 0, max: agamaResmi.length })
      ],
    nomorKelahiran: null,
    kewarganegaraan: "WNI",
    statusPerkawinan:
      statusPerkawinan[faker.helpers.rangeToNumber({ min: 0, max: 1 })],
  };
  return person;
}

function generateUpdateData(
  kotaPembuatan: string,
  provinsiPembuatan: string
): RespondDataKTP {
  const kelamin =
    faker.helpers.rangeToNumber({ min: 0, max: 1 }) === 0 ? "male" : "female";
  const person: RespondDataKTP = {
    provinsiPembuatan: provinsiPembuatan,
    kotaPembuatan: kotaPembuatan,
    nama: faker.person.fullName({ sex: kelamin }),
    kelamin: kelamin === "male" ? "Laki-laki" : "Perempuan",
    tempatLahir:
      indonesianCities[
        faker.helpers.rangeToNumber({
          min: 0,
          max: indonesianCities.length,
        })
      ],
    tanggalLahir: faker.date
      .betweens({
        from: "1950-01-01",
        to: "2006-12-30",
        count: 1,
      })[0]
      .toISOString(),
    NIK: faker.string.uuid(),
    alamat: `JL. ${faker.location.street()} No.${faker.helpers.rangeToNumber({
      min: 1,
      max: 100,
    })}`,
    agama:
      agamaResmi[
        faker.helpers.rangeToNumber({ min: 0, max: agamaResmi.length })
      ],
    nomorKelahiran: null,
    kewarganegaraan: "WNI",
    statusPerkawinan:
      statusPerkawinan[faker.helpers.rangeToNumber({ min: 0, max: 1 })],
  };
  return person;
}

export { generateKTPData, generateUpdateData };
