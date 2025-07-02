import React, { useState, useEffect } from "react";
import { Faker, en } from "@faker-js/faker";
import {
  Box,
  Paper,
  Typography,
  TextField,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button,
  Grid,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TablePagination,
  type SelectChangeEvent,
  ThemeProvider,
  Container,
} from "@mui/material";
import { LocalizationProvider, DatePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import dayjs, { Dayjs } from "dayjs";
import type { RespondDataKTP } from "../interface";
import theme from "../../global/theme";
import NavBar from "../../global/appbar";

// Initialize Faker
const faker = new Faker({ locale: [en] });

// Provided filter options
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

// Indonesian provinces for provinsiPembuatan
const indonesianProvinces = [
  "DKI Jakarta",
  "Sulawesi Selatan",
  "Jawa Timur",
  "Jawa Barat",
  "Sumatera Utara",
  "DI Yogyakarta",
  "Bali",
  "Jawa Tengah",
  "Sulawesi Utara",
  "Aceh",
  "Sulawesi Tengah",
  "Papua Barat",
  "Kepulauan Riau",
  "Banten",
  "Papua",
];

// Interface for KTP data

// Generate mock KTP data
const generateMockKtpData = (count: number): RespondDataKTP[] => {
  return Array.from({ length: count }, () => ({
    NIK: faker.string.numeric({ length: 16 }), // 16-digit NIK
    nama: faker.person.fullName(),
    kelamin: faker.helpers.arrayElement(["Laki-laki", "Perempuan"]),
    tempatLahir: faker.helpers.arrayElement(indonesianCities),
    tanggalLahir: dayjs(faker.date.past({ years: 50 })).format("DD/MM/YYYY"),
    alamat: faker.address.streetAddress(),
    agama: faker.helpers.arrayElement(agamaResmi),
    nomorKelahiran: faker.string.numeric({ length: 10 }),
    kewarganegaraan: faker.helpers.arrayElement(["WNI", "WNA"]),
    statusPerkawinan: faker.helpers.arrayElement(statusPerkawinan),
    kotaPembuatan: faker.helpers.arrayElement(indonesianCities),
    provinsiPembuatan: faker.helpers.arrayElement(indonesianProvinces),
  }));
};

const SearchKtpPage: React.FC = () => {
  // State for filters
  const [searchTerm, setSearchTerm] = useState("");
  const [cityFilter, setCityFilter] = useState("");
  const [startDate, setStartDate] = useState<Dayjs | null>(null);
  const [endDate, setEndDate] = useState<Dayjs | null>(null);
  const [marriageStatusFilter, setMarriageStatusFilter] = useState("");
  const [religionFilter, setReligionFilter] = useState("");

  // State for table data and pagination
  const [allRecords, setAllRecords] = useState<RespondDataKTP[]>([]);
  const [filteredRecords, setFilteredRecords] = useState<RespondDataKTP[]>([]);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  // Generate mock data on mount
  useEffect(() => {
    const mockData = generateMockKtpData(50); // Generate 50 records for demo
    setAllRecords(mockData);
    setFilteredRecords(mockData);
  }, []);

  // Handle filter changes
  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
    applyFilters(
      e.target.value,
      cityFilter,
      startDate,
      endDate,
      marriageStatusFilter,
      religionFilter
    );
  };

  const handleCityFilter = (e: SelectChangeEvent) => {
    const value = e.target.value as string;
    setCityFilter(value);
    applyFilters(
      searchTerm,
      value,
      startDate,
      endDate,
      marriageStatusFilter,
      religionFilter
    );
  };

  const handleStartDateChange = (newValue: Dayjs | null) => {
    setStartDate(newValue);
    applyFilters(
      searchTerm,
      cityFilter,
      newValue,
      endDate,
      marriageStatusFilter,
      religionFilter
    );
  };

  const handleEndDateChange = (newValue: Dayjs | null) => {
    setEndDate(newValue);
    applyFilters(
      searchTerm,
      cityFilter,
      startDate,
      newValue,
      marriageStatusFilter,
      religionFilter
    );
  };

  const handleMarriageStatusFilter = (e: SelectChangeEvent) => {
    const value = e.target.value as string;
    setMarriageStatusFilter(value);
    applyFilters(
      searchTerm,
      cityFilter,
      startDate,
      endDate,
      value,
      religionFilter
    );
  };

  const handleReligionFilter = (e: SelectChangeEvent) => {
    const value = e.target.value as string;
    setReligionFilter(value);
    applyFilters(
      searchTerm,
      cityFilter,
      startDate,
      endDate,
      marriageStatusFilter,
      value
    );
  };

  // Apply all filters
  const applyFilters = (
    name: string,
    city: string,
    start: Dayjs | null,
    end: Dayjs | null,
    marriage: string,
    religion: string
  ) => {
    let filtered = allRecords;

    if (name) {
      filtered = filtered.filter((record) =>
        record.nama.toLowerCase().includes(name.toLowerCase())
      );
    }

    if (city) {
      filtered = filtered.filter((record) => record.kotaPembuatan === city);
    }

    if (start) {
      filtered = filtered.filter(
        (record) =>
          dayjs(record.tanggalLahir, "DD/MM/YYYY").isAfter(start) ||
          dayjs(record.tanggalLahir, "DD/MM/YYYY").isSame(start)
      );
    }

    if (end) {
      filtered = filtered.filter(
        (record) =>
          dayjs(record.tanggalLahir, "DD/MM/YYYY").isBefore(end) ||
          dayjs(record.tanggalLahir, "DD/MM/YYYY").isSame(end)
      );
    }

    if (marriage) {
      filtered = filtered.filter(
        (record) => record.statusPerkawinan === marriage
      );
    }

    if (religion) {
      filtered = filtered.filter((record) => record.agama === religion);
    }

    setFilteredRecords(filtered);
    setPage(0); // Reset to first page on filter change
  };

  // Handle pagination
  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  // Reset filters
  const handleResetFilters = () => {
    setSearchTerm("");
    setCityFilter("");
    setStartDate(null);
    setEndDate(null);
    setMarriageStatusFilter("");
    setReligionFilter("");
    setFilteredRecords(allRecords);
    setPage(0);
  };

  return (
    <Container
      maxWidth="lg"
      sx={{
        minHeight: "100vh",
        bgcolor: "background.default",
        py: 4,
      }}
    >
      <Grid
        container
        spacing={8}
        sx={{
          mx: "auto",
          width: "95%",
        }}
      >
        {/* Filter Section */}
        <Grid size={{ xs: 12, md: 4 }}>
          <Paper
            elevation={6}
            sx={{
              width: "100%",
              p: 3,
              borderRadius: 2,
              bgcolor: "white",
              border: "1px solid",
              borderColor: "primary.main",
            }}
          >
            <Typography
              variant="h5"
              gutterBottom
              sx={{
                color: "primary.main",
                fontWeight: "bold",
                textAlign: "center",
              }}
            >
              Filter Pencarian KTP
            </Typography>
            <Grid container spacing={2}>
              <Grid size={{ xs: 12 }}>
                <TextField
                  fullWidth
                  label="Cari Nama"
                  value={searchTerm}
                  onChange={handleSearch}
                  variant="outlined"
                  sx={{
                    "& .MuiOutlinedInput-root": {
                      "&:hover fieldset": {
                        borderColor: "secondary.main",
                      },
                      "&.Mui-focused fieldset": {
                        borderColor: "primary.main",
                      },
                    },
                  }}
                />
              </Grid>
              <Grid size={{ xs: 12 }}>
                <FormControl fullWidth>
                  <InputLabel>Kota Pembuatan</InputLabel>
                  <Select
                    value={cityFilter}
                    onChange={handleCityFilter}
                    label="Kota Pembuatan"
                    sx={{
                      "&:hover .MuiOutlinedInput-notchedOutline": {
                        borderColor: "secondary.main",
                      },
                      "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                        borderColor: "primary.main",
                      },
                    }}
                  >
                    <MenuItem value="">Semua Kota</MenuItem>
                    {indonesianCities.map((city) => (
                      <MenuItem key={city} value={city}>
                        {city}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
              </Grid>
              <Grid size={{ xs: 12 }}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DatePicker
                    label="Tanggal Lahir (Dari)"
                    value={startDate}
                    onChange={handleStartDateChange}
                    sx={{
                      width: "100%",
                      "& .MuiOutlinedInput-root": {
                        "&:hover fieldset": {
                          borderColor: "secondary.main",
                        },
                        "&.Mui-focused fieldset": {
                          borderColor: "primary.main",
                        },
                      },
                    }}
                  />
                </LocalizationProvider>
              </Grid>
              <Grid size={{ xs: 12 }}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DatePicker
                    label="Tanggal Lahir (Sampai)"
                    value={endDate}
                    onChange={handleEndDateChange}
                    sx={{
                      width: "100%",
                      "& .MuiOutlinedInput-root": {
                        "&:hover fieldset": {
                          borderColor: "secondary.main",
                        },
                        "&.Mui-focused fieldset": {
                          borderColor: "primary.main",
                        },
                      },
                    }}
                  />
                </LocalizationProvider>
              </Grid>
              <Grid size={{ xs: 12 }}>
                <FormControl fullWidth>
                  <InputLabel>Status Perkawinan</InputLabel>
                  <Select
                    value={marriageStatusFilter}
                    onChange={handleMarriageStatusFilter}
                    label="Status Perkawinan"
                    sx={{
                      "&:hover .MuiOutlinedInput-notchedOutline": {
                        borderColor: "secondary.main",
                      },
                      "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                        borderColor: "primary.main",
                      },
                    }}
                  >
                    <MenuItem value="">Semua Status</MenuItem>
                    {statusPerkawinan.map((status) => (
                      <MenuItem key={status} value={status}>
                        {status}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
              </Grid>
              <Grid size={{ xs: 12 }}>
                <FormControl fullWidth>
                  <InputLabel>Agama</InputLabel>
                  <Select
                    value={religionFilter}
                    onChange={handleReligionFilter}
                    label="Agama"
                    sx={{
                      "&:hover .MuiOutlinedInput-notchedOutline": {
                        borderColor: "secondary.main",
                      },
                      "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                        borderColor: "primary.main",
                      },
                    }}
                  >
                    <MenuItem value="">Semua Agama</MenuItem>
                    {agamaResmi.map((agama) => (
                      <MenuItem key={agama} value={agama}>
                        {agama}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
              </Grid>
              <Grid size={{ xs: 12 }}>
                <Button
                  onClick={handleResetFilters}
                  variant="contained"
                  color="info"
                  fullWidth
                  sx={{
                    py: 1.5,
                    fontWeight: "bold",
                    borderRadius: 2,
                    "&:hover": {
                      bgcolor: "#FFB300",
                      transform: "scale(1.05)",
                      transition: "all 0.2s ease-in-out",
                    },
                  }}
                >
                  Reset Filter
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
        {/* Table Section */}
        <Grid size={{ xs: 12, md: 8 }}>
          <Paper
            elevation={6}
            sx={{
              width: "100%",
              p: 3,
              borderRadius: 2,
              bgcolor: "white",
              border: "1px solid",
              borderColor: "primary.main",
            }}
          >
            <Typography
              variant="h5"
              gutterBottom
              sx={{
                color: "primary.main",
                fontWeight: "bold",
                textAlign: "center",
              }}
            >
              Hasil Pencarian KTP
            </Typography>
            <TableContainer>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell sx={{ fontWeight: "bold" }}>NIK</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Nama</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Kelamin</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Tempat Lahir
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Tanggal Lahir
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Alamat</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Agama</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Nomor Kelahiran
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Kewarganegaraan
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Status Perkawinan
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Kota Pembuatan
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Provinsi Pembuatan
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {filteredRecords.length === 0 ? (
                    <TableRow>
                      <TableCell colSpan={12} align="center">
                        <Typography sx={{ color: "text.secondary" }}>
                          Tidak ada data ditemukan
                        </Typography>
                      </TableCell>
                    </TableRow>
                  ) : (
                    filteredRecords
                      .slice(
                        page * rowsPerPage,
                        page * rowsPerPage + rowsPerPage
                      )
                      .map((record) => (
                        <TableRow key={record.NIK}>
                          <TableCell>{record.NIK}</TableCell>
                          <TableCell>{record.nama}</TableCell>
                          <TableCell>{record.kelamin}</TableCell>
                          <TableCell>{record.tempatLahir}</TableCell>
                          <TableCell>{record.tanggalLahir}</TableCell>
                          <TableCell>{record.alamat}</TableCell>
                          <TableCell>{record.agama}</TableCell>
                          <TableCell>{record.nomorKelahiran || "-"}</TableCell>
                          <TableCell>{record.kewarganegaraan}</TableCell>
                          <TableCell>{record.statusPerkawinan}</TableCell>
                          <TableCell>{record.kotaPembuatan}</TableCell>
                          <TableCell>{record.provinsiPembuatan}</TableCell>
                        </TableRow>
                      ))
                  )}
                </TableBody>
              </Table>
            </TableContainer>
            <TablePagination
              rowsPerPageOptions={[5, 10, 25]}
              component="div"
              count={filteredRecords.length}
              rowsPerPage={rowsPerPage}
              page={page}
              onPageChange={handleChangePage}
              labelRowsPerPage="Baris per Halaman"
              sx={{
                "& .MuiTablePagination-select": {
                  "&:hover .MuiOutlinedInput-notchedOutline": {
                    borderColor: "secondary.main",
                  },
                  "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                    borderColor: "primary.main",
                  },
                },
              }}
            />
          </Paper>
        </Grid>
      </Grid>
    </Container>
  );
};

function KTPSearch() {
  return (
    <ThemeProvider theme={theme}>
      <NavBar />
      <SearchKtpPage />
    </ThemeProvider>
  );
}
export default KTPSearch;
