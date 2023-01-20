import LogOutForm from 'modules/Autentication/LogOutForm/LogOutForm';
import Menu from 'modules/SysAdmin/Menu/MenuListForm';
import { Routes, Route } from 'react-router-dom';
import LoginForm from './modules/Autentication/LoginForm/LogInForm';
import { GetTokenFromStorage } from 'state/hooks/useToken';
import NavBar from 'components/NavBar/NavBar';
import MenuCreate from 'modules/SysAdmin/Menu/MenuCreateForm';

function App() {
    const token = GetTokenFromStorage();    
    
    if(!token) {
        return <LoginForm />;
    }

    return (
        <>
            <NavBar />   
            <Routes>                            
                <Route path="/" element={<Menu />} />   
                <Route path="/menu" element={<Menu />} />   
                <Route path="/menu_create" element={<MenuCreate />} />   
                <Route path="/login" element={<LoginForm />} />            
                <Route path="/logout" element={<LogOutForm />} />                        
            </Routes>
        </>
    );
}

export default App;
