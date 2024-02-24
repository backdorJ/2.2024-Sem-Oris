import '../css/Header.css'

const Header = ({ changeInputData }) => {

    const applyChangeData = (event) => {
        changeInputData(event.target.value)
    }

    return (
        <header className="header">
            <h1 className="header__title-name">Who are you looking for?</h1>
            <div className="header__search-wrapper">
                <div clasName="header__search">
                    <div className="header__form">
                        <input
                            className="header__input-place"
                            type="text"
                            placeholder="E.g. Pikachu"
                            onChange={applyChangeData}/>
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