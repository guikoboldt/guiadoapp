import React, { useState, useRef } from 'react';
import classNames from 'classnames';
import Routes from '../../routes';
import AppTopbar from '../../Components/AppTopBar';
import AppFooter from '../../Components/AppFooter';
import AppProfile from '../../Components/AppProfile';
import AppMenu, { MenuItem } from '../../Components/AppMenu';
import { CSSTransition } from 'react-transition-group';
import logo from '../../assets/logo.svg';
import { FiLogIn, FiHelpCircle } from 'react-icons/fi';

import './styles.scss';
import '../../layouts/SideBar.scss';
import '../../layouts/responsive.scss';
import '../../layouts/Profile.scss';
import '../../layouts/AppMenu.scss';

function App() {
  const [menuClicked, setMenuClicked] = useState(false);
  const sidebar = useRef();

  const onToggleMenu = () => {
    setMenuClicked(previousState => !previousState);
  }

  const wrapperClass = classNames('layout-wrapper', {
    'layout-sidebar-inactive': !menuClicked,
  });

  const menu: MenuItem[] = [
    { label: 'Login', icon: FiLogIn, to: '/login' },
    { label: 'About', icon: FiHelpCircle, to: '/about' },
  ];

  function onMenuItemClick(selectedItem: MenuItem) {
    if (!selectedItem.items) {
    }
  };

  const sidebarClassName = classNames('layout-sidebar', {'layout-sidebar-dark': true});

  return (    
    <div id="home" className={wrapperClass}>
        <div id="header-topbar">
          <AppTopbar onToggleMenu={onToggleMenu} />
          <CSSTransition classNames="layout-sidebar" timeout={{ enter: 200, exit: 200 }} in={menuClicked} unmountOnExit>
              <div ref={sidebar.current} className={sidebarClassName}>
                    <div className="layout-logo" style={{cursor: 'pointer'}}>
                         <img alt="Logo" src={logo} />
                    </div>
                    <AppProfile />
                    <AppMenu MenuItems={menu} onItemClick={onMenuItemClick} />
              </div>
          </CSSTransition>
        </div>

        <body>  
            <Routes />
        </body>

        <footer>
            <AppFooter />
        </footer>
    </div>
  );
}

export default App;
