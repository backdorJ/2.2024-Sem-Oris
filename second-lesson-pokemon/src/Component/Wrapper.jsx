import './Card'
import '../css/Wrapper.css'
import React from "react";
import Card from "./Card";
import NotFound from "./NotFound";

const Wrapper = ({pokemonsData, filterPoke}) => {
    let filteredData = pokemonsData
        .filter((item) => {
            // Добавляем проверку на item, чтобы избежать ошибки при обращении к свойству name
            if (!item) {
                return false;
            }
            return (
                item.species.name.toLowerCase().includes(filterPoke.toLowerCase())
                || item.id === filterPoke
                || item.species.name === filterPoke
            );
        });

    if (filteredData.length === 0)
        return <NotFound />

    return (
        <div className="wrapper">
            {
                filteredData.map((item, _) => {
                    // Добавляем дополнительную проверку на item, чтобы избежать ошибки при обращении к свойствам item
                    if (!item) {
                        return null;
                    }
                    return (
                        <Card
                            img={item.sprites.other.home.front_shiny}
                            key={item.id}
                            name={item.species.name}
                            id={item.id}
                            btns={item.types}
                        />
                    );
                })
            }
        </div>
    )
}

export default Wrapper;