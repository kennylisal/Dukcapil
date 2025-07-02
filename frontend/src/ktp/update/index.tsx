import { useEffect, useState } from "react";
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
  List,
  ListItemButton,
  ListItem,
  ListItemText,
} from "@mui/material";
import NavBar from "../../global/appbar";
import theme from "../../global/theme";
import type { Dayjs } from "dayjs";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import dayjs from "dayjs";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import type { RespondDataKTP } from "../interface";
import { generateUpdateData } from "../create/services";

const HalamanUpdateKTP = () => {
  const dataAwal: RespondDataKTP = {
    nama: "",
    kelamin: "",
    tempatLahir: "",
    tanggalLahir: "",
    alamat: "",
    agama: "",
    nomorKelahiran: "",
    kewarganegaraan: "",
    statusPerkawinan: "",
    kotaPembuatan: "",
    provinsiPembuatan: "",
    NIK: "",
  };
  const [formData, setFormData] = useState<RespondDataKTP>(dataAwal);
  const [searchTerm, setSearchTerm] = useState("");
  const [allRecords, setAllRecords] = useState<RespondDataKTP[]>([]);
  const [searchResults, setSearchResults] = useState<RespondDataKTP[]>([]);

  useEffect(() => {
    const temp: RespondDataKTP[] = [];
    for (let index = 0; index < 10; index++) {
      temp.push(generateUpdateData("Makassar", "Sulawesi Selatan"));
    }
    setAllRecords(temp);
  }, []);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleGantiTanggal = (tanggalBaru: Dayjs | null) => {
    setFormData({
      ...formData,
      tanggalLahir: tanggalBaru ? tanggalBaru?.format("YYYY-MM-DD") : "",
    });
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

  const cleanData = () => {
    setFormData(dataAwal);
  };

  // Handle search
  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    const term = e.target.value.toLowerCase();
    setSearchTerm(term);
    const filtered = allRecords
      .filter((record) => record.nama.toLowerCase().includes(term))
      .slice(0, 5); // Limit to 5 results
    setSearchResults(filtered);
  };
  const handleSelectResult = (pilihan: RespondDataKTP) => {
    setFormData(pilihan);
  };

  return (
    <Box
      sx={{
        minHeight: "100vh",
        bgcolor: "background.default",
        display: "flex",
        justifyContent: "center",
        alignItems: "flex-start",
        py: 4,
      }}
    >
      <Grid
        container
        spacing={10}
        sx={{
          maxWidth: 1200,
          mx: "auto",
          width: "100%",
        }}
      >
        {/* Form Section */}
        <Grid size={{ xs: 12, md: 8 }}>
          <Paper
            elevation={6}
            sx={{
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
              Update KTP
            </Typography>
            <Typography
              variant="body1"
              sx={{ color: "text.secondary", mb: 3, textAlign: "center" }}
            >
              Cari dan Perbarui Data Individu untuk KTP
            </Typography>
            <Box component="div">
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
                      label="Kelamin"
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
                    <InputLabel>Kewarganegaraan</InputLabel>
                    <Select
                      name="kewarganegaraan"
                      value={formData.kewarganegaraan}
                      onChange={handleSelectChange}
                      label="Kewarganegaraan"
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
                    label="Alamat"
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
                    label="Tempat Lahir"
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
                      label="Tanggal Lahir"
                      name="tanggalLahir"
                      value={
                        formData.tanggalLahir === ""
                          ? dayjs("2000-01-01")
                          : dayjs(formData.tanggalLahir)
                      }
                      onChange={handleGantiTanggal}
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
                <Grid size={{ xs: 12, sm: 6 }}>
                  <TextField
                    fullWidth
                    name="statusPerkawinan"
                    label="Status Perkawinan"
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
                    value={formData.nomorKelahiran}
                    onChange={handleInputChange}
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
                      onClick={handleSubmit}
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
                      Update
                    </Button>
                  </Box>
                </Grid>
              </Grid>
            </Box>
          </Paper>
        </Grid>
        {/* Search Section */}
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
              minHeight: "400px", // Ensure sufficient height
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
              Cari Data KTP
            </Typography>
            <TextField
              fullWidth
              label="Cari Nama"
              value={searchTerm}
              onChange={handleSearch}
              variant="outlined"
              sx={{
                mb: 2,
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
            <List>
              {searchResults.length === 0 ? (
                <Typography
                  sx={{ textAlign: "center", color: "text.secondary" }}
                >
                  Tidak ada hasil ditemukan
                </Typography>
              ) : (
                searchResults.map((record) => (
                  <ListItem key={record.NIK} disablePadding>
                    <ListItemButton onClick={() => handleSelectResult(record)}>
                      <ListItemText
                        primary={record.nama}
                        secondary={
                          <>
                            Tanggal Lahir:
                            {record.tanggalLahir.substring(0, 10)}
                            <br />
                            Kota Tinggal: {record.kotaPembuatan}
                          </>
                        }
                      />
                    </ListItemButton>
                  </ListItem>
                ))
              )}
            </List>
          </Paper>
        </Grid>
      </Grid>
    </Box>
  );
};

function KTPUpdate() {
  return (
    <ThemeProvider theme={theme}>
      <NavBar />
      <HalamanUpdateKTP />
    </ThemeProvider>
  );
}

export default KTPUpdate;
