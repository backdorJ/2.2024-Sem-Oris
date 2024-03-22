import './Card'
import '../css/Wrapper.css'
import React from "react";
import Card from "./Card";
import NotFound from "./NotFound";

const Wrapper = ({pokemonsData, filterPoke, isClick}) => {

    if (isClick === true && filterPoke === '')
        return <NotFound />

    let filteredData = pokemonsData
        .filter((item) =>
            filterPoke === ''
            || (item.name && item.name.includes(filterPoke))
            || item.name.toLowerCase() === filterPoke.toLowerCase());

    console.log(filteredData)

    if (filteredData === undefined)
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