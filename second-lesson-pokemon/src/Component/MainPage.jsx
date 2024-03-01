import React, {useEffect, useState} from 'react';
import {useFetchingPoke} from "../hooks/useFetchingPoke";
import {useInView} from "react-intersection-observer";
import Header from "./Header";
import Wrapper from "./Wrapper";
import Loader from "./Loader/Loader";

const MainPage = () => {
    const [pokemons, setPokemons] = useState([]);
    const [inputData, setInputData] = useState('');
    const [maxCountPoke, setMaxCountPoke] = useState(0)
    const [pokemonsData, setPokemonsData] = useState([]);
    const [offset, setOffset] = useState(0);
    const [_, fetching] = useFetchingPoke(async () => {
        const response = await fetch(`https://pokeapi.co/api/v2/pokemon?limit=30&offset=${offset}`);
        const data = await response.json();
        setPokemons([...data.results]);
        setMaxCountPoke(data.count)
    });
    const { ref, inView } = useInView({
        threshold: 0.5,
    });

    const [isLoadingAfterPokeData, fetchingPokeData] = useFetchingPoke(async () => {
        const promises = pokemons.map(async (item, _) => {
            const response = await fetch(item.url);
            return response.json();
        });
        const newData = await Promise.all(promises);
        setPokemonsData([...pokemonsData, ...newData]);
    });

    const handleInputChange = (value) => {
        setInputData(value);
    };

    useEffect(() => {
        if (pokemons.length === 0)
        {
            fetching();
            setOffset(offset + 20)
        }
    }, []);

    useEffect(() => {
        if (!pokemonsData) {
            fetching();
            setOffset(offset + 20)
        }
    }, [])

    useEffect(() => {
        if (inView && pokemonsData && (offset <= maxCountPoke) && inputData === '') {
            fetching()
            setOffset(offset + 20)
        }
    }, [inView]);

    useEffect(() => {
        if (pokemons && inputData === '') {
            fetchingPokeData();
        }
    }, [pokemons]);

    useEffect(() => {
        let endElement = document.querySelector('.end__for__pagination');
        endElement.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
        if (endElement !== undefined) {
            endElement.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
        }
    }, [])

    return (
        <div>
            <Header changeInputData={handleInputChange} />
            <Wrapper pokemonsData={pokemonsData} filterPoke={inputData} />
            {
                isLoadingAfterPokeData && <Loader />
            }
            <div className="end__for__pagination" ref={ref}>z</div>
        </div>
    );
};

export default MainPage;