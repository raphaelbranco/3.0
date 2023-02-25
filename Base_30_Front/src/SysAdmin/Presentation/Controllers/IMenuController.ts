import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';

export interface IMenuController {
    HandleSubmit(
        event: React.FormEvent<HTMLFormElement>,         
        name: InputValidation,
        order: InputValidation,
        id?: InputValidation
    ): Promise<string>
    HandleFieldChange(fieldName:string, field: Record<string, unknown>, setError: React.Dispatch<React.SetStateAction<string>>):void;
}