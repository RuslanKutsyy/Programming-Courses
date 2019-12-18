function isBigger(input){
    let a = input.shift();
    let b = input.shift();

    if (a > b){
        console.log(a);
    }
    else{
        console.log(b);
    }
}

isBigger([5,7]);