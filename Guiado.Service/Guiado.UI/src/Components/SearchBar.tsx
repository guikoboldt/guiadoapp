import React from 'react';
import { FcSearch } from 'react-icons/fc';

import '../layouts/SearchBar.css';

const SearchBar = () => {
    return (
        <div className="home">
            {/* <input onChange={e => setQuery(e)} onKeyPress={e => handleKey(e)} autoFocus={true} /> */}
            <input autoFocus={true} placeholder="O que deseja encontrar?" />
            {/* <img onClick={search} className="glass" alt="magnifying glass" src={glass} /> */}
            <FcSearch className="glass" />
        </div>
    );
};

export default SearchBar;