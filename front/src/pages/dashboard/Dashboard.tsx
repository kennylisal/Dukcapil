import { Container, Grid } from "@mui/material";
import { StatWidget } from "./components/stat-widget/StatWidget";
import { WelcomeWidget } from "./components/welcome-widget/WelcomeWidget";
import { PageHeader } from "../../components/page-header/PageHeader";
import { SalesWidget } from "./components/sales-widget/SalesWidget";

export default function Dashboard() {
  return (
    <Container maxWidth={false}>
      <PageHeader title={"Dashboard"} />
      <Grid container spacing={4}>
        <Grid container size={{ xs: 12, md: 12 }} spacing={2}>
          <Grid size={{ xs: 6 }} display={"flex"}>
            <WelcomeWidget
              title={"Welcome"}
              description={"This is an example sentence to welcome a user"}
            />
          </Grid>
          <Grid size={{ xs: 6 }} display={"flex"}>
            <WelcomeWidget
              title={"Welcome"}
              description={"This is an example sentence to welcome a user"}
            />
          </Grid>
        </Grid>
        <Grid container size={{ xs: 12, md: 12 }} spacing={2}>
          <Grid size={{ xs: 6, md: 3 }} display={"flex"}>
            <StatWidget
              title={"Active users"}
              value={"12 153"}
              footerText={"Current Month"}
            />
          </Grid>
          <Grid size={{ xs: 6, md: 3 }} display={"flex"}>
            <StatWidget
              title={"Users"}
              value={"19 539"}
              footerText={"Current Month"}
            />
          </Grid>
        </Grid>

        <Grid container size={{ xs: 12, md: 12 }} spacing={2}>
          <Grid size={{ xs: 6, md: 3 }} display={"flex"}>
            <SalesWidget />
          </Grid>
        </Grid>

        {/* <Grid container item xs={12} md={12} spacing={2}>
          <Grid item md={3} xs={6}>
            <StatWidget title={'Active users'} value={'12 153'} footerText={'Current Month'} />
          </Grid>

          <Grid item md={3} xs={6}>
            <StatWidget title={'Users'} value={'19 539'} footerText={'Current Month'} />
          </Grid>

          <Grid item md={3} xs={6}>
            <StatWidget title={'Sales'} value={'1 521'} footerText={'Current Month'} />
          </Grid>

          <Grid item md={3} xs={6}>
            <StatWidget title={'Posts'} value={'126'} footerText={'Current Month'} />
          </Grid>
        </Grid> */}

        {/* <Grid container item xs={12} md={12} spacing={2}>
          <Grid item md={6} xs={12}>
            <SalesWidget />
          </Grid>

          <Grid item md={6} xs={12}>
            <UsersStatsWidget />
          </Grid>
        </Grid> */}
      </Grid>
    </Container>
  );
}
