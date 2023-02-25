import { CoreDTO } from '../../../Core/Infrastructure/Protocols/CoreDto';

export interface MenuDto extends CoreDTO {
    id?:number,
    name?:string,
    order?:number
}