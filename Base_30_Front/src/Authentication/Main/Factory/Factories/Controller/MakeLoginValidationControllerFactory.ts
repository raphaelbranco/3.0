import { ILoginValidation } from '../../../../Presentation/Validation/ILoginValidation';
import { LoginValidation } from '../../../../Presentation/Validation/LoginValidation';
import { MakeLoginValidation } from '../Validation/MakeLoginValidation';

export const  MakeLoginValidationControllerFactory = ():ILoginValidation => 
    new LoginValidation(MakeLoginValidation());
