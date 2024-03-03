import React from 'react';
import classes from "./CardInfo.module.css";

const Abilities = ({abilities}) => {
    return (
        <div className={classes.card__abilities}>
            <div className={classes.card__abilities__title}>
                <p>Abilities</p>
            </div>
            <div className={classes.card__abilities__blocks}>
                <div className={classes.card__abilities__block}>
                    <div className={classes.card__abilities__wrapper__img}>
                        <div className={classes.card__abilities__img}>
                            <span style={{color: "#FDD85D", fontWeight: 400}}>{abilities[0]?.ability?.name.charAt(0).toUpperCase()}</span>
                        </div>
                    </div>
                    <div className={classes.card__abilities__block_title}>
                        <p>{abilities[0]?.ability?.name.charAt(0).toUpperCase() + abilities[0]?.ability?.name.slice(1)}</p>
                    </div>
                </div>
                {
                    abilities[1]?.ability?.name &&
                    <div className={classes.card__abilities__block_2}>
                        <div className={classes.card__abilities__wrapper__img}>
                            <div className={classes.card__abilities__img}>
                                <span style={{color: "#FF844F", fontWeight: 400}}>{abilities[1]?.ability?.name.charAt(0).toUpperCase()}</span>
                            </div>
                        </div>
                        <div className={classes.card__abilities__block_title}>
                            <p>{abilities[1]?.ability?.name.charAt(0).toUpperCase() + abilities[1]?.ability?.name.slice(1)}</p>
                        </div>
                    </div>
                }
            </div>
        </div>
    );
};

export default Abilities;