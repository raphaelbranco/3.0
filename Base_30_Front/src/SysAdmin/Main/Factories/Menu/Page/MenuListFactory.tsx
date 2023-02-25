import React from 'react';
import { MenuListPage } from '../../../../../SysAdmin/Presentation/Pages/MenuListPage';
import { MakeMenuServiceFactory } from '../Service/MakeMenuServiceFactory';

export const MenuListFactory: React.FC = () => {
    return (
        <MenuListPage menuService={MakeMenuServiceFactory()}/>
    );
};