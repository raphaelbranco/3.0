import { HttpClient, HttpMethod, HttpResponse } from '../../../Core/Data/Protocols/HttpClient';
import { MenuDto } from '../../Domain/Menu/MenuDto';
import { SysAdminEndpoints } from '../https/SysAdminEndpoints';
import { IMenuInfra } from './IMenuInfra';

export class MenuInfra implements IMenuInfra {
    constructor (        
        private readonly httpClient: HttpClient<string>,
        private readonly sysAdminEndpoints : SysAdminEndpoints
    ) {}
    
    async GetAll(): Promise<HttpResponse<string>> {
        const endpoint = this.sysAdminEndpoints.getGetAllUrl();
        return await this.CallAPI(endpoint.url, endpoint.method);
    }

    async Create(menuDto: MenuDto): Promise<HttpResponse<string>> {
        const endpoint = this.sysAdminEndpoints.getCreateUrl();
        return await this.CallAPI(endpoint.url, endpoint.method, menuDto);
    }

    async Update(menuDto: MenuDto): Promise<HttpResponse<string>> {
        const endpoint = this.sysAdminEndpoints.getUpdateUrl();
        return await this.CallAPI(endpoint.url, endpoint.method, menuDto);
    }

    private async CallAPI(url:string, method:HttpMethod, menuDto?: MenuDto){
        const httpResponse:HttpResponse<string> = 
        await this.httpClient.request({
            url: url,
            method: method,
            body: menuDto
        });
        return httpResponse; 
    }

}