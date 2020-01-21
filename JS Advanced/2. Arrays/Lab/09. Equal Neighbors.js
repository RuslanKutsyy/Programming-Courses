function equalNeighbors(data) {
    let count = 0;
    for (let row = 0; row < data.length; row++) {
        if (row !== data.length - 1) {
            for (let j = 0; j < data[row].length; j++) {
                if (data[row][j] === data[row + 1][j]) {
                    count++;
                }
                if (data[row][j] === data[row][j + 1]) {
                    count++;
                }
            }   
        } else {
            for (let j = 0; j < data[row].length; j++) {
                if (data[row][j] === data[row][j + 1]) {
                    count++;
                }
            }
        }
    }
    console.log(count);
}

equalNeighbors([['2', '2', '5', '7', '4'],
    ['4', '0', '5', '3', '4'],
    ['2', '5', '5', '4', '2']]
);