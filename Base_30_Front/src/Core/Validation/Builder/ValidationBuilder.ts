import { EmailValidation } from '../../../Core/Validation/Validators/EmailValidation';
import { RequiredFieldValidation } from '../../../Core/Validation/Validators/RequiredFieldValidation';
import { FieldValidation } from '../Protocols/FieldValidation';

export class ValidationBuilder {
    private fieldName: string;
    private validations: Array<FieldValidation> = [];
    
    public constructor (
        fieldName: string, validations: FieldValidation[]
    ) {
        this.fieldName = fieldName;
        this.validations = validations;
    }

    static field (fieldName: string): ValidationBuilder {
        return new ValidationBuilder(fieldName, []);        
    }
    
    email (): ValidationBuilder {
        this.validations.push(new EmailValidation(this.fieldName));
        return this;
    }
    
    required (): ValidationBuilder {
        this.validations.push(new RequiredFieldValidation(this.fieldName));
        return this;
    }
    
    rules(validations: Array<FieldValidation>): ValidationBuilder {
        this.validations = this.validations.concat(validations);
        return this;
    }

    build (): Array<FieldValidation> {
        return this.validations;
    }
}
