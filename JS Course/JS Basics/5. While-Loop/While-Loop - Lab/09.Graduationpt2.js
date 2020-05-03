function Graduation2(input) {
    let name = input.shift();
    let gradeSum = 0;
    let gradeNum = 1;

    while (gradeNum <= 12) {
        let grade = parseFloat(input.shift());
        if (grade < 4.0) {
            let gradeNext = parseFloat(input.shift());
            if (gradeNext < 4.00) {
                break;
            }
            else{
                gradeSum += gradeNext;
                gradeNum++;
            }
        }
        else {
            gradeSum += grade;
            if (gradeNum != 12) {
                gradeNum++;   
            }
            else{
                break;
            }
        }
    }

    if (gradeNum == 12) {
        console.log(`${name} graduated. Average grade: ${(gradeSum/12).toFixed(2)}`);
        
    } else{
        console.log(`${name} has been excluded at ${gradeNum} grade`);
    }
}

Graduation2([
    "Mimi",
    "5",
    "6",
    "5",
    "6",
    "5",
    "6",
    "6",
    "2",
    "3"
]);