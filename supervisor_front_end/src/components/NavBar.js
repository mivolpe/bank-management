import * as FaIcons from "react-icons/fa"
import * as AiIcons from "react-icons/ai"
import {Link} from "react-router-dom";
import {useState} from "react";
import {SideBarData} from "./SideBarData";
import '../style/NavBar.css'
import * as MdIcons from "react-icons/md";
import {useAuth} from "../hooks/UserContext";

function NavBar() {
    const [sidebar, setSideBar] = useState(false)
    const { logout } = useAuth()

    const showSideBar = () => setSideBar(prev => !prev)

    return (
        <>
            <div className="navbar">
                <Link to='#' className='menu-bars'>
                    <FaIcons.FaBars onClick={showSideBar}/>
                </Link>
            </div>
            <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
                <ul className='nav-menu-items' onClick={showSideBar}>
                    <li className="navbar-toggle">
                        <Link to="#" className='menu-bars'>
                            <AiIcons.AiOutlineClose />
                        </Link>
                    </li>
                    {SideBarData.map((item, index) => {
                        return (
                            <li key={index} className={item.cName}>
                                <Link to={item.path}>
                                    {item.icon}
                                    <span>{item.title}</span>
                                </Link>
                            </li>
                        )
                    })}
                    <li className="nav-text">
                        <Link to="/" >
                            <MdIcons.MdOutlineLogout />
                            <span onClick={logout}> {"Déconnexion"}</span>
                        </Link>
                    </li>
                </ul>
            </nav>
        </>
    )
}

export default NavBar;