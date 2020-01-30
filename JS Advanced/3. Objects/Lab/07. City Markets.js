function calculateIncome(input) {
    let sales = {};
    let stringToPrint = "";

    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(/\s+(?:-\>|\:)\s+/);
        let cityName = data[0];
        let product = data[1];
        let amountOfSales = Number(data[2]);
        let priceForOneUnit = Number(data[3]);

        if (!sales.hasOwnProperty(cityName)) {
            sales[cityName] = null;
            sales[cityName] = {
                [product] : amountOfSales * priceForOneUnit
            }
        } else {
            sales[cityName][product] = amountOfSales * priceForOneUnit;
        }

    }
    
    for (let key in sales) {
        stringToPrint += `Town - ${key}\n`;
        for (let prod in sales[key]) {
            stringToPrint += `$$$${prod} : ${sales[key][prod]}\n`
        }
    }

    console.log(stringToPrint);
}

calculateIncome(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']);