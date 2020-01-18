function cookingByNumbers(input) {
    let number = input.shift();
    let command = input.shift();


    while (command !== undefined) {
        if (command === 'chop') {
            number/=2;
        }
        if (command === 'dice') {
            number = Math.sqrt(number);
        } 
        if (command === 'spice') {
            number += 1;
        } 
        if (command === 'bake') {
            number *= 3;
        }
        if (command === 'fillet') {
            number -= number * 0.2;
        }

        command = input.shift();
        console.log(number);
    }
}

cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);