function HalfSumElement(input) {
    let numOfNumbers = Number(input.shift());
    var data = input + '';
    var numsArr = data.split(",").map(Number);
    let sum = 0;
    let result = Number.NaN;
    let biggest = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < numsArr.length; i++) {
        sum += numsArr[i];
        if (numsArr[i] > biggest) {
            biggest = numsArr[i];
        }
    }    

    for (let j = 0; j < numsArr.length; j++) {
        if (numsArr[j] == sum - numsArr[j]) {
            result = numsArr[j];
        }
    }

    if (!Number.isNaN(result)) {
        console.log("Yes");
        console.log(`Sum = ${result}`);
    } else{
        console.log("No");
        console.log(`Diff = ${Math.abs(biggest - (sum - biggest))}`);        
    }
}

HalfSumElement([
    "3",
    "1",
    "1",
    "10",
]);