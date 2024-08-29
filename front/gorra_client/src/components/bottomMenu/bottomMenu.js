import React, {Component} from 'react';
import './bottomMenu.css';
import SimpleBottomNavigation from '../bottomNavigation/bottomNavigation';

export default class Footer extends Component {
    render(){
        return (
            <div className="footer">
                {this.props.children}
                <SimpleBottomNavigation/>
            </div>
        )
    }
}