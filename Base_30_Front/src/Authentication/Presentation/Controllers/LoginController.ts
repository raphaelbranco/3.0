import { ILoginController } from './ILoginController';
import { ILoginValidation } from '../Validation/ILoginValidation';
import { ILoginService } from '../../Data/LoginService/ILoginService';
import { InputValidation } from '@/src/Core/Validation/Protocols/InputListValidation';
import { LoginDTO } from '../../Domain/Dto/LoginDto';
import { UserDTO } from '../../Domain/Dto/UserDto';
import { ILocalStorage } from '@/src/Core/Infrastructure/Cache/ILocalStorage';
import i18next from 'i18next';

export class LoginController implements ILoginController{
    private _loginValidation: ILoginValidation;
    private _loginService: ILoginService;
    private _localStorage: ILocalStorage;

    private loginDto:LoginDTO = {
        email: '',
        password: '',
        errorMessage: ''
    };

    constructor(
        loginValidation: ILoginValidation, 
        loginService: ILoginService,
        localStorage: ILocalStorage
    ) {
        this._loginValidation = loginValidation;
        this._loginService = loginService;
        this._localStorage = localStorage;
    }    

    public async HandleSubmit(
        event: React.FormEvent<HTMLFormElement>,         
        email: InputValidation,
        password: InputValidation        
    ): Promise<string> {

        event.preventDefault();
        this.loginDto = this.ValidateForm(email, password);
        if (this.loginDto.errorMessage) return this.loginDto.errorMessage;
        
        const userDto:UserDTO = await this.Login(email, password);
        if (userDto.error) return userDto.error;

        return '';
    }

    public HandleFieldChange(fieldName:string, field: Record<string, unknown>, setError: React.Dispatch<React.SetStateAction<string>>):void {
        setError('');
        const error = this._loginValidation.ValidateField(fieldName, field);        
        if (error) {            
            const errorTranslate = i18next.t(`error.${error?.message}`, { defaultValue: i18next.t('error.unspecific') });            
            setError(errorTranslate);
        }
    }

    private ValidateForm(
        email: InputValidation,
        password: InputValidation
    ): LoginDTO {

        if (!this._loginValidation.ValidateForm(email, password)) {
            this.loginDto.errorMessage = 'InvalidFieldsCompletion';
            return this.loginDto;
        }
        this.loginDto.errorMessage = '';
        return this.loginDto;
    }

    private async Login(
        email: InputValidation,
        password: InputValidation
    ): Promise<UserDTO> {        

        this.loginDto = {
            email: email.input['email'] as string,
            password: password.input['password'] as string,
            errorMessage: ''
        };
        
        const userDTO:UserDTO = await this._loginService.Login(this.loginDto);

        if (userDTO.error != '') {
            this.loginDto.errorMessage = userDTO.error;
        }

        //Set on Storage
        this._localStorage.setStorage('accountUser', userDTO);

        return userDTO;
    }

}