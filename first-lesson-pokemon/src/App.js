import './App.css';
import {useEffect, useState} from "react";
import Wrapper from "./Component/Wrapper";
import Header from "./Component/Header";
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

    const handleInputChange = (value) => {
        setInputData(value)
    }

    return (
        <div className="App">
            <Header changeInputData={handleInputChange}/>
            <Wrapper pokemonsData={pokemonsData} filterPoke={inputData}/>
        </div>
    );
}

export default App;
