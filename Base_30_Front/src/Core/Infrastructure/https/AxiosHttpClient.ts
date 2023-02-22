import axios, { AxiosResponse } from 'axios';
import { HttpClient, HttpRequest, HttpResponse } from '../../Data/Protocols/HttpClient';


export class AxiosHttpClient implements HttpClient {
    async request (data: HttpRequest): Promise<HttpResponse> {
        let axiosResponse: AxiosResponse;
        try {
            axiosResponse = await axios.request({
                url: data.url,
                method: data.method,
                data: data.body,
                headers: data.headers
            });
        } catch (error:any) {
            if (error.response){
                axiosResponse = error.response;
            }
            else {
                axiosResponse = error;
            }
            
        }
        return {
            statusCode: axiosResponse.status,
            body: axiosResponse.data
        };
    }
}
