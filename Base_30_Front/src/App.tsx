import { Routes, Route } from 'react-router-dom';
import { LoginFactory } from './Authentication/Main/Factory/Factories/Pages/LoginFactory';
import NavBar from './Core/Presentation/Components/NavBar/NavBar';
import { MakeLocalStorage } from './Core/Main/Factories/MakeLocalStorage';
import { LogOutFactory } from './Authentication/Main/Factory/Factories/Pages/LogOutFactory';
import { MenuFactory } from './SysAdmin/Main/Factories/Menu/Page/MenuFactory';
import { MenuListFactory } from './SysAdmin/Main/Factories/Menu/Page/MenuListFactory';
import Home from './Core/Presentation/Pages/home/home';
  
function App() {
    const userAccount = MakeLocalStorage().getStorage('accountUser');    

    
    if(!userAccount) return <LoginFactory  />;
    
    return (
        <>
            <NavBar />   
            <Routes>                                            
                <Route path="/" element={<Home />} />   
                <Route path="/login" element={<LoginFactory />} />            
                <Route path="/logout" element={<LogOutFactory />} />                        
                <Route path="/menu" element={<MenuListFactory />} />   
                <Route path="/menu_create" element={<MenuFactory />} />   
            </Routes>
        </>
    );
}

export default App;
