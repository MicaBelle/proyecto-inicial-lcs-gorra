import * as React from 'react';
import Box from '@mui/material/Box';
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import FormatListNumberedRtlIcon from '@mui/icons-material/FormatListNumberedRtl';
import AddIcon from '@mui/icons-material/Add';
import HomeIcon from '@mui/icons-material/Home';
import { useNavigate } from 'react-router-dom'
import { Link } from 'react-router-dom';

export default function SimpleBottomNavigation() {
  const [value, setValue] = React.useState(0);

  const navigate = useNavigate();

  const handleNavigation = (path) => {
    navigate(path);
  };

  return (
    <Box sx={{ width: "100%" }}>
      <BottomNavigation
        showLabels
        value={value}
        onChange={(event, newValue) => {
          setValue(newValue);
        }}
      >
        <BottomNavigationAction
        label="Inicio"
        icon={<HomeIcon />}
        component={Link}
        to="/"
      />
      <BottomNavigationAction
        label="Denunciar robo"
        icon={<AddIcon />}
        component={Link}
        to="/report"
      />
      <BottomNavigationAction
        label="Mis denuncias"
        icon={<FormatListNumberedRtlIcon />}
        component={Link}
        to="/my-reports"
      />
      </BottomNavigation>
    </Box>
  );
}