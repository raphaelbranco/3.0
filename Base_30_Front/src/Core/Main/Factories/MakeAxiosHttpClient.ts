import { AxiosHttpClient } from '../../Infrastructure/https/AxiosHttpClient';

export const MakeAxiosHttpClient = (): AxiosHttpClient => new AxiosHttpClient();
