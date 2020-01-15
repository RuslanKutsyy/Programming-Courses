function resolve(arg1, arg2, arg3) {
    let firstNum = Number(arg1);
    let secondNum = Number(arg2);
    let result;

    switch (arg3) {
        case '+':
            result = firstNum + secondNum;
            break;
        case '-':
            result = firstNum - secondNum;
            break;
        case '*':
            result = firstNum * secondNum;
            break;
        case '/':
            result = firstNum/secondNum;
            break;
        case '%':
            result = firstNum%secondNum;
            break;
        case '**':
            result = firstNum ** secondNum;
            break;
        default:
            break;
    }

    console.log(result);    
}

resolve(3, 5.5, '*');