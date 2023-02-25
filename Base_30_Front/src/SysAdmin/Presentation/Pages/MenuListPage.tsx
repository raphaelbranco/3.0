import { useEffect, useState } from 'react';
import { IMenuService } from '../../Data/MenuService/IMenuService';
import { MenuDto } from '../../Domain/Menu/MenuDto';
import BoxList from '../Components/BoxList';

type Props = {
    menuService: IMenuService;
}


export const MenuListPage: React.FC<Props> = ({menuService}: Props) => {    
    const [menuList, setMenuState] = useState<MenuDto[]>([]);

    useEffect(() => {
        async function fetchMenus() {
            const menu:MenuDto[] = await menuService.GetAll();
            setMenuState(menu);
        }
        fetchMenus();
    }, []);

    return (
        <>
            <BoxList menuList={menuList}></BoxList>
        </>
    );
};