function Sequence2k1(input) {
    let originalNum = input.shift();
    let num = 1;

    while (num <= originalNum) {
        console.log(num);
        num = num * 2 + 1;
    }
}

Sequence2k1([31]);