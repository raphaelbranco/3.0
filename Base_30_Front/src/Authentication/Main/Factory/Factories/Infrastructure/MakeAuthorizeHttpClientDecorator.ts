import { HttpClient } from '@/src/Core/Data/Protocols/HttpClient';
import { AuthorizeHttpClientDecorator } from '../../../../../Authentication/Infrastructure/https/AuthorizeHttpClientDecorator';
import { MakeAxiosHttpClient } from '../../../../../Core/Main/Factories/MakeAxiosHttpClient';
import { MakeLocalStorage } from '../../../../../Core/Main/Factories/MakeLocalStorage';

export const MakeAuthorizeHttpClientDecorator = (): HttpClient =>
    new AuthorizeHttpClientDecorator(MakeLocalStorage(), MakeAxiosHttpClient());