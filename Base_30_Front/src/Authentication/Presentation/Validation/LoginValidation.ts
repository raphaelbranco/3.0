import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';
import { ValidationCoreService } from '../../../Core/Validation/Service/ValidationCoreService';
import { ILoginValidation } from './ILoginValidation';

export class LoginValidation extends ValidationCoreService implements ILoginValidation {
      
    public ValidateForm(
        email: InputValidation,
        password: InputValidation)
        : boolean{

        const fieldList:Array<InputValidation> = [];
        fieldList.push(email);
        fieldList.push(password);

        const error = this._validation.validateAll(fieldList);
        if (error) return false;
        return true;
    }
    
    

}