import { LoginDTO } from '../../Domain/Dto/LoginDto';
import { UserDTO } from '../../Domain/Dto/UserDto';

export interface ILoginService {
    Login(loginDto: LoginDTO): Promise<UserDTO>
}