function sortArray(arg1, arg2) {
    return arg1.sort((a, b) => arg2 === 'asc' ? a - b : b - a);
}

sortArray([14, 7, 17, 6, 8], 'desc');