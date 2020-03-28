function sortArray(data, criteria) {
    return criteria === 'asc' ? data.sort((a, b) => a - b) : data.sort((a, b) => b - a);
}

sortArray([14, 7, 17, 6, 8], 'asc');