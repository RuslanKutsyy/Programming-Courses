function evenPositionElements(params) {
    let arr = [];
    for (let i = 0; i < params.length; i++) {
        if (i % 2 === 0) {
            arr.push(params[i]);
        }
    }

    console.log(arr.join(' '));
}

evenPositionElements(['20', '30', '40']);