function aggregateElements(args) {
    console.log(Sum(args));
    console.log(inversedSum(args));
    console.log(concat(args));    
}

function Sum(data) {
    let result = 0;
    for (let i = 0; i < data.length; i++) {
        result += Number(data[i]);
    }
    return result;
}

function inversedSum(data) {
    let result = 0;
    for (let i = 0; i < data.length; i++) {
        result += 1/Number(data[i]);
    }
    return result.toFixed(4);
}

function concat(data) {
    let result = '';
    for (let i = 0; i < data.length; i++) {
        result += data[i];
    }
    return result;
}

aggregateElements(['2', '4', '8', '16']);