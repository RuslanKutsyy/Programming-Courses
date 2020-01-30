function productSorting(input) {
    let parsedData = input.reduce((acc, product) => {
        let [name, price] = product.split(':').map(x => x.trim());

        if (acc[name[0]]) {
            acc[name[0]] = [...acc[name[0]], product];
        } else {
            acc[name[0]] = [product];
        }

        return acc;

    },  {})

    console.log(parsedData)

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