import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { CSSTransition } from 'react-transition-group';
import classNames from 'classnames';

import '../layouts/AppMenu.scss';
import { IconType } from 'react-icons';

export interface MenuItem {
    label: string;
    icon: IconType;
    to: string;
    items?: MenuItem[];
}

interface MenuProps {
    MenuItems: MenuItem[];
    onItemClick(selectedItem: MenuItem) : void;
}

interface AppSubMenu {
    MenuItems?: MenuItem[];
    onItemClick(selectedItem: MenuItem) : void;
    root: boolean;
    className: string;
}

const AppSubmenu: React.FC<AppSubMenu> = (props) => {

    const [activeIndex, setActiveIndex] = useState(1)

    const onMenuItemClick = (item: MenuItem, index: number) => {
        if (index === activeIndex)
            setActiveIndex(0);
        else
            setActiveIndex(index);

        props.onItemClick(item);
    }

    const renderLinkContent = (item: MenuItem) => {
        let submenuIcon = item.items && <i className="pi pi-fw pi-angle-down menuitem-toggle-icon"></i>;

        return (
            <React.Fragment>
                <item.icon className="menu-item-icon"/>
                <span>{item.label}</span>
                {submenuIcon}
            </React.Fragment>
        );
    }

    const renderLink = (item: MenuItem, i: number) => {
        let content = renderLinkContent(item);

        if (item.to) {
            return (
                <Link className="active-route" to={item.to} onClick={(e) => onMenuItemClick(item, i)}>
                    {content}
                </Link>
            )
        }
    }

    let items = props.MenuItems && props.MenuItems.map((item, i) => {
        let active = activeIndex === i;
        let styleClass = classNames({'active-menuitem': active && !item.to });

        return (
            <li className={styleClass} key={i}>
                {item.items && props.root === true && <div className='arrow'></div>}
                {renderLink(item, i)}
                <CSSTransition classNames="toggleable-content" timeout={{ enter: 1000, exit: 450 }} in={active} unmountOnExit>
                    <AppSubmenu MenuItems={item.items} onItemClick={props.onItemClick} className="" root={false}/>
                </CSSTransition>
            </li>
        );
    });

    return items ? <ul className={props.className}>{items}</ul> : null;
};

const AppMenu: React.FC<MenuProps> = (props) => {
    return (
        <div className="layout-menu-container">
            <AppSubmenu className="layout-menu" MenuItems={props.MenuItems} onItemClick={props.onItemClick} root={true} />
        </div>
    );
};

export default AppMenu;
