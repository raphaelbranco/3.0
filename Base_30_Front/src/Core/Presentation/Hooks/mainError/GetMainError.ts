import { useRecoilValue } from 'recoil';
import { mainError } from '../../state/atoms';

export const GetMainError = ():string => {
    const error = useRecoilValue(mainError);
    return error;
};