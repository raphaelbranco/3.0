import { AuthenticationEndpoints } from '../../../../Infrastructure/https/AuthenticationEndpoints';
import { IAuthenticationEndpoints } from '../../../../Infrastructure/https/IAuthenticationEndpoints';

export const MakeAuthEndpoints = ():IAuthenticationEndpoints => 
    new AuthenticationEndpoints();
