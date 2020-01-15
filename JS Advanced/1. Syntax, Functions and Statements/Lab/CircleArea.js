function circleArea(arg) {
    let result;
    let type = typeof(arg);
    if (type === "number") {
        result = (Math.PI * Math.pow(arg, 2)).toFixed(2);
    }
    else{
        result = `We can not calculate the circle area, because we receive a ${type}.`;
    }

    console.log(result);
}

circleArea('name');