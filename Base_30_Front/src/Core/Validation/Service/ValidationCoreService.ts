import { IValidationComposite } from '../Composite/IValidationComposite';

export class ValidationCoreService {
    public _validation: IValidationComposite;

    constructor(validation: IValidationComposite) {
        this._validation = validation;
    } 
    
    public ValidateField(fieldName:string, field: Record<string, unknown>): Error | null {
        return this._validation.validate(fieldName, field);
    }   

}