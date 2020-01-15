function Largest(arg1, arg2, arg3) {
    let largest = 0;
    if (arg1 > arg2 && arg1 > arg3) {
        largest = arg1;
    }
    else if (arg2 > arg1 && arg2 > arg3) {
        largest = arg2;
    }
    else if (arg3 > arg1 && arg3 > arg2) {
        largest = arg3;
    }

    console.log(`The largest number is ${largest}.`);
}

Largest(-3, -5, -22.5);