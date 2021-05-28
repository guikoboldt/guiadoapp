import React from 'react';
import logo from '../assets/logo.svg';

import '../layouts/AppFooter.scss';

const AppFooter = () => {

    return (
        <div id="appFooter-layout">
            <img src={logo} alt="Logo" width="80" />
            <span id="footer-text" style={{ 'marginLeft': '5px' }}>GUIADO APP</span>
        </div>
    );
}

export default AppFooter;