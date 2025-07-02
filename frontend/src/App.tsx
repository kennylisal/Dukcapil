import {
  AppBar,
  Button,
  Card,
  CardActions,
  CardContent,
  Container,
  Divider,
  Grid,
  Menu,
  MenuItem,
  ThemeProvider,
  Toolbar,
  Typography,
} from "@mui/material";
import { createTheme } from "@mui/material/styles";
import React, { useState } from "react";

const theme = createTheme({
  palette: {
    primary: { main: "#003087" },
    secondary: { main: "#FBC02D" },
    background: { default: "#F5F5F5" },
  },
  typography: { fontFamily: "Roboto, sans-serif" },
});

const NavBar: React.FC = () => {
  const [anchor, setAnchor] = useState<{ [key: string]: HTMLElement | null }>({
    ktp: null,
    keluarga: null,
    nikah: null,
    kelahiran: null,
  });

  const handleMenuOpen =
    (name: string) => (event: React.MouseEvent<HTMLButtonElement>) => {
      setAnchor((prev) => ({ ...prev, [name]: event.currentTarget }));
    };

  const handleMenuClose = (name: string) => () => {
    setAnchor((prev) => ({ ...prev, [name]: null }));
  };
  return (
    <AppBar position="static" color="primary">
      <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
        <Typography variant="h5" sx={{ fontWeight: "bold" }}>
          DUKCAPIL
        </Typography>
        <div>
          <Button
            color="inherit"
            sx={{ mr: 2 }}
            onClick={handleMenuOpen("ktp")}
            aria-controls={anchor.ktp ? "services-menu" : undefined}
            aria-haspopup="true"
            aria-expanded={anchor.ktp ? "true" : undefined}
          >
            KTP
          </Button>
          <Menu
            id="ktp-menu"
            anchorEl={anchor.ktp}
            open={Boolean(anchor.ktp)}
            onClose={handleMenuClose("ktp")}
            anchorOrigin={{
              vertical: "bottom",
              horizontal: "right",
            }}
            transformOrigin={{
              vertical: "top",
              horizontal: "right",
            }}
          >
            <Typography
              variant="subtitle2"
              sx={{
                px: 2,
                pt: 1,
                pb: 0.5,
                fontWeight: "bold",
                color: "text.secondary",
              }}
            >
              KTP
            </Typography>
            <MenuItem onClick={handleMenuClose("ktp")}>Buat</MenuItem>
            <MenuItem onClick={handleMenuClose("ktp")}>Update</MenuItem>
          </Menu>
          <Button
            color="inherit"
            sx={{ mr: 2 }}
            onClick={handleMenuOpen("keluarga")}
            aria-controls={anchor.keluarga ? "services-menu" : undefined}
            aria-haspopup="true"
            aria-expanded={anchor.keluarga ? "true" : undefined}
          >
            Keluarga
          </Button>
          <Menu
            id="services-menu"
            anchorEl={anchor.keluarga}
            open={Boolean(anchor.keluarga)}
            onClose={handleMenuClose("keluarga")}
            anchorOrigin={{
              vertical: "bottom",
              horizontal: "right",
            }}
            transformOrigin={{
              vertical: "top",
              horizontal: "right",
            }}
          >
            <Typography
              variant="subtitle2"
              sx={{
                px: 2,
                pt: 1,
                pb: 0.5,
                fontWeight: "bold",
                color: "text.secondary",
              }}
            >
              Kartu Keluarga
            </Typography>
            <MenuItem onClick={handleMenuClose("keluarga")}>Buat</MenuItem>
            <MenuItem onClick={handleMenuClose("keluarga")}>Perbarui</MenuItem>
            <MenuItem onClick={handleMenuClose("keluarga")}>
              Death Certificates
            </MenuItem>
            <Divider />
            <Typography
              variant="subtitle2"
              sx={{
                px: 2,
                pt: 1,
                pb: 0.5,
                fontWeight: "bold",
                color: "text.secondary",
              }}
            >
              Pohon Keluarga
            </Typography>
            <MenuItem onClick={handleMenuClose("keluarga")}>Cari</MenuItem>
          </Menu>
          <Button
            color="inherit"
            sx={{ mr: 2 }}
            onClick={handleMenuOpen("kelahiran")}
            aria-controls={anchor.kelahiran ? "services-menu" : undefined}
            aria-haspopup="true"
            aria-expanded={anchor.kelahiran ? "true" : undefined}
          >
            Kelahiran
            <Menu
              id="kelahiran-menu"
              anchorEl={anchor.kelahiran}
              open={Boolean(anchor.kelahiran)}
              onClose={handleMenuClose("kelahiran")}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "right",
              }}
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
            >
              <Typography
                variant="subtitle2"
                sx={{
                  px: 2,
                  pt: 1,
                  pb: 0.5,
                  fontWeight: "bold",
                  color: "text.secondary",
                }}
              >
                Akta Kelahiran
              </Typography>
              <MenuItem onClick={handleMenuClose("kelahiran")}>Buat</MenuItem>
              <MenuItem onClick={handleMenuClose("kelahiran")}>Update</MenuItem>
            </Menu>
          </Button>
          <Button
            color="inherit"
            sx={{ mr: 2 }}
            onClick={handleMenuOpen("nikah")}
            aria-controls={anchor.nikah ? "services-menu" : undefined}
            aria-haspopup="true"
            aria-expanded={anchor.nikah ? "true" : undefined}
          >
            Pernikahan
            <Menu
              id="nikah-menu"
              anchorEl={anchor.nikah}
              open={Boolean(anchor.nikah)}
              onClose={handleMenuClose("nikah")}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "right",
              }}
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
            >
              <Typography
                variant="subtitle2"
                sx={{
                  px: 2,
                  pt: 1,
                  pb: 0.5,
                  fontWeight: "bold",
                  color: "text.secondary",
                }}
              >
                Akta Pernikahan
              </Typography>
              <MenuItem onClick={handleMenuClose("nikah")}>Buat</MenuItem>
              <MenuItem onClick={handleMenuClose("nikah")}>Update</MenuItem>
            </Menu>
          </Button>
          <Button variant="contained" color="secondary">
            Logout
          </Button>
        </div>
      </Toolbar>
    </AppBar>
  );
};

