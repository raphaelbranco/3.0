import { MenuDto } from '../../Domain/Menu/MenuDto';

export interface IMenuService {
    GetAll(): Promise<MenuDto[]>
    Create(menuDto: MenuDto): Promise<boolean>
    Update(menuDto: MenuDto): Promise<boolean>
}