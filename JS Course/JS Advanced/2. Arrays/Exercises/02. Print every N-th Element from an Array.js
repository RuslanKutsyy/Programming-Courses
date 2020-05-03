function printNthElement(input) {
    let n = Number(input.pop());

    for (let i = 0; i < input.length; i+=n) {
        console.log(input[i]);
    }
}
printNthElement(['1', 
'2',
'3', 
'4', 
'5', 
'6']);