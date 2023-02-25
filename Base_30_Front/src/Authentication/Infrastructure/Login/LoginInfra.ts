import { HttpClient, HttpResponse } from '@/src/Core/Data/Protocols/HttpClient';
import { LoginDTO } from '../../Domain/Dto/LoginDto';
import { AuthenticationEndpoints } from '../https/AuthenticationEndpoints';
import { ILoginInfra } from './ILoginInfra';

export class LoginInfra implements ILoginInfra {
    
    constructor (        
        private readonly httpClient: HttpClient<string>,
        private readonly authEndpoints : AuthenticationEndpoints
    ) {}

    async Login (params: LoginDTO): Promise<HttpResponse<string>> {
        
        const httpResponse:HttpResponse<string> = 
        await this.httpClient.request({
            url: this.authEndpoints.getLoginUrl(),
            method: 'post',
            body: params
        });
        return httpResponse;       
    }
}