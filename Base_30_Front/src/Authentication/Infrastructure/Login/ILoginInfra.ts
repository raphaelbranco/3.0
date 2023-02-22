import { HttpResponse } from '@/src/Core/Data/Protocols/HttpClient';
import { LoginDTO } from '../../Model/Dto/LoginDto';

export interface ILoginInfra {
    Login (params: LoginDTO): Promise<HttpResponse<string>>
}