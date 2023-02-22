import styles from './LoginPage.module.scss';
import { Box } from '@mui/material';
import { InputIcon } from '../../../Core/Presentation/Components/InputIcon/InputIcon';
import { useEffect, useState } from 'react';
import { ILoginController } from '../Controllers/ILoginController';
import { SetMainError } from '../../../Core/Presentation/Hooks/mainError/SetMainError';
import FormStatus from '../../../Core/Presentation/Components/FormStatus/FormStatus';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import { SubmitButton } from '../../../Core/Presentation/Components/SubmitButton/SubmitButton';

type Props = {
    loginController: ILoginController;
}

const LoginPage: React.FC<Props> = ({loginController}: Props) => {
    
    const [email, setEmail] = useState('teste@14.com');
    const [emailError, setEmailError] = useState('');
    const [password, setPassword] = useState('12345S#s1');
    const [passwordError, setPasswordError] = useState('');    
    const [isLoading, setLoading] = useState(false);
    const { t } = useTranslation();
    const navigate = useNavigate();
    
    const mainError = SetMainError();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setLoading(true);
        const errorReturn = await loginController.HandleSubmit(
            event, 
            {fieldName: 'email', input: {email}}, 
            {fieldName: 'password', input: {password}}            
        );
        if (errorReturn) {                                   
            setLoading(false);
            const error = t(`error.${errorReturn}`);
            mainError(error);
        }
        else {            
            navigate('/menu');
            navigate(0);
        }
    };

    useEffect(() => {loginController.HandleFieldChange('email', {email}, setEmailError);}, [email]);
    useEffect(() => {loginController.HandleFieldChange('password', {password}, setPasswordError);}, [password]);

    return (        
        <div>            
            
            <div className={styles.loginContainer}>
                <FormStatus></FormStatus>            
                <form onSubmit={handleSubmit}>                
                    <h1>Login</h1>
                        
                    <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                        <InputIcon 
                            name='email'
                            label='E-mail'
                            iconName='mail'  
                            placeholder={t('login.TypeEmail') as string}                            
                            setState={setEmail}
                            helperText={emailError}
                            value={email}                                                        
                        ></InputIcon>     
                    </Box>
                    <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                        <InputIcon 
                            name='password'
                            label='Password'
                            iconName='lock'  
                            placeholder={t('login.TypePassword') as string} 
                            type="password"
                            setState={setPassword}
                            value={password}
                            helperText={passwordError}
                        ></InputIcon>     
                    </Box>
                    <div className={styles.submitContainer}>                        
                        <SubmitButton label="Login" isLoading={isLoading} icon='login'></SubmitButton>
                    </div>
                </form>
            </div>
        </div>
        
    );
};

export default LoginPage;