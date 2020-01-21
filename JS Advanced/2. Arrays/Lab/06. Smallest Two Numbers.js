function smallestTwoNumbers(input) {
    let arr = input.map(Number);
    arr = arr.sort(function(a, b) {return a-b}).slice(0, 2);

    console.log(arr.join(" "));
}

smallestTwoNumbers([3, 0, 10, 4, 7, 3]);