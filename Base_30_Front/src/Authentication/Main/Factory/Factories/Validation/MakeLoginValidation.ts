import { ValidationBuilder } from '../../../../../Core/Validation/Builder/ValidationBuilder';
import { ValidationComposite } from '../../../../../Core/Validation/Composite/ValidationComposite';

export const MakeLoginValidation = (): ValidationComposite => ValidationComposite.build([    
    ...ValidationBuilder.field('email').required().email().build(),
    ...ValidationBuilder.field('password').required().build()
]);