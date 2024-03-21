import classes from "./CardInfo.module.css";

const BreedingInfo = ({ poke }) => {
    return (
        <div className={classes.card__breeding}>
            <div className={classes.card__breeding__title}>
                <p>Breeding</p>
            </div>
            <div className={classes.card__breeding__stat}>
                <div className={classes.card__breeding__stat__height}>
                    <div>
                        <h5>Height</h5>
                        <div className={classes.card__breeding__stat__height__table}>
                            <p>2,04</p>
                            <p>{poke?.breeding?.height.toString().length === 1
                                ? `0.${poke?.breeding?.height} m`
                                : `${poke?.breeding?.height.toString().slice(0, -1)}.${poke?.breeding?.height.toString().slice(-1)} m`}
                            </p>
                        </div>
                    </div>
                    <div>
                        <h5>Weight</h5>
                        <div className={classes.card__breeding__stat__height__table}>
                            <p>2,04</p>
                            <p>{(poke?.breeding?.weight / 10).toFixed(1)} kg</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default BreedingInfo;