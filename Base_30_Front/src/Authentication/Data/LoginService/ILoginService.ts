import { LoginDTO } from '../../Model/Dto/LoginDto';
import { UserDTO } from '../../Model/Dto/UserDto';

export interface ILoginService {
    Login(loginDto: LoginDTO): Promise<UserDTO>
}