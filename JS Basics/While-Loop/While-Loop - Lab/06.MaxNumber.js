function MaxNumber(input) {
    let nums = parseInt(input.shift());
    let maxNum = Number.MIN_SAFE_INTEGER;

    while (nums != 0) {
        let temp = parseInt(input.shift());
        if (temp > maxNum) {
            maxNum = temp;
        }
        nums --;
    }

    console.log(maxNum);    
}

MaxNumber(["2", "-1", "-2"]);