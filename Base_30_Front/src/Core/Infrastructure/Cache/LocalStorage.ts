import { ILocalStorage } from './ILocalStorage';

export class LocalStorage implements ILocalStorage {
    setStorage (key: string, value: object | null): void {
        if (value) {
            localStorage.setItem(key, JSON.stringify(value));
        } else {
            localStorage.removeItem(key);
        }
    }

    getStorage (key: string): object | null {
        const localData:string | null = localStorage.getItem(key);
        if (localData){
            return JSON.parse(localData);
        }
        return null;
    }
}
