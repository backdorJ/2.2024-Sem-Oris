export class ColorFilter {
    static getColorByName(name){
        const colors = new Map();

        colors.set("bug", "#42946C");
        colors.set('dragon', '#61C1B6');
        colors.set('grass', '#5ABE79');
        colors.set('steel', '#8FDFAB');
        colors.set('dark', '#444649');
        colors.set('flying', '#8E9BAB');
        colors.set('normal', '#B98EB7');
        colors.set('ghost', '#91589D');
        colors.set('rock', '#5D3515');
        colors.set('ground', '#815831');
        colors.set('fighting', '#B95821');
        colors.set('fire', '#DC3E2D');
        colors.set('electric', '#F5C242');
        colors.set('poison', '#6846F6');
        colors.set('psychic', '#C92AB1');
        colors.set('fairy', '#DC506A');
        colors.set('water', '#4960E6');
        colors.set('ice', '#A2DEED');

        return colors.get(name);
    }

    static getColorByBlock(name){
        const colors = new Map();

        colors.set('card__movies__1', '#14C172');
        colors.set('card__movies__2', '#6E44FF');
        colors.set('card__movies__3', '#14C172');
        colors.set('card__movies__4', '#C18CBA');
        colors.set('card__movies__5', '#C18CBA');
        colors.set('card__movies__6', '#14C172');

        return colors.get(name?.toString()?.toLowerCase())
    }
}