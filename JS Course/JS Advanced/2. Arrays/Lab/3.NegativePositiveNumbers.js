function negativePositiveNumbers(params) {
    let arr = params.map(Number);
    let result = [];

    for(let element of arr) {
        if(element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    }

    console.log(result.join(' '));
}

negativePositiveNumbers([3, -2, 0, -1, 0]);