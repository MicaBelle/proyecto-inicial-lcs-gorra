import React, {Component} from 'react'
import './topMenu.css';
import ResponsiveAppBar from '../navbar/navbar';

export default class Header extends Component {
    render(){
        return (
            <div className="header">
                <ResponsiveAppBar/>
            </div>
        )
    }
}