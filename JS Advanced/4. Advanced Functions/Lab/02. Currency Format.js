function returnData(currencyFormatter) {
    let separator = ",";
    let symbol = "$";
    let symbolFirst = true;
    
    let dollarFormatter = value => currencyFormatter(separator, symbol, symbolFirst, value);
    return dollarFormatter;
}

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

let dollarFormatter = returnData(currencyFormatter);
console.log(dollarFormatter(5345));