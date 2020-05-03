function diagonalSums(input) {
    let mainSum = 0 , secondarySum = 0;

    for (let i = 0; i < input.length; i++) {
        mainSum += input[i][i];
        secondarySum += input[i][input[i].length - 1 - i];
    }
    console.log(`${mainSum} ${secondarySum}`);
}

diagonalSums([[20, 40],
    [10, 60]]      
   );