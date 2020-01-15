function SquareOfStars(arg) {
    let typeOfArg = typeof(arg);
    
    if (typeOfArg === 'number') {
        for (let i = 0; i < arg; i++) {
            console.log('* '.repeat(arg));            
        }
    }
    else{
        for (let i = 0; i < 5; i++) {
            console.log('* '.repeat(5));            
        }
    }
}

SquareOfStars();