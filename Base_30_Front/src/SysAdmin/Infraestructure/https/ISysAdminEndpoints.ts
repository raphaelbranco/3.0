import { EndpointType } from '../../../Core/Infrastructure/Protocols/IEndpointParams';

export interface ISysAdminEndpoints {
    baseUrl:string
    getCreateUrl():EndpointType
    getUpdateUrl():EndpointType
    getGetAllUrl():EndpointType
}