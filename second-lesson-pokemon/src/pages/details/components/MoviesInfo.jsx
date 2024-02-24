import React from 'react';
import classes from "./CardInfo.module.css";
import {ColorFilter} from "../../../Services/ColorFilter";

const MoviesInfo = ({poke}) => {
    const movies = poke?.moves?.slice(0, 6)

    return (
        <div className={classes.card__movies}>
            <div className={classes.card__breeding__title}>
                <p>Movies</p>
            </div>
            <div className={classes.card__movies__blocks}>
                {movies?.map((move, index) => {
                    return (
                        <div
                            className={classes.card__movies__block}
                            style={
                                {backgroundColor: `${ColorFilter.getColorByBlock(`card__movies__${index + 1}`)}`}}>
                                   <span
                                       className={classes.card__movies__block__title}>
                                       {move?.move?.name.charAt(0).toUpperCase() + move?.move?.name.slice(1)}
                                   </span>
                        </div>
                    )
                })}
            </div>
        </div>
    );
};

export default MoviesInfo;