const HeroSection = () => (
  <div
    style={{
      backgroundColor: theme.palette.background.default,
      padding: "4rem 0",
      textAlign: "center",
    }}
  >
    <Container>
      <Typography variant="h3" sx={{ fontWeight: "bold", mb: 2 }}>
        Welcome to Civil Registry Services
      </Typography>
      <Typography variant="h6" sx={{ mb: 4, color: "text.secondary" }}>
        Access vital records, business registrations, and more with ease.
      </Typography>
      <Button variant="contained" color="primary" size="large">
        Explore Services
      </Button>
    </Container>
  </div>
);

const ServiceCard = ({
  title,
  description,
}: {
  title: string;
  description: string;
}) => (
  <Card sx={{ height: "100%", display: "flex", flexDirection: "column" }}>
    <CardContent sx={{ flexGrow: 1 }}>
      <Typography variant="h6" sx={{ fontWeight: "bold", mb: 1 }}>
        {title}
      </Typography>
      <Typography variant="body2" color="text.secondary">
        {description}
      </Typography>
    </CardContent>
    <CardActions>
      <Button size="small" color="primary">
        Learn More
      </Button>
    </CardActions>
  </Card>
);

const ServicesGrid = () => (
  <Container sx={{ py: 8 }}>
    <Typography
      variant="h4"
      sx={{ fontWeight: "bold", textAlign: "center", mb: 4 }}
    >
      Our Services
    </Typography>
    <Grid container spacing={4}>
      {[
        {
          title: "Birth Certificates",
          description: "Order certified copies of birth records.",
        },
        {
          title: "Marriage Certificates",
          description: "Access marriage records and licenses.",
        },
        {
          title: "Business Registration",
          description: "Register or manage your business entity.",
        },
        {
          title: "Death Certificates",
          description: "Obtain certified death records.",
        },
      ].map((service, idx) => (
        <Grid size={{ xs: 12, sm: 6, lg: 6 }} key={idx}>
          <ServiceCard
            title={service.title}
            description={service.description}
          />
        </Grid>
      ))}
    </Grid>
  </Container>
);

function App() {
  return (
    <ThemeProvider theme={theme}>
      <NavBar />
      <HeroSection />
      <ServicesGrid />
    </ThemeProvider>
  );
}

export default App;
