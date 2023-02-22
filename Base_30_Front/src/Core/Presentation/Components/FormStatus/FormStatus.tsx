import { useEffect, useState } from 'react';
import { useSetRecoilState } from 'recoil';
import { GetMainError } from '../../Hooks/mainError/GetMainError';
import styles from './FormStatus.module.scss';
import { mainError } from '../../state/atoms';

const FormStatus: React.FC = () => {    
    const atomError = GetMainError();
    const [fadeOut, setFadeOut] = useState(false);
    const setMainError = useSetRecoilState(mainError);

    useEffect(() => {
        if (atomError) {
            setTimeout(() => {
                setFadeOut(true);
                setTimeout(() => {
                    setMainError('');    
                    setTimeout(() => {
                        setFadeOut(false);
                    }, 1000);
                }, 2000);
            }, 3000);
        }
    }, [atomError]);
    
    return (
        <div className={styles.errorWrap}>  
            {
                atomError && 
                <span 
                    id="mainError" 
                    className={`${styles.mainError} ${fadeOut ? styles['mainError--fadeout'] : ''}`}
                >
                    {atomError}
                </span>
            }
        </div>
    );
};
  
export default FormStatus;