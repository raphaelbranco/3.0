import { HttpClient, HttpRequest, HttpResponse } from '../../../Core/Data/Protocols/HttpClient';
import { LocalStorage } from '../../../Core/Infrastructure/Cache/LocalStorage';

export class AuthorizeHttpClientDecorator implements HttpClient {
    constructor (
    private readonly localStorage: LocalStorage,
    private readonly httpClient: HttpClient
    ) {}

    async request (data: HttpRequest): Promise<HttpResponse> {
        const account:any = this.localStorage.getStorage('accountUser');
        if (account?.token) {
            Object.assign(data, {
                headers: Object.assign(data.headers || {}, {
                    'Authorization': 'Bearer ' + account.token
                })
            });
        }
        const httpResponse = await this.httpClient.request(data);
        return httpResponse;
    }
}
