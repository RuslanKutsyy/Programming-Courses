function getHeros(input) {
    let heros = [];

    for (let i = 0; i < input.length; i++) {
        let currentHeroData = input[i].split(' / ');
        let heroName = currentHeroData[0];
        let heroLevel = currentHeroData[1];
        let heroItems = [];

        if (currentHeroData.length > 2) {
            heroItems =currentHeroData[2].split(", ");
        }

        let hero = {
            name : heroName,
            level : Number(heroLevel),
            items : heroItems
        }
        
        heros.push(hero);
    }

    console.log(JSON.stringify(heros));
}

getHeros(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);