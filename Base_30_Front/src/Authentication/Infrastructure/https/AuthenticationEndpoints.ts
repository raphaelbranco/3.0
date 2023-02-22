import { IAuthenticationEndpoints } from './IAuthenticationEndpoints';

export class AuthenticationEndpoints implements IAuthenticationEndpoints {
    public baseUrl:string = 'https://localhost:7289';

    public getLoginUrl():string {
        return this.baseUrl + '/Login';
    }
}
