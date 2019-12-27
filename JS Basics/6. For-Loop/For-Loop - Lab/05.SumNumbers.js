function NumSum(params) {
    let numberOfNums = Number(params.shift());
    let sum = 0;

    for (let i = 0; i < numberOfNums; i++) {
        let num = Number(params.shift());
        sum+=num;
    }
    console.log(sum);
    
}

NumSum([
    "2",
    "10",
    "20"
]);