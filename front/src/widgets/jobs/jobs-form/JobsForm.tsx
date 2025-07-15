import {
  Button,
  Card,
  Checkbox,
  FormControlLabel,
  Grid,
  Icon,
  Radio,
  RadioGroup,
  Stack,
  styled,
  TextField,
} from "@mui/material";
import { useState, type ReactNode } from "react";
import { Span } from "../../../components/Typography";

// interface JobsFormProps {
//   defaultValues?: JobsFormSchema;
//   formRef?: React.MutableRefObject<HTMLFormElement | null>;
//   onSubmit: (data: JobsFormSchema) => void;
// }

const CardRoot = styled(Card)({
  height: "100%",
  padding: "20px 24px",
  ".subtitle": { marginBottom: "1rem" },
});

interface CardTitleProps {
  subtitle?: string;
}

const CardTitle = styled("div")<CardTitleProps>(({ subtitle }) => ({
  fontSize: "1rem",
  fontWeight: 500,
  textTransform: "capitalize",
  marginBottom: !subtitle ? "16px" : undefined,
}));

interface SimpleCardProps {
  children?: ReactNode;
  title?: string;
  subtitle?: string;
}

function SimpleCard({ children, title, subtitle }: SimpleCardProps) {
  return (
    <CardRoot elevation={6}>
      <CardTitle subtitle={subtitle}>{title}</CardTitle>
      {subtitle && <div className="subtitle">{subtitle}</div>}
      {children}
    </CardRoot>
  );
}

const FormTest = () => {
  const [state, setState] = useState({
    email: "",
    mobile: "",
    gender: "",
    username: "",
    password: "",
    firstName: "",
    creditCard: "",
    confirmPassword: "",
  });
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    console.log("submitted");
    console.log(event);
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    event.persist();

    setState({ ...state, [event.target.name]: event.target.value });
  };
  const {
    username,
    firstName,
    creditCard,
    mobile,
    password,
    confirmPassword,
    gender,
    email,
  } = state;
  return (
    <div>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={6}>
          <Grid size={{ md: 6, xs: 12 }} sx={{ mt: 2 }}>
            <Stack spacing={3}>
              <TextField
                fullWidth
                type="text"
                name="username"
                value={username}
                onChange={handleChange}
                label="Username"
              />

              <TextField
                fullWidth
                type="text"
                name="firstName"
                label="First Name"
                onChange={handleChange}
                value={firstName}
              />

              <TextField
                fullWidth
                type="email"
                name="email"
                label="Email"
                value={email}
                onChange={handleChange}
              />

              <TextField
                sx={{ mb: 4 }}
                fullWidth
                type="number"
                name="creditCard"
                label="Credit Card"
                onChange={handleChange}
                value={creditCard}
              />
            </Stack>
          </Grid>

          <Grid size={{ md: 6, xs: 12 }} sx={{ mt: 2 }}>
            <Stack spacing={3}>
              <TextField
                fullWidth
                type="text"
                name="mobile"
                value={mobile}
                label="Mobile Nubmer"
                onChange={handleChange}
              />
              <TextField
                fullWidth
                name="password"
                type="password"
                label="Password"
                value={password}
                onChange={handleChange}
              />
              <TextField
                fullWidth
                type="password"
                name="confirmPassword"
                onChange={handleChange}
                label="Confirm Password"
                value={confirmPassword}
              />

              <RadioGroup
                row
                name="gender"
                value={gender}
                onChange={handleChange}
              >
                <FormControlLabel
                  value="Male"
                  label="Male"
                  labelPlacement="end"
                  control={<Radio color="secondary" />}
                />

                <FormControlLabel
                  value="Female"
                  label="Female"
                  labelPlacement="end"
                  control={<Radio color="secondary" />}
                />

                <FormControlLabel
                  value="Others"
                  label="Others"
                  labelPlacement="end"
                  control={<Radio color="secondary" />}
                />
              </RadioGroup>

              <FormControlLabel
                control={<Checkbox />}
                label="I have read and agree to the terms of service."
              />
            </Stack>
          </Grid>
        </Grid>

        <Button color="primary" variant="contained" type="submit">
          <Icon>send</Icon>
          <Span sx={{ pl: 1, textTransform: "capitalize" }}>Submit</Span>
        </Button>
      </form>
    </div>
  );
};

const JobForm = () => (
  <SimpleCard title="Simple Form">
    <FormTest />
  </SimpleCard>
);

export default JobForm;
