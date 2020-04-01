let solution = (function() {
    let microelements = {
        carbohydrate : 0,
        flavour : 0,
        fat : 0,
        protein : 0
    };

    let recipes = {
        apple : {
            carbohydrate : 1,
            flavour : 2
        },
        lemonade : {
            carbohydrate : 10,
            flavour : 20
        },
        burger : {
            carbohydrate : 5,
            fat : 7,
            flavour : 3
        },
        eggs : {
            protein : 5,
            fat : 1,
            flavour : 1
        },
        turkey : {
            protein : 10,
            carbohydrate : 10,
            fat : 10,
            flavour : 10,
        }
    }

    function commandProcessing(command) {
        let data = command.split(' ');
        switch (data[0]) {
            case 'restock': {
                let microel = data[1];
                let quantity = Number(data[2]);
                if (microelements[microel] !== 'undefined') {
                    microelements[microel] += quantity;
                    return 'Success';
                }
            };
            case 'prepare': {
                let meal = data[1];
                let quantity = Number(data[2]);
                if (recipes[meal] !== 'undefined') {
                    return preparationProcess(meal, quantity);
                }
            };
            case 'report': {
                let storageAsString = `protein=${microelements.protein} carbohydrate=${microelements.carbohydrate} fat=${microelements.fat} flavour=${microelements.flavour}`;
                return storageAsString;
            };
        }
    }

    function preparationProcess(meal, quantity){
        let check = enoughMicroelements();
        if (typeof(check) === 'boolean') {

            Object.keys(recipes[meal]).forEach(el => microelements[el] -= recipes[meal][el] * quantity);

            return 'Success';
        }

        return `Error: not enough ${check} in stock`;

        function enoughMicroelements() {
            let answer = undefined;
            answer = Object.keys(recipes[meal]).find((el) => recipes[meal][el] * quantity > microelements[el]);
            if (typeof(answer) === 'undefined') {
                answer = true;
            }
            return answer;
        }
    }

    return (input) => commandProcessing(input);

    
});

let manager = solution();
manager("restock carbohydrate 10");  // Success
manager("restock flavour 10"); // Success
manager("prepare apple 1"); // Success
manager("restock fat 10"); // Success
manager("prepare burger 1"); // Success
manager("report");