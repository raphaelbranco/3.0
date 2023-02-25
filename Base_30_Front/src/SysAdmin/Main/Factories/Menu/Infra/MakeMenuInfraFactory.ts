import { MakeAuthorizeHttpClientDecorator } from '../../../../../Authentication/Main/Factory/Factories/Infrastructure/MakeAuthorizeHttpClientDecorator';
import { IMenuInfra } from '../../../../Infraestructure/Menu/IMenuInfra';
import { MenuInfra } from '../../../../Infraestructure/Menu/MenuInfra';
import { MakeSysAdminEndpointsFactory } from './MakeSysAdminEndpointsFactory';

export const MakeMenuInfraFactory =(): IMenuInfra =>
{
    return new MenuInfra(MakeAuthorizeHttpClientDecorator(), MakeSysAdminEndpointsFactory());
};
