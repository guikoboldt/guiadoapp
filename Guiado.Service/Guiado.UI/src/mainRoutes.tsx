import React from 'react';
import { Route, BrowserRouter } from 'react-router-dom';
import Main from './pages/Main';

const MainRoutes = () => {
    return (
        <BrowserRouter>
            <Route exact path="/" component={Main} />
        </BrowserRouter>
    );
}

export default MainRoutes;