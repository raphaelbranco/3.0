import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';

export interface IMenuValidation {
    ValidateForm(name: InputValidation,order: InputValidation, id?:InputValidation): boolean;    
    ValidateField(fieldName:string, field: Record<string, unknown>): Error | null;   
}
