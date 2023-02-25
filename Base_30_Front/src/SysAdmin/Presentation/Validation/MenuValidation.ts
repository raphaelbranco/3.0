import { InputValidation } from '../../../Core/Validation/Protocols/InputListValidation';
import { ValidationCoreService } from '../../../Core/Validation/Service/ValidationCoreService';
import { IMenuValidation } from './IMenuValidation';

export class MenuValidation  extends ValidationCoreService implements IMenuValidation {
    ValidateForm(
        name: InputValidation, 
        order: InputValidation, 
        id?: InputValidation | undefined): boolean {
        
        const fieldList:Array<InputValidation> = [];
        fieldList.push(name);
        fieldList.push(order);

        if (id) fieldList.push(id);

        const error = this._validation.validateAll(fieldList);
        if (error) return false;
        return true;
    }
    
}