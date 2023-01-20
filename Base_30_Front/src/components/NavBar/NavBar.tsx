import { Link } from 'react-router-dom';
import styles from './NavBar.module.scss';

const NavBar = () => {
    return (
        <nav className={styles.Link}>
            <ul>
                <li>
                    <Link to="/menu">Home</Link>
                </li>
                <li>
                    <Link to="/menu_create">Criar Menu</Link>
                </li>
                <li>
                    <Link to="/logout">LogOut</Link>
                </li>
            </ul>
        </nav>
    );
};

export default NavBar;