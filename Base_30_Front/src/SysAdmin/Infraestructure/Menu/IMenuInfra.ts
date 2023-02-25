import { HttpResponse } from '@/src/Core/Data/Protocols/HttpClient';
import { MenuDto } from '../../Domain/Menu/MenuDto';

export interface IMenuInfra {
    GetAll(): Promise<HttpResponse<string>>
    Create(menuDto: MenuDto): Promise<HttpResponse<string>>
    Update(menuDto: MenuDto): Promise<HttpResponse<string>>
}