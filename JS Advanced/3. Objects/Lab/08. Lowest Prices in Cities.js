function findLowestPrice(params) {
    let pricing = new Map();

    for (let i = 0; i < params.length; i++) {
        let data = params[i].split(" | ");
        let city = data[0];
        let product = data[1];
        let price = Number(data[2]);

        if (!pricing.has(product)) {
            pricing.set(product, new Map());
        }

        pricing.get(product).set(city, price);
    }

    for (let [product, internalMap] of pricing) {
        let lowestPrice = Number.MAX_SAFE_INTEGER;
        let lowestCity = "";

        for (let [city, price] of internalMap) {
            if (price < lowestPrice) {
                lowestPrice = price;
                lowestCity = city;
            }
        }

        console.log(`${product} -> ${lowestPrice} (${lowestCity})`);
    }

}

findLowestPrice(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']);