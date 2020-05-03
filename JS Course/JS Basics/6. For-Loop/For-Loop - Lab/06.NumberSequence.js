function NumberSequence(input) {
    let numOfNums = Number(input.shift());
    let minNum = Number.MAX_SAFE_INTEGER;
    let maxNum = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < numOfNums; i++) {
        let num = Number(input.shift());
        if (num >= maxNum) {
            maxNum = num;
        }
        if (num <= minNum) {
            minNum = num;
        }
    }

    console.log(`Max number: ${maxNum}`);
    console.log(`Min number: ${minNum}`);
}

NumberSequence([
    "5",
    "10",
    "20",
    "304",
    "0",
    "50"
]);