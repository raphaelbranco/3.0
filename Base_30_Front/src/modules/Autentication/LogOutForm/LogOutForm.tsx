import { Fab } from '@mui/material';
import LogoutIcon from '@mui/icons-material/Logout';
import { useNavigate } from 'react-router-dom';
import AuthenticationApi from '../https/AuthenticationApi';
import { useState } from 'react';
import { SaveTokenInStorage } from 'state/hooks/useToken';

export default function LogoutForm() {    
    const saveToken = SaveTokenInStorage();
    const navigate = useNavigate();    
    const email = 'teste@14.com';
    const data = { email };
    const [isLoading, setLoading] = useState(false);
      
    function DoLogOut(){
        setLoading(true);

        AuthenticationApi
            .post('LogOut', data)
            .then(function () {
                saveToken('');
                navigate('/menu');
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    return(
        <div>
            <Fab variant="extended" size="medium" aria-label='Login' type="button" onClick={DoLogOut} disabled={isLoading}>
                <LogoutIcon sx={{ mr: 2 }} />   
                    Logout
            </Fab>   
        </div>
    );
}