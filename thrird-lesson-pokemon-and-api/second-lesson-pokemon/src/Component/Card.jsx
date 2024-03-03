import {Link} from "react-router-dom";
import {ColorFilter} from "../Services/ColorFilter";

const Card = ({name, id, btns, img}) => {
    return (
        <Link to={`/poke-info/${name}`}>
            <div className="card">
                <div className="card__header">
                    <p className="card__header__name">{name.charAt(0).toUpperCase() + name.slice(1)}</p>
                    <p className="card__header__number">{`#${id.toString().padStart(3, '0')}`}</p>
                </div>
                <div className="card__body">
                    <img className="card__body__image" src={`${img}`} alt=""/>
                </div>
                <div className="card__footer">
                    {
                        btns.map((x, index) => {
                            return(
                            <button
                                key={index}
                                className="card__footer__btn"
                                style={{backgroundColor: `${ColorFilter.getColorByName(x.type.name.toLowerCase())}`}}>
                                {x.type.name}
                            </button>)
                        })
                    }
                </div>
            </div>
        </Link>
    )
}

export default Card;