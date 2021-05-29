import React, { MouseEventHandler } from 'react';
import ReactTooltip from 'react-tooltip';
import { AiOutlineMenu } from 'react-icons/ai';

import '../layouts/AppTopBar.scss';

interface AppTopBarProperties {
    onToggleMenu: MouseEventHandler<HTMLButtonElement>
}

const AppTopbar: React.FC<AppTopBarProperties> = (props) => {
    return (
        <div className="layout-topbar">
            <button className="layout-menu-button"
                    type="button"
                    data-tip='Menu'
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