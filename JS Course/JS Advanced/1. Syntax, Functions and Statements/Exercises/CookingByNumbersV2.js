function CookingByNumbersV2(params) {
    let number = Number(params[0]);

    let functions = {
        chop: (number) => number/2,
        dice: (number) => Math.sqrt(number),
        spice: (number) => number + 1,
        bake: (number) => number * 3,
        fillet: (number) => number * 0.8
    }

    for (let i = 1; i < params.length; i++) {
        number = functions[params[i]](number);
        console.log(number);       
    }
}

CookingByNumbersV2(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);