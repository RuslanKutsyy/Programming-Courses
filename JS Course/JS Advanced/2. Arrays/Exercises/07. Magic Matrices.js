function ifMagic(input) {
    let matrix = input.map(row => row.map(Number));
    let sum = matrix[0].reduce((a, b) => a + b);
    let isMagic = true;

    for (let i = 1; i < matrix.length; i++) {
        if (sum !== matrix[i].reduce((a, b) => a + b)) {
            isMagic = false;
        }
    }

    for (let col = 0; col < matrix.length; col++) {
        let colSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            colSum+= matrix[row][col];
        }

        if (sum !== colSum) {
            isMagic = false;
        }
    }

    console.log(isMagic);

}

ifMagic([['1', '0', '0'],
    ['0', '0', '1'],
    ['0', '1', '0']]     
   );