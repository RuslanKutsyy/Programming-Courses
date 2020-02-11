function almostIncreasingSequence(sequence) {
    let fails = 0;
    let max = Math.pow(-10, 5);
    let secondMax = Math.pow(-10, 5);

    sequence.map(element => {
        if (element > max) {
            secondMax = max;
            max = element;
        } else if (element > secondMax){
            max = element;
            fails++;
        } else fails++;
    });

    return fails <= 1;
}

almostIncreasingSequence([10, 1, 2, 3, 4, 5]);