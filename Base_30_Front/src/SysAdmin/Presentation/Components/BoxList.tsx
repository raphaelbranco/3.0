import styles from './BoxList.module.scss';
import { MenuDto } from '../../Domain/Menu/MenuDto';
import { Grid, Icon } from '@mui/material';

type Props = {
    menuList: Array<MenuDto> | null
}

const BoxList:React.FC<Props> = ({menuList}: Props ) => { 
    let count = 0;
    const icons = ['home', 'settings', 'notifications', 'dashboard', 'account_circle',
        'add_circle', 'attach_money', 'build', 'calendar_today', 'camera_alt', 'cloud', 'emoji_objects',
        'favorite', 'language'];

    return (
        <>
            
            <Grid container spacing={2} className={styles.gridContainer} alignItems='center'
                justifyContent="center">
                {
                    menuList?.map(menu => { 
                        count++;
                        const randomIconIndex = Math.floor(Math.random() * icons.length);
                        const randomIcon = icons[randomIconIndex];
                        return (                            
                            <Grid 
                                spacing={20}
                                xs={3} 
                                className={styles.boxContainer} 
                                key={count} 
                                alignItems='center'
                                justifyContent="center"
                            >
                                <div>
                                    <Icon sx={{ mr: 1 }}>{randomIcon}</Icon>
                                </div>
                                <div>
                                    {menu.name}
                                </div>
                            </Grid>
                        );
                    })
                }
            </Grid>            
        </>
    );
};

export default BoxList;