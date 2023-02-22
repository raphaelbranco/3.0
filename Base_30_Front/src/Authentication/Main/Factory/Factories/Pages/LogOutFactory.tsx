import React from 'react';
import { MakeLogOutControllerFactory } from '../Controller/MakeLogOutControllerFactory';
import LogOutPage from '../../../../../Authentication/Presentation/Pages/LogOutPage';

export const LogOutFactory: React.FC = () => {
    return (
        <LogOutPage logOutController={MakeLogOutControllerFactory()}  />
    );
};