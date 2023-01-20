import axios from 'axios';

const AuthenticationApi = axios.create({
    baseURL: 'https://localhost:7289/'
});

export default AuthenticationApi;