import React from "react";
import '../css/NotFound.css'

const NotFound = () => {
    return (
        <div className="wrapper">
            <div className="wrapper__not_found">
                <h2 className="wrapper__not_found_title">Oops! Try again.</h2>
                <p className="wrapper_not_found_description">The Pokemon you`re looking for is a unicorn. It doesn`t exist is this list</p>
                <img className="wrapper_not_found_img" src="./img/Pikachu.png" alt=""/>
            </div>
        </div>
    )
}

export default NotFound;