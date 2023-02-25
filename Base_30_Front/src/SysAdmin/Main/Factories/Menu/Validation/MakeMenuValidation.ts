import { ValidationBuilder } from '../../../../../Core/Validation/Builder/ValidationBuilder';
import { ValidationComposite } from '../../../../../Core/Validation/Composite/ValidationComposite';

export const MakeMenuValidation = (): ValidationComposite => ValidationComposite.build([    
    ...ValidationBuilder.field('name').required().build(),
    ...ValidationBuilder.field('order').required().build()
]);