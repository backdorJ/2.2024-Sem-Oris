import {useState} from "react";

export const useFetchingPoke = (callback) => {
    const [isLoading, setIsLoading] = useState(false)

    const fetching = async () => {
        try{
            setIsLoading(true)
            await callback();
        } catch(e){
            console.log(e.message)
        } finally {
            setIsLoading(false)
        }
    }

    return [isLoading, fetching]
}