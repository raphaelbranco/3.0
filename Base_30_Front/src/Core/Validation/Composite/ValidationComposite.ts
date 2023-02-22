import { FieldValidation } from '../Protocols/FieldValidation';
import { InputValidation } from '../Protocols/InputListValidation';
import { IValidationComposite } from './IValidationComposite';

export class ValidationComposite implements IValidationComposite {
    private readonly validations: FieldValidation[];

    public constructor(validations: FieldValidation[]) {
        this.validations = validations;
    }

    static build(validations: FieldValidation[]): ValidationComposite {
        return new ValidationComposite(validations);
    }

    public validate(fieldName: string, input: Record<string, unknown>): Error | null {
        const validators = this.validations.filter(v => v.fieldName === fieldName);
        for (const validation of validators) {
            const error = validation.validate(input);
            if (error) {
                return error;
            }
        }
        return null;
    }
    
    public validateAll(inputList:InputValidation[]): Error | null {
        for (const input of inputList) {
            const error = this.validate(input.fieldName, input.input);
            if (error) return error;
        }
        
        return null;
    }
}