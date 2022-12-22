import { Routes, Route } from 'react-router-dom';
import Home from './shared/modules/home/home';
import AdminBasePage from './modules/SysAdmin/BasePage/BasePage';
import Menu from './modules/SysAdmin/Menu/Menu';

function App() {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            
            <Route path='/admin' element={<AdminBasePage />} />
            <Route path="/admin/menu" element={<Menu />} />

        </Routes>
    );
}

export default App;
