import logo from '../../logo.svg';
import SearchBar from '../../Components/SearchBar';

import './styles.css';

const Home = () => {
    function handleSearch(textToSearch: string) {
        alert("cara buscou algo " + textToSearch);
    }

    return (
        <div id="home">
            <div id="logo">
                <img id="logo-img" src={logo} alt="logo"/>
            </div>

            <div id="searchbar">
                {/* <input type="text" placeholder="Digite o produto/serviço que deseja"/> */}
                <SearchBar onSearch={handleSearch}/>
            </div>
        </div>
    );
};

export default Home;