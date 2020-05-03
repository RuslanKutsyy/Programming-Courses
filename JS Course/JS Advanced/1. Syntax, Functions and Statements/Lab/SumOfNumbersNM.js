function Sum(arg1, arg2) {
    let num1 = Number(arg1);
    let num2 = Number(arg2);
    let sum = 0;

    for (let startNum = num1; startNum <= num2; startNum++){
        sum += startNum;
    }

    console.log(sum);    
}

Sum('-8', '20');