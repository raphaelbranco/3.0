import { ISysAdminEndpoints } from '../../../../Infraestructure/https/ISysAdminEndpoints';
import { SysAdminEndpoints } from '../../../../Infraestructure/https/SysAdminEndpoints';

export const MakeSysAdminEndpointsFactory = ():ISysAdminEndpoints => 
    new SysAdminEndpoints();