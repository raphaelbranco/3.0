import styles from './LoginForm.module.scss';
import { TextField } from '@mui/material';
import { Fab } from '@mui/material';
import LoginIcon from '@mui/icons-material/Login';
import Box from '@mui/material/Box';
import EmailIcon from '@mui/icons-material/Email';
import PasswordIcon from '@mui/icons-material/Password';
import { useState } from 'react';
import AuthenticationApi from '../https/AuthenticationApi';
import { useNavigate } from 'react-router-dom';
import { SaveTokenInStorage } from 'state/hooks/useToken';


export default function LoginForm() {
    const saveToken = SaveTokenInStorage();
    const [email, setEmail] = useState('teste@14.com');
    const [password, setPassword] = useState('12345S#s1');
    const [error, setError] = useState('');
    const navigate = useNavigate();
    const [isLoading, setLoading] = useState(false);
    
    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setError('');
        if (!email || !password) {
            setError('Please enter a username and password.');
            return;            
        }
        DoLogin();
    };

    function DoLogin(){
        const data = { email, password };
        setLoading(true);
        AuthenticationApi
            .post('Login', data)
            .then(function (response) {
                if (response){
                    console.log(response);
                    saveToken(response.data);
                    navigate('/menu');
                }                
            })
            .catch(function (error) {
                console.log(error);
            });
    }
    
    return (        
        <div className={styles.loginContainer}>    
            {error && <p style={{ color: 'red' }}>{error}</p>}        
            <form onSubmit={handleSubmit}>                
                <h1>Login</h1>

                <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                    <EmailIcon sx={{ color: 'action.active', mr: 1, my: 3 }} />
                    <TextField id="input-with-sx" label="E-mail" variant="outlined" 
                        value={email}
                        onChange={(event) => setEmail(event.target.value)}
                    />                    
                </Box>

                <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                    <PasswordIcon sx={{ color: 'action.active', mr: 1, my: 3 }} />
                    <TextField id="password" label="Password" variant='outlined' type="password"
                        value={password}
                        onChange={(event) => setPassword(event.target.value)}
                    ></TextField>                 
                </Box>
                              
                <div className={styles.submitContainer}>
                    <Fab variant="extended" size="medium" aria-label='Login' type="submit" disabled={isLoading}>
                        <LoginIcon sx={{ mr: 2 }} />   
                    Login
                    </Fab>     
                </div>
            </form>
        </div>
        
    );
}
