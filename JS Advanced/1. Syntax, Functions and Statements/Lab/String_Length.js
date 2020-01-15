function StringLength(arg1, arg2, arg3) {
    let sumOfLengths;
    let averageLength;

    let first = arg1.length;
    let second = arg2.length;
    let third = arg3.length;
    sumOfLengths = first + second + third;
    averageLength = Math.floor(sumOfLengths/3);

    console.log(sumOfLengths);
    console.log(averageLength);
}

StringLength("chocolate", "ice cream", "cake");
