import AuthenticationApi from '../https/AuthenticationApi';

function DoLogin(email, password){
    const data = { email, password };
    AuthenticationApi
        .post('Login', data)
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
}