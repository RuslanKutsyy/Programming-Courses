function adjacentElementsProduct(inputArray) {
    let max = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < inputArray.length; i++) {
        let temp = inputArray[i] * inputArray[i+1];
        if (temp > max) {
            max = temp;
        }
    }
    return max;
}