import { Fab } from '@mui/material';
import Spinner from '../Spinner/Spinner';
import Icon from '@mui/material/Icon';
import { MouseEventHandler } from 'react';

type Props = React.DetailedHTMLProps<React.InputHTMLAttributes<HTMLInputElement>, HTMLInputElement> & {    
    label: string,  
    isLoading: boolean,
    onClick?: MouseEventHandler<HTMLButtonElement> | undefined,
    icon:string
}

export const SubmitButton: React.FC<Props> = (props: Props) => {

    return (
        <>              
            <Fab 
                variant="extended" 
                size="medium" 
                aria-label={props.label} 
                type="submit" 
                disabled={Boolean(props.isLoading)}
                onClick={props.onClick}
            >     
                {props.isLoading && <Spinner isLoading={props.isLoading}></Spinner>}
                {!props.isLoading && <Icon sx={{ color: 'action.active', mr: 1, my: 3 }}>{props.icon}</Icon>}
                {props.label}
            </Fab> 
        </>
    );
    

     
};

