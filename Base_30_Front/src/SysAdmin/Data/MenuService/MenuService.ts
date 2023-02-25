import { HttpResponse, HttpStatusCode } from '../../../Core/Data/Protocols/HttpClient';
import { MenuDto } from '../../Domain/Menu/MenuDto';
import { IMenuInfra } from '../../Infraestructure/Menu/IMenuInfra';
import { IMenuService } from './IMenuService';

export class MenuService implements IMenuService {
    private _menuInfra: IMenuInfra;

    constructor(menuInfra: IMenuInfra) {
        this._menuInfra = menuInfra;
    }

    async GetAll(): Promise<MenuDto[]> {
        const httpResponse = await this._menuInfra.GetAll();

        if (httpResponse.statusCode === HttpStatusCode.ok && httpResponse.body) {
            return [...httpResponse.body as unknown as MenuDto[]].map(menuDto => ({
                id: menuDto.id,
                name: menuDto.name,
                order: menuDto.order
            }));
        }
        
        return [{ errorResponse: 'unspecific' }];
    }
    async Create(menuDto: MenuDto): Promise<boolean> {
        const ret:HttpResponse<string> = await this._menuInfra.Create(menuDto);

        return ret.statusCode === HttpStatusCode.ok;
    }
    async Update(menuDto: MenuDto): Promise<boolean> {
        const ret:HttpResponse<string> = await  this._menuInfra.Update(menuDto);
        
        return ret.statusCode === HttpStatusCode.ok;
    }

}