import './Card'
import '../css/Wrapper.css'
import React from "react";
import Card from "./Card";
import NotFound from "./NotFound";

const Wrapper = ({pokemonsData, filterPoke}) => {

    let filteredData = pokemonsData
        .filter((item) =>
            filterPoke === null
            || (item.name && item.name.includes(filterPoke))
            || item.name.toLowerCase() === filterPoke.toLowerCase());

    console.log(filteredData)

    if (pokemonsData.length === 0 && filterPoke !== '')
        return <NotFound />

    return (
        <div className="wrapper">
            {
                filteredData.map((item, _) => {
                    {
                        console.log(item.name)
                        return <Card
                            img={item.imageUrl}
                            key={item.id}
                            name={item.name}
                            id={item.order}
                            btns={item.types}/>
                    }
                })
            }
        </div>
    )
}

export default Wrapper;