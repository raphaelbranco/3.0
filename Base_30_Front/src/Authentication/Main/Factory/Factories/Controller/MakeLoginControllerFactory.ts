import { MakeLocalStorage } from '../../../../../Core/Main/Factories/MakeLocalStorage';
import { ILoginController } from '../../../../Presentation/Controllers/ILoginController';
import { LoginController } from '../../../../Presentation/Controllers/LoginController';
import { MakeLoginServiceFactory } from '../Data/MakeLoginServiceFactory';
import { MakeLoginValidationControllerFactory } from './MakeLoginValidationControllerFactory';


export const MakeLoginControllerFactory =(): ILoginController =>
{
    return new LoginController(
        MakeLoginValidationControllerFactory(),
        MakeLoginServiceFactory(),
        MakeLocalStorage()
    );
};


