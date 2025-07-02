import {
  AppBar,
  Button,
  Divider,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { useState } from "react";

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
            <MenuItem onClick={handleMenuClose("ktp")}>Search</MenuItem>
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

export default NavBar;
