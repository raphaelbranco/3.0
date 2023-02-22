import { TextField } from '@mui/material';
import Icon from '@mui/material/Icon';

type Props = React.DetailedHTMLProps<React.InputHTMLAttributes<HTMLInputElement>, HTMLInputElement> & {
    iconName?: string
    label: string 
    placeholder?: string
    name?:string
    type?:string
    value?:string
    setState?:React.SetStateAction<any>
    onBlur?:React.FocusEventHandler<HTMLInputElement> | undefined
    helperText?: string
}

export const InputIcon = (props: Props) => {
    let label:string = '';
    if (!props.value) { label = props.label; }
    

    return (
        <>
            {props.iconName && <Icon sx={{ color: 'action.active', mr: 1, my: 3 }}>{props.iconName}</Icon>}
            <TextField 
                id={props.name} 
                data-testid={props.name}
                label={label}
                placeholder={props.placeholder}   
                type={props.type}
                title={props.label}              
                variant="outlined"                 
                value={props.value}
                onChange={(event) => {props.setState(event.target.value);}}
                onBlur={props.onBlur}
                helperText={props.helperText}
                error={Boolean(props.helperText)}
            />               
        </>
    );
    

     
};

