function almostIncreasingSequence(sequence) {
    let increaseCheck;
    for (let i = 0; i < sequence.length; i++){
        let tempArr = [];

        for (let el of sequence) {
            if (el != sequence[i]) {
                tempArr.push(el);
            }
        }

        increaseCheck = increasing(tempArr);

        if (increaseCheck === true) {
            break;
        }

    }

    console.log(increaseCheck);


    function increasing(someArray) {
        let current = someArray[0];
        for (let i = 1; i < someArray.length; i++) {
            if (someArray[i] <= current) {
                return false;
            }
            current = someArray[i];
        }

        return true;
    }
}

almostIncreasingSequence([1, 1, 1, 2, 3]);