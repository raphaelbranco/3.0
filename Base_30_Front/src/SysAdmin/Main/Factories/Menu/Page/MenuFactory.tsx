import { MenuPage } from '../../../../Presentation/Pages/MenuPage';
import React from 'react';
import { MakeMenuControllerFactory } from '../Controller/MakeMenuControllerFactory';

export const MenuFactory: React.FC = () => {
    return (
        <MenuPage menuController={MakeMenuControllerFactory()}  />
    );
};