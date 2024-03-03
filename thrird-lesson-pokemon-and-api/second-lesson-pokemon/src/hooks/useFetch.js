import { useEffect, useState } from "react";

export const useFetch = (url, offset) => {
    const [data, setData] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        setIsLoading(true);
        fetch(`${url}?limit=20&offset=${offset}`)
            .then(res => res.json())
            .then(result => setData(result.results))
            .finally(() => setIsLoading(false));
    }, [url, offset]);

    return [isLoading, data];
};