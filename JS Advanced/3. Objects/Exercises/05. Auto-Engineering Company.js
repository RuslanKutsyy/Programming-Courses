function carCatalog(input) {
    let catalog = new Map();

    for (let line of input) {
        let data = line.split('|').map(x => x.trim());

        let brand = data[0];
        let model = data[1];
        let numberOfCars = Number(data[2]);

        if (!catalog.get(brand)) {
            catalog.set(brand, new Map());
        }

        if (!catalog.get(brand).get(model)) {
            catalog.get(brand).set(model, 0);   
        }

        catalog.get(brand).set(model,catalog.get(brand).get(model) + numberOfCars);
    }

    for (let [brand, models] of catalog) {
        console.log(brand);
        
        for (let [model, numberOfCars] of catalog.get(brand)) {
            console.log(`###${model} -> ${catalog.get(brand).get(model)}`);
        }
    }
}

carCatalog(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);