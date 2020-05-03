function sameNumber(arg) {
    let firstNum = arg%10;
    var numAsText = String(arg).split('');
    let same =true;
    let sum = 0;

    for (let i = 0; i < numAsText.length; i++) {
        let temp = Number(numAsText[i]);
        sum+=temp;
        if (same === true && temp !==firstNum) {
             same = false;
        }
    }

    console.log(same);
    console.log(sum);    
}

sameNumber(2222222);