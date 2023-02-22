import { ILoginService } from '../../../../../Authentication/Data/LoginService/ILoginService';
import { LoginService } from '../../../../../Authentication/Data/LoginService/LoginService';
import { MakeLoginInfraFactory } from '../Infrastructure/MakeLoginInfraFactory';


export const MakeLoginServiceFactory = ():ILoginService => 
    new LoginService(MakeLoginInfraFactory());

