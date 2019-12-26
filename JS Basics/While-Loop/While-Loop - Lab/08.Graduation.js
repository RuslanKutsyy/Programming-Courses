function Graduation(input) {
    let gradeCount = 1;
    let gradeSum = 0;
    let name = input.shift();

    while (gradeCount <= 12) {
        let grade = parseFloat(input.shift());
        if (grade >= 4.00) {
            gradeSum += grade;
            gradeCount++;
            grade = 0;
        }
    }

    console.log(`${name} graduated. Average grade: ${(gradeSum/12).toFixed(2)}`);    
}


Graduation([
    "Ani",
    "5",
    "5.32",
    "6",
    "5.43",
    "5",
    "6",
    "5.5",
    "4.55",
    "5",
    "6",
    "5.56",
    "6"
]);