import { EndpointType } from '../../../Core/Infrastructure/Protocols/IEndpointParams';
import { ISysAdminEndpoints } from './ISysAdminEndpoints';

export class SysAdminEndpoints implements ISysAdminEndpoints {
    public baseUrl:string = 'https://localhost:7136';

    getCreateUrl(): EndpointType {
        return {
            method: 'post',
            url: this.baseUrl + '/Menu'
        };        
    }
    getUpdateUrl(): EndpointType {
        return {
            method: 'put',
            url: this.baseUrl + '/Menu'
        }; 
    }
    getGetAllUrl(): EndpointType {
        return {
            method: 'get',
            url: this.baseUrl + '/Menu'
        }; 
    }

    
}