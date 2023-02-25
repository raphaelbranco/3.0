import i18next from 'i18next';
import { InputValidation } from '../../../Core/Validation/Protocols/InputListValidation';
import { IMenuService } from '../../Data/MenuService/IMenuService';
import { MenuDto } from '../../Domain/Menu/MenuDto';
import { IMenuValidation } from '../Validation/IMenuValidation';
import { IMenuController } from './IMenuController';

export class MenuController implements IMenuController {
    private _menuValidation: IMenuValidation;
    private _menuService: IMenuService;
    
    constructor(
        menuValidation: IMenuValidation, 
        menuService: IMenuService,
    ) {
        this._menuValidation = menuValidation;
        this._menuService = menuService;
    }    

    public async HandleSubmit(
        event: React.FormEvent<HTMLFormElement>,         
        name: InputValidation,
        order: InputValidation,
        id?: InputValidation
    ): Promise<string> {

        event.preventDefault();

        if (!this._menuValidation.ValidateForm(name, order, id)) return 'InvalidFieldsCompletion';

        const menuDto:MenuDto = {
            name: name.input['name'] as string,
            order: order.input['order'] as number,
            id: order.input['id'] as number
        };

        if (!id) return await this.Create(menuDto);
        
        return await this.Update(menuDto);
    }

    public HandleFieldChange(fieldName:string, field: Record<string, unknown>, setError: React.Dispatch<React.SetStateAction<string>>):void {
        setError('');
        const error = this._menuValidation.ValidateField(fieldName, field);        
        if (error) {            
            const errorTranslate = i18next.t(`error.${error?.message}`, { defaultValue: i18next.t('error.unspecific') });            
            setError(errorTranslate);
        }
    }
    
    private async Create(menuDto: MenuDto): Promise<string> {
        if (await this._menuService.Create(menuDto)) return '';        
        return 'unspecific';
    }

    private async Update(menuDto: MenuDto): Promise<string> {
        if (await this._menuService.Update(menuDto)) return '';        
        return 'unspecific';
    }

    
}