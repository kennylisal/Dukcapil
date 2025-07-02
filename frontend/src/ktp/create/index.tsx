import { useState } from "react";
import {
  Paper,
  Typography,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Button,
  Grid,
  Box,
  Divider,
  type SelectChangeEvent,
  ThemeProvider,
} from "@mui/material";
import NavBar from "../../global/appbar";
import theme from "../../global/theme";
import type { Dayjs } from "dayjs";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import dayjs from "dayjs";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { generateKTPData } from "./services";
import type { FormDataKtp } from "../interface";

const dataAwal: FormDataKtp = {
  nama: "",
  kelamin: "",
  tempatLahir: "",
  tanggalLahir: null,
  alamat: "",
  agama: "",
  nomorKelahiran: "",
  kewarganegaraan: "",
  statusPerkawinan: "",
  kotaPembuatan: "",
  provinsiPembuatan: "",
};

const HalamanCreateKTP: React.FC = () => {
  const [formData, setFormData] = useState<FormDataKtp>(dataAwal);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleGantiTanggal = (tanggalBaru: Dayjs | null) => {
    setFormData({ ...formData, tanggalLahir: tanggalBaru });
  };

  const handleSelectChange = (event: SelectChangeEvent) => {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value as string,
    });
  };

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    console.log("Form submitted:", formData);
    cleanData();
  };

  const generateData = () => {
    const res = generateKTPData("Makassar", "Sulawesi Selatan");
    setFormData(res);
    console.log(res);
  };

  const cleanData = () => {
    setFormData(dataAwal);
  };

  return (
    <Box
      sx={{
        minHeight: "100vh",
        bgcolor: "background.default",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        py: 4,
      }}
    >
      <Paper
        elevation={6}
        sx={{
          maxWidth: 600,
          width: "100%",
          p: 4,
          borderRadius: 2,
          bgcolor: "white",
          border: "1px solid",
          borderColor: "primary.main",
        }}
      >
        <Typography
          variant="h4"
          gutterBottom
          sx={{
            color: "primary.main",
            fontWeight: "bold",
            textAlign: "center",
          }}
        >
          Pembuatan KTP
        </Typography>
        <Typography
          variant="body1"
          sx={{ color: "text.secondary", mb: 3, textAlign: "center" }}
        >
          Masukkan Data Individu Untuk Pembuatan KTP
        </Typography>
        <form onSubmit={handleSubmit}>
          <Grid container spacing={2}>
            <Grid size={{ xs: 12 }}>
              <TextField
                fullWidth
                name="nama"
                label="Nama Lengkap"
                value={formData.nama}
                onChange={handleInputChange}
                required
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
            <Grid size={{ xs: 12, sm: 6 }}>
              <FormControl fullWidth required>
                <InputLabel>Kelamin</InputLabel>
                <Select
                  name="kelamin"
                  value={formData.kelamin}
                  onChange={handleSelectChange}
                  label="Gender"
                  sx={{
                    "&:hover .MuiOutlinedInput-notchedOutline": {
                      borderColor: "secondary.main",
                    },
                    "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                      borderColor: "primary.main",
                    },
                  }}
                >
                  <MenuItem value="Laki-laki">Laki-laki</MenuItem>
                  <MenuItem value="Perempuan">Perempuan</MenuItem>
                </Select>
              </FormControl>
            </Grid>
            <Grid size={{ xs: 12, sm: 6 }}>
              <FormControl fullWidth required>
                <InputLabel>Nationality</InputLabel>
                <Select
                  name="kewarganegaraan"
                  value={formData.kewarganegaraan}
                  onChange={handleSelectChange}
                  label="Nationality"
                  sx={{
                    "&:hover .MuiOutlinedInput-notchedOutline": {
                      borderColor: "secondary.main",
                    },
                    "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                      borderColor: "primary.main",
                    },
                  }}
                >
                  <MenuItem value="WNI">WNI</MenuItem>
                  <MenuItem value="WNA">WNA</MenuItem>
                </Select>
              </FormControl>
            </Grid>
            <Grid size={{ xs: 12 }}>
              <TextField
                fullWidth
                name="alamat"
                label="alamat"
                value={formData.alamat}
                onChange={handleInputChange}
                required
                multiline
                rows={3}
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
            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField
                name="tempatLahir"
                fullWidth
                label="Tempat lahir"
                value={formData.tempatLahir}
                onChange={handleInputChange}
                required
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
            <Grid size={{ xs: 12, sm: 6 }}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DatePicker
                  label="Tanggal lahir"
                  name="tanggalLahir"
                  value={formData.tanggalLahir ?? dayjs("2000-01-01")}
                  defaultValue={dayjs("2000-01-01")}
                  onChange={(newValue) => {
                    handleGantiTanggal(newValue);
                  }}
                />
              </LocalizationProvider>
            </Grid>
            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField
                fullWidth
                label="Status perkawinan"
                value={formData.statusPerkawinan}
                onChange={handleInputChange}
                required
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
            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField
                name="agama"
                fullWidth
                label="Agama"
                value={formData.agama}
                onChange={handleInputChange}
                type="tel"
                required
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
              <TextField
                fullWidth
                name="nomorKelahiran"
                label="Nomor Akta Kelahiran"
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
              <Divider sx={{ my: 2 }} />

              <Box
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  alignItems: "center",
                }}
              >
                <Box sx={{ flex: 1 }} />

                <Button
                  type="submit"
                  variant="contained"
                  color="secondary"
                  size="large"
                  sx={{
                    px: 4,
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
                  Submit
                </Button>

                <Box
                  sx={{ flex: 1, display: "flex", justifyContent: "flex-end" }}
                >
                  <Button
                    onClick={generateData}
                    variant="contained"
                    color="info"
                    size="large"
                    sx={{
                      px: 4,
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
                    Generate
                  </Button>
                </Box>
              </Box>
            </Grid>
          </Grid>
        </form>
      </Paper>
    </Box>
  );
};

function KTPCreate() {
  return (
    <ThemeProvider theme={theme}>
      <NavBar />
      <HalamanCreateKTP />
    </ThemeProvider>
  );
}

export default KTPCreate;
