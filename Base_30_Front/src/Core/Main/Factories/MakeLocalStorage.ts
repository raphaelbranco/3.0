import { LocalStorage } from '../../Infrastructure/Cache/LocalStorage';

export const MakeLocalStorage = (): LocalStorage => new LocalStorage();