function EvenOrOdd(input){
    let a = input.shift();
    if (a % 2 == 0){
        console.log(`even`);
    }
    else {
        console.log(`odd`);
    }
}

EvenOrOdd([5]);