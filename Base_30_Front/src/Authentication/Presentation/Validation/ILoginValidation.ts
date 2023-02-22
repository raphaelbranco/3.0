import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';

export interface ILoginValidation {
    ValidateForm(email: InputValidation,password: InputValidation): boolean;    
    ValidateField(fieldName:string, field: Record<string, unknown>): Error | null;   
}