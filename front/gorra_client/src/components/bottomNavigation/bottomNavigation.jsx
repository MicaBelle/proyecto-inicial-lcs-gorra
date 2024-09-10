// SimpleBottomNavigation.js
import * as React from 'react';
import Box from '@mui/material/Box';
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import FormatListNumberedRtlIcon from '@mui/icons-material/FormatListNumberedRtl';
import AddIcon from '@mui/icons-material/Add';
import HomeIcon from '@mui/icons-material/Home';
import { Link, useLocation } from 'react-router-dom';

export default function SimpleBottomNavigation() {
  const [value, setValue] = React.useState(0);
  const location = useLocation();
  const [autenticado, setAutenticado] = React.useState(localStorage.getItem('user'))

  React.useEffect(() => {
    setAutenticado(localStorage.getItem('user'))
  },[location])

  return (
    <Box sx={{ width: "100%" }}>
      {autenticado != null && (
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
            to="/home"
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
      )}
    </Box>
  );
}
