import { InvalidFieldError } from '../Errors/InvalidFieldError';
import { FieldValidation } from '../Protocols/FieldValidation';

export class EmailValidation implements FieldValidation {
    constructor (readonly fieldName: string) {}

    validate (input: Record<string, unknown>): Error | null {
        const emailRegex = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
        return (!input[this.fieldName] || emailRegex.test(input[this.fieldName] as string)) ? null : new InvalidFieldError();
    }
}