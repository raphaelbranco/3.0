import { useRecoilValue, useSetRecoilState } from 'recoil';
import { tokenState } from '../atom';

export const SaveTokenInStorage = () => {    
    const setToken = useSetRecoilState(tokenState);
    sessionStorage.setItem('token', JSON.stringify(GetTokenFromStorage()));   
    console.log('salvou:' + GetTokenFromStorage());
    return setToken;
}; 

export function GetTokenFromStorage() {
    const token = useRecoilValue(tokenState);
    return token;
}
