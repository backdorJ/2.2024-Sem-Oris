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
    const [filteredData, setfilteredData] = useState([]);
    const [isClick, setIsClick] = useState(false)
    const [offset, setOffset] = useState(1);
    const [_, fetching] = useFetchingPoke(async () => {
        const response = await fetch(`https://localhost:44343/api/Pokemon?pageSize=30&pageNumber=${offset}`);
        const data = await response.json();
        setPokemons([...data.entities]);
        setMaxCountPoke(data.totalCount)
    });
    const { ref, inView } = useInView({
        threshold: 0.5,
    });

    const [isLoadingAfterPokeData, fetchingPokeData] = useFetchingPoke(async () => {
        const promises = pokemons.map(async (item, _) => {
            const response = await fetch(`https://localhost:44343/api/Pokemon/${item.name}`);
            return response.json();
        });
        const newData = await Promise.all(promises);
        setPokemonsData([...pokemonsData, ...newData]);
    });

    const handleInputChange = (value) => {
        setInputData(value);
    };

    const handleClickButtonSearch = async (value) => {
        const response = await fetch(`https://localhost:44343/api/Pokemon/${value}`)
        const data = await response.json();
        setPokemonsData([])
        setPokemonsData([data])
        setIsClick(true)
    }

    useEffect(() => {
        if (pokemons.length === 0)
        {
            fetching();
            setOffset(offset + 1)
        }
    }, []);

    useEffect(() => {
        if (!pokemonsData) {
            fetching();
            setOffset(offset + 1)
        }
    }, [])

    useEffect(() => {
        if (inView && pokemonsData && (offset <= maxCountPoke)) {
            fetching()
            setOffset(offset + 1)
        }
    }, [inView]);

    useEffect(() => {
        if (pokemons) {
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
            <Header changeInputData={handleInputChange} clickSearch={handleClickButtonSearch}/>
            <Wrapper pokemonsData={pokemonsData} filterPoke={inputData} isClick={isClick}/>
            {
                isLoadingAfterPokeData && <Loader />
            }
            <div className="end__for__pagination" ref={ref}>z</div>
        </div>
    );
};

export default MainPage;