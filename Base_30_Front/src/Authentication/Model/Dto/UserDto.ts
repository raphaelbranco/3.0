export interface UserDTO {
    name: string;
    email: string;
    authenticated: boolean;
    token: string;
    error: string;
}