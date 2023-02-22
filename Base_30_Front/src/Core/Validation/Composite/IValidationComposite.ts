import { InputValidation } from '../Protocols/InputListValidation';

export interface IValidationComposite {        
    validate: (fieldName: string, input: Record<string, unknown>) => Error | null
    validateAll: (inputList:InputValidation[]) => Error | null
  }
  