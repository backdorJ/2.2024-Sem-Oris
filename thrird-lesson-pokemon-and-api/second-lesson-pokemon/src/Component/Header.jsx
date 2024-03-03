import '../css/Header.css'
import {useState} from "react";

const Header = ({ changeInputData }) => {

    const [inputData, setInputData] = useState('')

    const applyChangeData = (e) => {
        changeInputData(e.target.value);
    }

    return (
        <header className="header">
            <h1 className="header__title-name">Who are you looking for?</h1>
            <div className="header__search-wrapper">
                <div clasName="header__search">
                    <div className="header__form">
                        <input
                            id="my__input__data"
                            className="header__input-place"
                            type="text"
                            onChange={applyChangeData}
                            placeholder="E.g. Pikachu"/>
                        <button
                            className="header__button"
                            type="submit">Go</button>
                    </div>
                </div>
            </div>
        </header>
    )
}

export default Header;