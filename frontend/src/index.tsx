import {
  Button,
  Card,
  CardActions,
  CardContent,
  Container,
  Grid,
  ThemeProvider,
  Typography,
} from "@mui/material";

import theme from "./global/theme";
import NavBar from "./global/appbar";

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

function DukcapilIndex() {
  return (
    <ThemeProvider theme={theme}>
      <NavBar />
      <HeroSection />
      <ServicesGrid />
    </ThemeProvider>
  );
}

export default DukcapilIndex;
