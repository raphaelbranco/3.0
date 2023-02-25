import * as React from 'react';
import Box from '@mui/material/Box';
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import { t } from 'i18next';
import { Icon } from '@mui/material';
import { Link } from 'react-router-dom';

const NavBar = () => {
      
    const [value, setValue] = React.useState(0);

    return (
        <Box sx={{ width: '100%' }}>
            <BottomNavigation
                showLabels
                value={value}
                onChange={(event, newValue) => {
                    console.log(event);
                    setValue(newValue);
                }}
            >
                <BottomNavigationAction label={t('nav.Home')} icon={<Icon>home</Icon>} component={Link} to="/" />                
                <BottomNavigationAction label={t('nav.MenuList')} icon={<Icon>list</Icon>} component={Link} to="/menu"  />
                <BottomNavigationAction label={t('nav.CreateMenu')} icon={<Icon>create</Icon>} component={Link} to="/menu_create"  />
                <BottomNavigationAction label={t('nav.LogOut')} icon={<Icon>logout</Icon>} component={Link} to="/logout"  />
            </BottomNavigation>
        </Box>
    );

};

export default NavBar;