import { IMenuController } from '../../../../Presentation/Controllers/IMenuController';
import { MenuController } from '../../../../Presentation/Controllers/MenuController';
import { MakeMenuServiceFactory } from '../Service/MakeMenuServiceFactory';
import { MakeMenuValidationFactory } from '../Validation/MakeMenuValidationFactory';

export const MakeMenuControllerFactory =(): IMenuController =>
{
    return new MenuController(MakeMenuValidationFactory(), MakeMenuServiceFactory());
};
