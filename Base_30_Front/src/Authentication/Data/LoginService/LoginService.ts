import { LoginDTO } from '../../Domain/Dto/LoginDto';
import { UserDTO } from '../../Domain/Dto/UserDto';
import { ILoginService } from './ILoginService';
import { ILoginInfra } from '../../Infrastructure/Login/ILoginInfra';
import { HttpStatusCode } from '../../../Core/Data/Protocols/HttpClient';

export class LoginService implements ILoginService {
    private _remoteLogin: ILoginInfra;

    constructor(remoteLogin: ILoginInfra) {
        this._remoteLogin = remoteLogin;
    }

    public async Login(loginDto:LoginDTO): Promise<UserDTO> {
        const httpResponse = await this._remoteLogin.Login(loginDto);

        const userDto: UserDTO = {
            name: '',
            email: '',
            authenticated: false,
            token: '',
            error: ''
        };

        if (httpResponse.statusCode === HttpStatusCode.ok) {
            userDto.token = <string><unknown>httpResponse.body;
            userDto.email = loginDto.email;
            userDto.authenticated = true;  
            userDto.error = '';
        }
        else if (httpResponse.statusCode == null) {
            userDto.error = 'unspecific';
        }
        else {
            userDto.error = 'InvalidCredentials';
        }
        
        
        return userDto;        
    }
}

