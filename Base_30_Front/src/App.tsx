import { Routes, Route } from 'react-router-dom';
import { LoginFactory } from './Authentication/Main/Factory/Factories/Pages/LoginFactory';
import NavBar from './Core/Presentation/Components/NavBar/NavBar';
import MenuCreate from './Core/Presentation/Menu/MenuCreateForm';
import MenuList from './Core/Presentation/Menu/MenuListForm';
import { MakeLocalStorage } from './Core/Main/Factories/MakeLocalStorage';
import { LogOutFactory } from './Authentication/Main/Factory/Factories/Pages/LogOutFactory';
  
function App() {
    const userAccount = MakeLocalStorage().getStorage('accountUser');    

    if(!userAccount) return <LoginFactory  />;
    
    return (
        <>
            <NavBar />   
            <Routes>                                            
                <Route path="/" element={<MenuList />} />   
                <Route path="/login" element={<LoginFactory />} />            
                <Route path="/logout" element={<LogOutFactory />} />                        

                <Route path="/menu" element={<MenuList />} />   
                <Route path="/menu_create" element={<MenuCreate />} />   
            </Routes>
        </>
    );
}

export default App;
