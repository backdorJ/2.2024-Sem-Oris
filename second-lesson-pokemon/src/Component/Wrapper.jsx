import './Card'
import '../css/Wrapper.css'
import React from "react";
import Card from "./Card";
import NotFound from "./NotFound";

const Wrapper = ({pokemonsData, filterPoke}) => {
    let filteredData = pokemonsData
        .filter((item) =>
            item.species.name.includes(filterPoke)
            || item.id === filterPoke
            || item.species.name === filterPoke);

    console.log(filteredData)

    if (filteredData.length === 0)
        return <NotFound />

    return (
        <div className="wrapper">
            {
                filteredData.map((item, index) => {
                    {
                            return <Card
                                img={item.sprites.front_default}
                                key={item.id}
                                name={item.species.name}
                                id={item.id}
                                btns={item.types}/>
                    }
                })
            }
        </div>
    )
}

export default Wrapper;