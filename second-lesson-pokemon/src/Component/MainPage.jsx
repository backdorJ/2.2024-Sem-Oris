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
        const response = await fetch(`https://pokeapi.co/api/v2/pokemon?limit=20&offset=${offset}`);
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
        if (!pokemonsData) {
            fetching();
            setOffset(offset + 20)
        }
    }, [])

    useEffect(() => {
        console.log(`first ${offset} next: ${offset + 20}`)
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

    return (
        <div>
            <Header changeInputData={handleInputChange} />
            <Wrapper pokemonsData={pokemonsData} filterPoke={inputData} />
            {
                isLoadingAfterPokeData && <Loader />
            }
            <div ref={ref}>End</div>
        </div>
    );
};

export default MainPage;