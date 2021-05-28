import React from 'react';
import Routes from './routes';
import AppTopbar from './Components/AppTopBar';
import AppFooter from './Components/AppFooter';

import './App.css';

function App() {
  return (
    <div id="home">
            <div id="header-topbar">
                  <AppTopbar isHidden={false} onToggleMenu={() => null} />
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
