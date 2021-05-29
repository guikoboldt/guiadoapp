import React, { useState, ChangeEvent }  from 'react';
import { FcSearch } from 'react-icons/fc';

import '../layouts/SearchBar.css';

interface SearchBarProps {
    onSearch(text: string) : void;
};

const SearchBar: React.FC<SearchBarProps> = (props)  => {

    const [textToSearch, setTextToSearch] = useState("");

    function handleInputSearchChange(event: ChangeEvent<HTMLInputElement>)
    {
        const { value } = event.target;
        setTextToSearch(value);
    }

    function onKeyPressed(key: string) {
        if(key === "Enter" )
        {
            props.onSearch(textToSearch);
        }
    }

    return (
        <div className="home">
            <input
                placeholder="O que deseja encontrar?" 
                onKeyPress={e => onKeyPressed(e.key)}
                onChange={handleInputSearchChange} />
            <FcSearch className="glass" onClick={() => props.onSearch(textToSearch)}/>
        </div>
    );
};

export default SearchBar;