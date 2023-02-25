import { IMenuService } from '../../../../Data/MenuService/IMenuService';
import { MenuService } from '../../../../Data/MenuService/MenuService';
import { MakeMenuInfraFactory } from '../Infra/MakeMenuInfraFactory';

export const MakeMenuServiceFactory =(): IMenuService =>
{
    return new MenuService(MakeMenuInfraFactory());
};
