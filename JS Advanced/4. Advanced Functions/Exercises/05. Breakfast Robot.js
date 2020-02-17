let manager = (function solution() {

    const products = {
        apple: {
            carbohydrates: 1,
            flavours: 2
        },
        lemonade : {
            carbohydrates: 10,
            flavours: 20
        },
        burger : {
            carbohydrates: 5,
            fat: 7,
            flavours: 3
        },
        eggs : {
            protein: 5,
            fat: 1,
            flavours: 1
        },
        turkey : {
            protein: 10,
            carbohydrates : 10,
            fat: 10,
            flavours: 10
        }
    };

    let storage = {
        protein: 0,
        carbohydrates: 0,
        fat: 0,
        flavours: 0
    };

    function addElementToStorage(type, quantity) {
        storage[type]+=quantity;
        return 'Success';
    }

    function startCooking(type, quantity) {
        let storageCheck = isEnoughElementstoCook();

        if (storageCheck === 'Success') {
            cook();
        }

        return storageCheck;

        function cook(){
            for (let el of products[type]) {
                let neededEl = products[type][el] * quantity;
                storage[el] -= neededEl;
            }
        }

        function isEnoughElementstoCook() {
            let result = 'Success';

            for (let el of products[type]) {
                let needed = products[type][el] * quantity;

                if (needed > storage[el]) {
                    result = `Error: not enough ${el} in stock`;
                    break;
                }
            }
            
            return result;
        }
    }

    function printReport() {
        return object.keys(storage).map(key => {
            return `${key}=${storage[key]}`;
        }).join(' ');
    }

    return function (data) {
        let [command, type, quantity] = data.split(' ');
        quantity = Number(quantity);

        const functions = {
            restock: () => {
                return addElementToStorage(type, quantity);
            },
            prepare: () => {
                return startCooking(type, quantity);
            },
            report: () => {
                return printReport();
            }
        };

        return functions[command];
    }
});

manager("restock flavour 50");  // Success
manager("prepare lemonade 4");