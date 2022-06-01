import * as IoIcons from "react-icons/io"
import * as CgIcons from "react-icons/cg"


export const SideBarData = [

    {
        title: 'Liste des virements',
        path: '/payment',
        icon: <IoIcons.IoIosListBox />,
        cName: 'nav-text'
    },
    {
        title: 'Liste des clients',
        path: '/client',
        icon: <CgIcons.CgUserList />,
        cName: 'nav-text'
    },
]
