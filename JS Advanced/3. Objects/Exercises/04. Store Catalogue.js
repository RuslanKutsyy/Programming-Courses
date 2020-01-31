function productSorting(input) {
    let catalog = new Map();

    for (let line of input) {
        let data = line.split(' : ');
        let product = data[0];
        let price = data[1];
        catalog.set(product, price);
    }

    let chars = new Set();

    Array.from(catalog.keys()).forEach(x => chars.add(x[0]));

    for (let char of Array.from(chars.keys()).sort()) {
        console.log(char);

        for (let prod of Array.from(catalog.keys()).sort()) {
            if (prod.startsWith(char)) {
                console.log(`  ${prod}:${catalog.get(prod)}`);
            }
        }
    }

}

productSorting(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);