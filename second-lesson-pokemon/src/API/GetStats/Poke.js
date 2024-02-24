export class Poke {
    static async getImagePoke(url){
        const response = await fetch(url)
        return await response.json();
    }
}