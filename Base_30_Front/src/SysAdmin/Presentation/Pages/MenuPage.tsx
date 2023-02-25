import styles from './MenuPage.module.scss';
import { useEffect, useState } from 'react';
import { IMenuController } from '../Controllers/IMenuController';
import FormStatus from '../../../Core/Presentation/Components/FormStatus/FormStatus';
import { SetMainError } from '../../../Core/Presentation/Hooks/mainError/SetMainError';
import { useTranslation } from 'react-i18next';
import { Alert, AlertTitle, Box, Button } from '@mui/material';
import { InputIcon } from '../../../Core/Presentation/Components/InputIcon/InputIcon';
import { SubmitButton } from '../../../Core/Presentation/Components/SubmitButton/SubmitButton';
import { useNavigate } from 'react-router-dom';

type Props = {
    menuController: IMenuController;
}

export const MenuPage: React.FC<Props> = ({menuController}: Props) => {
    const [name, setName] = useState('menu name');
    const [nameError, setNameError] = useState('');
    const [order, setOrder] = useState('1');
    const [orderError, setOrderError] = useState('');  
    const [showSucess, setShowSucess] = useState(false);
    const navigate = useNavigate();

    const [isLoading, setLoading] = useState(false);
    const mainError = SetMainError();
    const { t } = useTranslation();
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setLoading(true);
        const errorReturn = await menuController.HandleSubmit(
            event, 
            {fieldName: 'name', input: {name}}, 
            {fieldName: 'order', input: {order}}            
        );
        setLoading(false);
        if (errorReturn) {                                   
            const error = t(`error.${errorReturn}`);
            mainError(error);
        }
        else {            
            setShowSucess(true);
        }
    };

    useEffect(() => {menuController.HandleFieldChange('email', {name}, setNameError);}, [name]);
    useEffect(() => {menuController.HandleFieldChange('order', {order}, setOrderError);}, [order]);

    const handleAlertClick = () => {
        navigate('/menu');
    };

    return (
        <>
            {
                showSucess &&
            <Alert

                severity="success"
                action={<Button color="inherit" size="small" onClick={handleAlertClick}>
                        Check It Out!
                </Button>}
            >
                <AlertTitle>{t('Success')}</AlertTitle>
                {t('menu.Saved')};
            </Alert>
            }
            <div className={styles.loginContainer}>

                <FormStatus></FormStatus>
                <form onSubmit={handleSubmit}>
                    <h1>{t('menu.CreateMenu')}</h1>

                    <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                        <InputIcon
                            name='name'
                            label={t('common.Name') as string}
                            iconName='text'
                            placeholder={t('menu.TypeMenuName') as string}
                            setState={setName}
                            helperText={nameError}
                            value={name}
                        ></InputIcon>
                    </Box>
                    <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
                        <InputIcon
                            name='order'
                            label={t('common.Order') as string}
                            iconName='number'
                            placeholder={t('menu.TypeOrderNumber') as string}
                            setState={setOrder}
                            value={order}
                            helperText={orderError}
                        ></InputIcon>
                    </Box>
                    <div className={styles.submitContainer}>
                        <SubmitButton label={t('common.Save') as string} isLoading={isLoading} icon='save'></SubmitButton>
                    </div>
                </form>
            </div></>
    );
};