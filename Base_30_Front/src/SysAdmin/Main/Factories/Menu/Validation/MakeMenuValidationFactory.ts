import { IMenuValidation } from '../../../../../SysAdmin/Presentation/Validation/IMenuValidation';
import { MenuValidation } from '../../../../../SysAdmin/Presentation/Validation/MenuValidation';
import { MakeMenuValidation } from './MakeMenuValidation';


export const  MakeMenuValidationFactory = ():IMenuValidation => 
    new MenuValidation(MakeMenuValidation());