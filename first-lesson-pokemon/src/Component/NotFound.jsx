import React from "react";

const notFound = () => {
    return (
        <div className="wrapper__not_found">
            <h2 className="wrapper__not_found_title">Oops! Try again.</h2>
            <p className="wrapper_not_found_description">The Pokemon you`re looking for is a unicorn. It doesn`t exist is this list</p>
            <img className="wrapper_not_found_img" src="./img/Pikachu.png" alt=""/>
        </div>
    )
}

export default notFound;