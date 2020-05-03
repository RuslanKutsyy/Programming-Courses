function solution() {
    let internalString = '';
    return functions = {
        append : (input) => internalString += input,
        removeStart : (input) => internalString = internalString.substr(input, internalString.length),
        removeEnd : (input) => internalString = internalString.substr(0, internalString.length - input),
        print : () => console.log(internalString)
    }
}

    let secondZeroTest = solution();

    secondZeroTest.append('123');
    secondZeroTest.append('45');
    secondZeroTest.removeStart(2);
    secondZeroTest.removeEnd(1);
    secondZeroTest.print();        