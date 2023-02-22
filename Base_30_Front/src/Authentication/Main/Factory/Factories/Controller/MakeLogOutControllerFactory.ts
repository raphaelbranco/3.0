import { ILogOutController } from '../../../../../Authentication/Presentation/Controllers/ILogOutController';
import { LogOutController } from '../../../../..//Authentication/Presentation/Controllers/LogOutController';
import { MakeLocalStorage } from '../../../../../Core/Main/Factories/MakeLocalStorage';


export const MakeLogOutControllerFactory =(): ILogOutController =>
{
    return new LogOutController(
        MakeLocalStorage()
    );
};

