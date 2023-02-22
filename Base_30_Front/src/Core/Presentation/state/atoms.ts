import { atom } from 'recoil';

export const mainError = atom<string>({
    key: 'mainError',
    default: ''
});