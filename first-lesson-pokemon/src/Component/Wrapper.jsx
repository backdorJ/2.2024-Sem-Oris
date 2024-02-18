import './Card'
import '../css/wrapper.css'
import React from "react";
import Card from "./Card";
import NotFound from "./NotFound";

const Wrapper = ({pokemonsData, filterPoke}) => {
    let filteredData = pokemonsData
        .filter((item) =>
            item.species.name.startsWith(filterPoke)
            || item.id == filterPoke
            || item.species.name == filterPoke);

    return (
        <div className="wrapper">
            {
                filteredData.length === 0
                    ?
                    <NotFound />
                    : filteredData.map((item) => {
                        return <Card
                            name={item.species.name}
                            id={item.id}
                            btns={item.types}/>
                })
            }
        </div>
    )
}

export default Wrapper;