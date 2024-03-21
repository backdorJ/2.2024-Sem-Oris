import classes from "./CardInfo.module.css";
import {ColorFilter} from "../../../Services/ColorFilter";

const CardPokeInfo = ({poke, stats}) => {
    return (
        <div className={classes.card}>
            <div className={classes.card__header}>
                <div className={classes.card__header__title}>
                    <span>{`#${poke?.order.toString().padStart(3, '0')}`}</span>
                    <p>{poke?.name.charAt(0).toUpperCase() + poke?.name.slice(1)}</p>
                </div>
                <div>
                    {
                        poke?.types.map((item, index) => {
                            return <button
                                style={{backgroundColor: `${ColorFilter.getColorByName(item.name)}`}}
                                className={classes.card__header__title__btns}
                                key={index}>
                                {item?.name}
                            </button>
                        })
                    }
                </div>
            </div>
            <div className={classes.card__body}>
                <div className={classes.card__body_statistics}>
                    <p style={{marginBottom: 5, fontWeight: 400}}>HP</p>
                    <div className={classes.card__body__progress__green}>
                        <div
                            className={classes.card__body__progress_bar}
                            style={{width: `${stats[0]?.value}px`, backgroundColor: "#0FC06F"}}></div>
                    </div>
                    <p style={{marginBottom: 5, fontWeight: 400}}>Attack</p>
                    <div className={classes.card__body__progress__attack}>
                        <div
                            className={classes.card__body__progress_bar}
                            style={{width: `${stats[1]?.value}px`, backgroundColor: "#EE3F2D"}}></div>
                    </div>
                    <p style={{marginBottom: 5, fontWeight: 400}}>Defense</p>
                    <div className={classes.card__body__progress__defense}>
                        <div
                            className={classes.card__body__progress_bar}
                            style={{width: `${stats[2]?.value}px`, backgroundColor: "#FAD355"}}></div>
                    </div>
                    <p style={{marginBottom: 5, fontWeight: 400}}>Speed</p>
                    <div className={classes.card__body__progress__speed}>
                        <div
                            className={classes.card__body__progress_bar}
                            style={{width: `${stats[3]?.value}px`, backgroundColor: "#FE8B56"}}></div>
                    </div>
                </div>
                <div className={classes.card__body__image}>
                    <img src={poke?.imageUrl} alt=""/>
                </div>
            </div>
            <div className={classes.card__footer}></div>
        </div>
    )
}

export default CardPokeInfo;