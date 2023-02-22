import { ILocalStorage } from '@/src/Core/Infrastructure/Cache/ILocalStorage';
import { ILogOutController } from './ILogOutController';


export class LogOutController implements ILogOutController {
    private _localStorage: ILocalStorage;

    constructor(localStorage: ILocalStorage) {
        this._localStorage = localStorage;
    }

    handleLogOut(): void {
        //Clear Storage
        this._localStorage.setStorage('accountUser', null);
    }

}