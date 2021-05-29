import React, { MouseEvent, useState } from 'react';
import classNames from 'classnames';
import { FiSettings, FiUser, FiLogOut } from 'react-icons/fi';
import { CSSTransition } from 'react-transition-group';
import userIcon from '../assets/profile.png'

import '../layouts/Profile.scss';

const AppProfile = () => {

    const [expanded, setExpanded] = useState(false);

    const onClick = (event: MouseEvent) => {
        setExpanded(prevState => !prevState);
        event.preventDefault();
    }

    return (
        <div className="layout-profile">
            <div>
                <img src={userIcon} alt="Profile" />
            </div>
            <button className="link layout-profile-link" onClick={o => onClick(o)}>
                <span>Claire Williams</span>
                <FiSettings className="profile-config-icon" />
            </button>
            <CSSTransition classNames="toggleable-content" timeout={{ enter: 1000, exit: 450 }} in={expanded} unmountOnExit>
                <ul className={classNames({ 'layout-profile-expanded': expanded })}>
                    <li>
                        <button type="button" className="link">
                            <FiUser className="profile-config-icon"/>
                            <span>Preferences</span>
                        </button>
                    </li>
                    <li>
                        <button type="button" className="link">
                            <FiLogOut className="profile-config-icon"/>
                            <span>Logout</span>
                        </button>
                    </li>
                </ul>
            </CSSTransition>
        </div>
    );

}

export default AppProfile;