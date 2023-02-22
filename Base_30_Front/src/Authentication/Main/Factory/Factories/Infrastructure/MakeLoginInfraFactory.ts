import { ILoginInfra } from '../../../../Infrastructure/Login/ILoginInfra';
import { LoginInfra } from '../../../../Infrastructure/Login/LoginInfra';
import { MakeAxiosHttpClient } from '../../../../../Core/Main/Factories/MakeAxiosHttpClient';
import { MakeAuthEndpoints } from './MakeAuthEndpoints';

export const MakeLoginInfraFactory = (): ILoginInfra =>
    new LoginInfra(MakeAxiosHttpClient(), MakeAuthEndpoints());