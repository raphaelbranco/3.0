import { SubmitButton } from '../../../Core/Presentation/Components/SubmitButton/SubmitButton';
import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import { ILogOutController } from '../Controllers/ILogOutController';
import styles from './LogOutPage.module.scss';
 
type Props = {
    logOutController: ILogOutController
}

const LogOutPage: React.FC<Props> = ({logOutController} : Props) => {
    const { t } = useTranslation();
    const [isLoading, setLoading] = useState(false);
    const navigate = useNavigate();
    
    const handleLogOut = ():void => {
        setLoading(true);
        logOutController.handleLogOut();
        navigate('/');
        navigate(0);
    };

    return (
        <>
            <div className={styles.logOutContainer}>
                <SubmitButton 
                    label={t('common.logOut')} 
                    isLoading={isLoading} 
                    onClick={handleLogOut}
                    icon='logout'
                ></SubmitButton>
            </div>
        </>
    );
};

export default LogOutPage;