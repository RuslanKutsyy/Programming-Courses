function StringLength(input) {
    let sumOfLengths = 0;
    let word = input.shift();
    let count = 0;
    
    while (word != null) {
        sumOfLengths+= word.length;
        count++;
        word = input.shift();
    }
    console.log(`${sumOfLengths}`);
    console.log(`${Math.floor(sumOfLengths/count)}`);
}

StringLength(["chocolate", "ice cream", "cake"]);
