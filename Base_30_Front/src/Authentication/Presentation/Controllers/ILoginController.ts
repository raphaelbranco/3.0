import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';

export interface ILoginController {    
    HandleSubmit(event: React.FormEvent<HTMLFormElement>, 
        email: InputValidation,
        password: InputValidation
    ): Promise<string>
    
    HandleFieldChange(fieldName:string, field: Record<string, unknown>, setError: React.Dispatch<React.SetStateAction<string>>):void;
}