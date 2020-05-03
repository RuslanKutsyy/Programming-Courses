function biggestElement(input) {
    let biggestNum = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < input.length; i++) {
        let tempArr = input[i].map(Number);

        let max = tempArr.reduce(function(a, b) {
            return Math.max(a, b);
        })

        if (max > biggestNum) {
            biggestNum = max;
        }
    }

    console.log(biggestNum);
}

biggestElement([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   );