// import React, { useState } from 'react';
// import classNames from 'classnames';
// import Routes from './routes';
// import AppTopbar from './Components/AppTopBar';
// import AppFooter from './Components/AppFooter';
// import AppProfile from './Components/AppProfile';
// import AppMenu, { MenuItem } from './Components/AppMenu';
// import { CSSTransition } from 'react-transition-group';
// import logo from './assets/logo.svg';

// import './App.css';
// import './layouts/SideBar.scss';
// import './layouts/responsive.scss';

// function App() {
//   const [menuClicked, setMenuClicked] = useState(false);

//   const onToggleMenu = () => {
//     setMenuClicked(previousState => !previousState);
//   }

//   const wrapperClass = classNames('layout-wrapper', {
//     'layout-sidebar-inactive': !menuClicked,
//   });

//   const menu: MenuItem[] = [
//     { label: 'Login', icon: 'pi pi-fw pi-home', to: '/login' },
//     { label: 'About', icon: 'pi pi-fw pi-home', to: '/about' },
//   ];

//   function onMenuItemClick(selectedItem: MenuItem) {
//     if (!selectedItem.items) {
//     }
//   };

//   return (    
//     <div id="home" className={wrapperClass}>
//         <div id="header-topbar">
//           <AppTopbar onToggleMenu={onToggleMenu} />
//           <CSSTransition classNames="layout-sidebar" timeout={{ enter: 200, exit: 200 }} in={menuClicked} unmountOnExit>
//               <div className="layout-sidebar-dark" onClick={onToggleMenu}>
//                   <div className="layout-logo" style={{cursor: 'pointer'}}>
//                       <img alt="Logo" src={logo} />
//                   </div>
//               <AppProfile />
//               <AppMenu MenuItems={menu} onItemClick={onMenuItemClick} />
//               </div>
//           </CSSTransition>
//         </div>

//         <body>  
//             <Routes />
//         </body>

//         <footer>
//             <AppFooter />
//         </footer>
//     </div>
//   );
// }


import MainRoutes from './mainRoutes';

function App() {
  return (
    <MainRoutes />
  );
};

export default App;
