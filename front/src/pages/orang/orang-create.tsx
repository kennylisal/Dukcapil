import { useState, type ChangeEvent } from "react";
import { Box, Button, Grid, Stack, TextField } from "@mui/material";
import SimpleCard from "../../components/CardContainer/CardContainer";
const Form = () => {
  const initState = {
    Nik: "",
    Nama: "",
    Tanggal_lahir: "",
    Tempat_lahir: "",
    Agama: "",
    Kelamin: "",
    Kewaganegaraan: "",
  };
  const [state, setState] = useState(initState);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setState((prev) => ({ ...prev, [name]: value }));
  };

  return (
    <>
      <Grid container spacing={6}>
        <Grid size={{ md: 6, xs: 12 }} sx={{ mt: 2 }}>
          <Stack spacing={3}>
            <TextField
              fullWidth
              type="text"
              name="Nik"
              value={state.Nik}
              onChange={handleChange}
              label="Nik"
            />

            <TextField
              fullWidth
              type="text"
              name="Nama"
              label="Nama orang"
              onChange={handleChange}
              value={state.Nama}
            />

            <TextField
              fullWidth
              type="text"
              name="Tanggal_lahir"
              label="Tanggal Lahir"
              value={state.Tanggal_lahir}
              onChange={handleChange}
            />

            <TextField
              sx={{ mb: 4 }}
              fullWidth
              type="text"
              name="Tempat_lahir"
              label="Tempat Lahir"
              onChange={handleChange}
              value={state.Tempat_lahir}
            />
          </Stack>
        </Grid>

        <Grid size={{ md: 6, xs: 12 }} sx={{ mt: 2 }}>
          <Stack spacing={3}>
            <TextField
              fullWidth
              type="text"
              name="Agama"
              value={state.Agama}
              label="Agama"
              onChange={handleChange}
            />
            <TextField
              fullWidth
              type="text"
              name="Kelamin"
              value={state.Kelamin}
              label="Kelamin"
              onChange={handleChange}
            />
            <TextField
              fullWidth
              type="text"
              name="Kelamin"
              value={state.Kelamin}
              label="Kelamin"
              onChange={handleChange}
            />
          </Stack>
        </Grid>
      </Grid>
      <Box sx={{ my: 5 }} />
      <Stack direction="row" spacing={3}>
        <Button color="primary" variant="contained" type="submit">
          Submit
        </Button>
        <Button color="secondary" variant="contained">
          Auto-Generate
        </Button>
      </Stack>
    </>
  );
};

const CreateOrangForm = () => (
  <SimpleCard
    title="Create Orang"
    subtitle="Craete ini akan automatis membuat Akta Kelahiran & KTP"
  >
    <Form />
  </SimpleCard>
);

export default CreateOrangForm;
