import { RequiredFieldError } from '../Errors/RequiredFieldError';
import { FieldValidation } from '../Protocols/FieldValidation';

export class RequiredFieldValidation implements FieldValidation {
    constructor (readonly fieldName: string) {}

    validate (input: Record<string, unknown>): Error | null {
        return input[this.fieldName] ? null : new RequiredFieldError();
    }
}
