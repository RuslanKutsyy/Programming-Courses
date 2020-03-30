let solution = (function() {
    let microelements = {
        carb : 0,
        flavour : 0,
        fat : 0,
        protein : 0
    };

    let recipes = {
        apple : {
            carb : 1,
            flavour : 2
        },
        lemonade : {
            carb : 10,
            flavour : 20
        },
        burger : {
            carb : 5,
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
            carb : 10,
            fat : 10,
            flavour : 10
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
                return `Error: not enough ${microel} in stock`;
            };
            case 'prepare': {
                let meal = data[1];
                let quantity = Number(data[2]);
                if (recipes[meal] !== 'undefined') {

                }
            }
        }
    }

    function preparationCheck(meal){
        
    }

    return function (input) {
        commandProcessing(input);
    }

    
});

let manager = solution();
manager("restock flavour 50");  // Success
manager("prepare lemonade 4");  // Error: not enough carbohydrate in stock