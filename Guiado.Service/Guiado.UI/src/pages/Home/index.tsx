import AppTopbar from '../../Components/AppTopBar';
import AppFooter from '../../Components/AppFooter';

import logo from '../../logo.svg';
import './styles.css';

const Home = () => {
    return (
        <div id="home">
            <header>
                <AppTopbar isHidden={false} onToggleMenu={() => null} />
            </header>

            <body className="App-header">
                <img src={logo} alt="logo" height="auto" width="1290"/>
                {/* <img src={logo} className="App-logo" alt="logo" />
                <p> Edit <code>src/App.tsx</code> and save to reload.</p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer">
                    Learn React
                </a>     */}
            </body>

            <footer>
                <AppFooter />
            </footer>
        </div>
    );
};

export default Home;