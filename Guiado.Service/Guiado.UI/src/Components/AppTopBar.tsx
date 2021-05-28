import React, { MouseEventHandler } from 'react';
import ReactTooltip from 'react-tooltip';
import { AiOutlineMenu } from 'react-icons/ai';

import '../layouts/AppTopBar.scss';

interface AppTopBarProperties {
    isHidden: boolean,
    onToggleMenu: MouseEventHandler<HTMLButtonElement>
}

const AppTopbar: React.FC<AppTopBarProperties> = (props) => {
    return (
        <div id="appTopBar-layout">
            <button id="appTopBar-menu-button"
                    type="button"
                    data-tip='Menu'
                    hidden={props.isHidden}
                    onClick={props.onToggleMenu}>
                <ReactTooltip />
                <span>
                    <AiOutlineMenu />
                </span>
            </button>
        </div>
    );
}

export default AppTopbar;