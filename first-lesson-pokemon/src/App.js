import './App.css';
import {useEffect, useState} from "react";
import Wrapper from "./Component/Wrapper";
function App()
{
    const [pokemons, setPokemons] = useState([]);
    const [inputData, setInputData] = useState('');
    const [pokemonsData, setPokemonsData] = useState([]);


    useEffect(() => {
        const fetchPokemons = async () => {
            try {
                const response = await fetch("https://pokeapi.co/api/v2/pokemon?limit=200");
                const data = await response.json();
                setPokemons(data.results);
            } catch (error) {
                console.error("Error fetching pokemons:", error);
            }
        };

        fetchPokemons();
    }, []);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const promises = pokemons.map(async item => {
                    const response = await fetch(item.url);
                    return response.json();
                });
                const data = await Promise.all(promises);
                setPokemonsData(data);
            } catch (error) {
                console.error("Error fetching pokemon data:", error);
            }
        };

        fetchData();
    }, [pokemons]);

    return (
        <div className="App">
            <header className="App-header">
                <h1 className="App-header__title-name">Who are you looking for?</h1>
                <div className="App-header__search-wrapper">
                    <div clasName="App-header__search">
                        <div className="App-header__form">
                            <input
                                className="App-header__input-place"
                                type="text"
                                placeholder="E.g. Pikachu"
                                onChange={(event) => setInputData(event.target.value)}/>
                            <button
                                className="App-header__button"
                                type="submit">Go</button>
                        </div>
                    </div>
                </div>
            </header>
            <Wrapper pokemonsData={pokemonsData} filterPoke={inputData}/>
        </div>
    );
}

export default App;
