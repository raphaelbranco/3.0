import { useSetRecoilState } from 'recoil';
import { mainError } from '../../state/atoms';

export function SetMainError() {    
    const error = useSetRecoilState(mainError);
    return error;
}