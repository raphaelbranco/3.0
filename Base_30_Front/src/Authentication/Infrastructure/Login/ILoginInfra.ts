import { HttpResponse } from '@/src/Core/Data/Protocols/HttpClient';
import { LoginDTO } from '../../Domain/Dto/LoginDto';

export interface ILoginInfra {
    Login (params: LoginDTO): Promise<HttpResponse<string>>
}