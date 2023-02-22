import LoginPage from '../../../../../Authentication/Presentation/Pages/LoginPage';
import React from 'react';
import { MakeLoginControllerFactory } from '../Controller/MakeLoginControllerFactory';

export const LoginFactory: React.FC = () => {
    return (
        <LoginPage loginController={MakeLoginControllerFactory()}  />
    );
};